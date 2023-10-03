using RabbitMQBus;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQPublisher.RabbitMQConnection
{
    public class RabbitMQEventBus : IEventBus
    {
        private readonly IEventBusSubscriptionManager _subscriptionManager;
        private readonly RabbitMQConnection _rabbitMQConnection;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RabbitMQEventBus(IEventBusSubscriptionManager subscriptionManager,
            RabbitMQConnection rabbitMQConnection, IServiceProvider serviceProvider)
        {
            _subscriptionManager = subscriptionManager;
            _rabbitMQConnection = rabbitMQConnection;
            _serviceScopeFactory = serviceProvider?.GetRequiredService<IServiceScopeFactory>()!;
        }

        public async Task PublishAsync<T>(T @event) where T : IntegrationEvent
        {
            try
            {
                var eventType = typeof(T).Name;

                using (var channel = _rabbitMQConnection.CreateModel())
                {
                    var queueName = channel.QueueDeclare(eventType, false, false, false);
                    channel.ExchangeDeclare("event-exchange", ExchangeType.Direct);
                    var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));
                    channel.BasicPublish("event-exchange", eventType, null, message);
                    Console.WriteLine($"Published event '{eventType}' to RabbitMQ");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SubscribeAsync<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>
        {
            try
            {
                var eventName = typeof(T).Name;
                using (var channel = _rabbitMQConnection.CreateModel())
                {
                    channel.ExchangeDeclare("event-exchange", ExchangeType.Direct);
                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(queueName, "event-exchange", eventName);

                    _subscriptionManager.AddSubscription<T, TH>();

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += async (sender, args) =>
                    {
                        var message = Encoding.UTF8.GetString(args.Body.ToArray());
                        await ProcessEvent<T>(message);

                        channel.BasicAck(args.DeliveryTag, false);
                    };

                    channel.BasicConsume(queueName, false, consumer);

                    Console.WriteLine($"Subscribed to event '{eventName}' from RabbitMQ");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task ProcessEvent<T>(string message) where T : IntegrationEvent
        {
            if (_subscriptionManager.HasEvent<T>())
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var subscriptions = _subscriptionManager.GetHandlersForEvent<T>();
                    foreach (var subscription in subscriptions)
                    {
                        var handler = scope.ServiceProvider.GetRequiredService(subscription);
                        if (handler == null) continue;
                        var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(typeof(T));
                        await (Task)concreteType.GetMethod("Handle")!.Invoke(handler, new object[] { JsonConvert.DeserializeObject<T>(message)! })!;
                    }
                }
            }
            Console.WriteLine($"Processed event of type '{typeof(T).Name}'");
        }
    }
}
