using Confluent.Kafka;
using Confluent.Kafka.Admin;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


static async Task Produce(string topicName, ClientConfig config)
{
    Console.WriteLine($"{nameof(Produce)} starting");
    // The URL of the EventStreams service.
    string eventStreamsUrl = "https://stream.wikimedia.org/v2/stream/recentchange";
    // Declare the producer reference here to enable calling the Flush
    // method in the finally block, when the app shuts down.
    IProducer<string, string> producer = null!;
    try
    {
        using (var adminClient = new AdminClientBuilder(config).Build())
        {
            var topicMetadata = adminClient.GetMetadata(TimeSpan.FromSeconds(5));

            if (!topicMetadata.Topics.Any(t => t.Topic.Equals(topicName, StringComparison.OrdinalIgnoreCase)))
            {
                var topicSpecs = new TopicSpecification[]
                {
                    new TopicSpecification
                    {
                        Name = topicName,
                        NumPartitions = 6,
                        ReplicationFactor = 3
                    }
                };

                await adminClient.CreateTopicsAsync(topicSpecs);
            }
        }
        // Build a producer based on the provided configuration.
        // It will be disposed in the finally block.
        producer = new ProducerBuilder<string, string>(config).Build();
        // Create an HTTP client and request the event stream.
        using (var httpClient = new HttpClient())
        // Get the RC stream. 
        using (var stream = await httpClient.GetStreamAsync(eventStreamsUrl))
        // Open a reader to get the events from the service.
        using (var reader = new StreamReader(stream))
        {
            // Read continuously until interrupted by Ctrl+C.
            while (!reader.EndOfStream)
            {
                // Get the next line from the service.
                var line = reader.ReadLine();
                // The Wikimedia service sends a few lines, but the lines
                // of interest for this demo start with the "data:" prefix. 
                if (!line!.StartsWith("data:"))
                {
                    continue;
                }
                // Extract and deserialize the JSON payload.
                int openBraceIndex = line.IndexOf('{');
                string jsonData = line.Substring(openBraceIndex);
                Console.WriteLine($"Data string: {jsonData}");
                // Parse the JSON to extract the URI of the edited page.
                var jsonDoc = JsonDocument.Parse(jsonData);
                var metaElement = jsonDoc.RootElement.GetProperty("meta");
                var uriElement = metaElement.GetProperty("uri");
                var key = uriElement.GetString(); // Use the URI as the message key.
                // For higher throughput, use the non-blocking Produce call
                // and handle delivery reports out-of-band, instead of awaiting
                // the result of a ProduceAsync call.
                producer.Produce(topicName, new Message<string, string> { Key = key!, Value = jsonData },
                    (deliveryReport) =>
                    {
                        if (deliveryReport.Error.Code != ErrorCode.NoError)
                        {
                            Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
                        }
                        else
                        {
                            Console.WriteLine($"Produced message to: {deliveryReport.TopicPartitionOffset}");
                        }
                    });
            }
        }
    }
    catch (Exception ex)
    {
        throw;
    }
    finally
    {
        var queueSize = producer.Flush(TimeSpan.FromSeconds(5));
        if (queueSize > 0)
        {
            Console.WriteLine("WARNING: Producer event queue has " + queueSize + " pending events on exit.");
        }
        producer.Dispose();
    }
}



static void Consume(string topicName, ClientConfig config)
{
    Console.WriteLine($"{nameof(Consume)} starting");
    // Configure the consumer group based on the provided configuration. 
    var consumerConfig = new ConsumerConfig(config);
    consumerConfig.GroupId = "wiki-edit-stream-group-1";
    // The offset to start reading from if there are no committed offsets (or there was an error in retrieving offsets).
    consumerConfig.AutoOffsetReset = AutoOffsetReset.Earliest;
    // Do not commit offsets.
    consumerConfig.EnableAutoCommit = false;
    // Enable canceling the Consume loop with Ctrl+C.
    CancellationTokenSource cts = new CancellationTokenSource();
    Console.CancelKeyPress += (_, e) =>
    {
        e.Cancel = true; // prevent the process from terminating.
        cts.Cancel();
    };
    // Build a consumer that uses the provided configuration.
    using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
    {
        // Subscribe to events from the topic.
        consumer.Subscribe(topicName);
        try
        {
            // Run until the terminal receives Ctrl+C. 
            while (true)
            {
                // Consume and deserialize the next message.
                var cr = consumer.Consume(cts.Token);
                // Parse the JSON to extract the URI of the edited page.
                var jsonDoc = JsonDocument.Parse(cr.Message.Value);
                // For consuming from the recent_changes topic. 
                var metaElement = jsonDoc.RootElement.GetProperty("meta");
                var uriElement = metaElement.GetProperty("uri");
                var uri = uriElement.GetString();
                // For consuming from the ksqlDB sink topic.
                // var editsElement = jsonDoc.RootElement.GetProperty("NUM_EDITS");
                // var edits = editsElement.GetInt32();
                // var uri = $"{cr.Message.Key}, edits = {edits}";
                Console.WriteLine($"Consumed record with URI {uri}");
            }
        }
        catch (OperationCanceledException)
        {
            // Ctrl+C was pressed.
            Console.WriteLine($"Ctrl+C pressed, consumer exiting");
        }
        finally
        {
            consumer.Close();
        }
    }
}


var clientConfig = new ClientConfig();
clientConfig.AllowAutoCreateTopics = true;  // allowing kafka to create automatic topic
clientConfig.BootstrapServers = "pkc-6ojv2.us-west4.gcp.confluent.cloud:9092";
clientConfig.SecurityProtocol = Confluent.Kafka.SecurityProtocol.SaslSsl;
clientConfig.SaslMechanism = Confluent.Kafka.SaslMechanism.Plain;
clientConfig.SaslUsername = "2DB4ZOUIDVP2YDQ3";
clientConfig.SaslPassword = "mrDuZecS9Fse7p2/K8HHdEVUutHFsCkwTfUV3KJcG8BBamvsR9xKr3c2EEHjB3Cs";
clientConfig.SslCaLocation = "probe"; // /etc/ssl/certs
await Produce("New_Topic", clientConfig);
//Consume("recent_changes", clientConfig);
Console.WriteLine("Exiting");


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
