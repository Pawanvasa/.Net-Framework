using RabbitMQ.Client;
using System.Text;

ConnectionFactory connectionFactory = new()
{
    Uri = new Uri("amqp://guest:guest@localhost:5672"),
    ClientProvidedName = "Rabbit Sender App"
};


IConnection connection = connectionFactory.CreateConnection();

IModel channel = connection.CreateModel();

string exchangeName = "DemoExchange";
string routingKey = "Demo-routing-key";
string queueName = "DemoQueue";

channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
channel.QueueDeclare(queueName, false, false, false);
channel.QueueBind(queueName, exchangeName, routingKey, null);

//byte[] message = Encoding.UTF8.GetBytes("Demo Message");
//channel.BasicPublish(exchangeName, routingKey, null, message);

for (int i = 0; i < 60; i++)
{
    Console.WriteLine($"Sending Message {i}");
    byte[] message = Encoding.UTF8.GetBytes($"Message {i}");
    channel.BasicPublish(exchangeName, routingKey, null, message);
    Thread.Sleep(1000);

}

channel.Close();
connection.Close();