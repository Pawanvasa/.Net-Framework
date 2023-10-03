using Confluent.Kafka;
using Confluent.SchemaRegistry.Serdes;
using RabbitMQBus;
using RabbitMQEventIntegrationBus.KafkaConnection;
using RabbitMQPublisher.Model;
using RabbitMQPublisher.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddTransient<TestProductIntegrationEventHandler>();
//builder.Services.AddSingleton<IEventBusSubscriptionManager, EventBusSubscriptionManager>();
//builder.Services.AddSingleton<IEventBus, RabbitMQEventBus>(sp =>
//{
//    var rabbitMqConnection = sp.GetRequiredService<RabbitMQConnection>();
//    var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionManager>();
//    return new RabbitMQEventBus(eventBusSubcriptionsManager, rabbitMqConnection, sp);
//});
//builder.Services.AddSingleton<RabbitMQConnection>();

builder.Services.AddScoped<EmployeeManagementContext>();
builder.Services.AddScoped<IProducerService, ProducerService>();


var config = new ClientConfig
{
    BootstrapServers = "pkc-6ojv2.us-west4.gcp.confluent.cloud:9092",
    SecurityProtocol = SecurityProtocol.SaslSsl,
    SaslMechanism = SaslMechanism.Plain,
    SaslUsername = "2DB4ZOUIDVP2YDQ3",
    SaslPassword = "mrDuZecS9Fse7p2/K8HHdEVUutHFsCkwTfUV3KJcG8BBamvsR9xKr3c2EEHjB3Cs",
    AllowAutoCreateTopics = true,
    SslCaLocation = "probe"
};

var schemaRegistryConfiguration = new Confluent.SchemaRegistry.SchemaRegistryConfig
{
    Url = "https://pkc-6ojv2.us-west4.gcp.confluent.cloud:443",
    BasicAuthCredentialsSource = Confluent.SchemaRegistry.AuthCredentialsSource.UserInfo,
    BasicAuthUserInfo = "2DB4ZOUIDVP2YDQ3:mrDuZecS9Fse7p2/K8HHdEVUutHFsCkwTfUV3KJcG8BBamvsR9xKr3c2EEHjB3Cs",
    RequestTimeoutMs = 5000,
    MaxCachedSchemas = 10,
};

var avroSerializerConfiguration = new AvroSerializerConfig
{
    AutoRegisterSchemas = true
};

// Set up the event bus
builder.Services.AddSingleton<KafkaConnection>(new KafkaConnection(
    config,
    schemaRegistryConfiguration,
    avroSerializerConfiguration));
builder.Services.AddSingleton<IEventBusSubscriptionManager, EventBusSubscriptionManager>();
builder.Services.AddSingleton<IEventBus, KafkaEventBus>(sp =>
{
    var kafkaConnection = sp.GetRequiredService<KafkaConnection>();
    var eventBusSubscriptionsManager = sp.GetRequiredService<IEventBusSubscriptionManager>();
    return new KafkaEventBus(eventBusSubscriptionsManager, kafkaConnection, sp, config);
});

builder.Services.AddControllers();
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
