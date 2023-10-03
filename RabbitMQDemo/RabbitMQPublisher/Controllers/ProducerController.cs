using Microsoft.AspNetCore.Mvc;
using RabbitMQBus;
using RabbitMQPublisher.Model;
using RabbitMQPublisher.Services;

namespace RabbitMQPublisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IEventBus _eventBus;
        private readonly IProducerService _producerService;

        public ProducerController(IEventBus eventBus, IProducerService producerService)
        {
            _eventBus = eventBus;
            _producerService = producerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var persons = _producerService.Get();
            int batchSize = 500;

            for (int i = 0; i < persons.Count; i += batchSize)
            {
                var batch = persons.Skip(i).Take(batchSize);

                TestProduceIntegrationEvent @event = new TestProduceIntegrationEvent()
                {
                    Key = Guid.NewGuid().ToString(),
                    Message = $"Batch {i / batchSize + 1}",
                    Person = batch.Select(p => new Persons
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Email = p.Email
                    }).ToList()
                };
                _eventBus.PublishAsync(@event);
            }

            return Ok();
        }

    }
}
