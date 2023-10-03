using RabbitMQBus;
using RabbitMQConsumer.Models;
using RabbitMQConsumer.Services;

namespace RabbitMQConsumer.EventConsumer
{
    public class TestProductIntegrationEventHandler : IIntegrationEventHandler<TestProduceIntegrationEvent>
    {
        private readonly ConsumerService _consumerService;
        public TestProductIntegrationEventHandler(ConsumerService service)
        {
            _consumerService = service;
        }
        public async Task Handle(TestProduceIntegrationEvent @event)
        {
            Console.WriteLine($"Received event of '{@event.Message}'");
            var persons = @event.Person!.Select(p => new PersonCopy
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email
            }).ToList();
            await _consumerService.BulkInsertFromJsonFileAsync(persons, "PersonCopy");
        }
    }
}
