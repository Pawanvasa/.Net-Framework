using RabbitMQ.Client;

namespace RabbitMQPublisher.RabbitMQConnection
{
    public class RabbitMQConnection
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private readonly IConfiguration configProvider;
        public RabbitMQConnection(IConfiguration configuration)
        {
            configProvider = configuration;
            _connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(configProvider.GetValue<string>("rabbitMq:Uri"))!,
                UserName = configProvider.GetValue<string>("rabbitMq:user")!,
                Password = configProvider.GetValue<string>("rabbitMq:password")!
            };
        }

        public IModel CreateModel()
        {
            if (_connection == null || !_connection.IsOpen)
                _connection = _connectionFactory.CreateConnection();

            return _connection.CreateModel();
        }

        public void Close()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
