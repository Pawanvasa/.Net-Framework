using RabbitMQPublisher.Model;

namespace RabbitMQPublisher.Services
{
    public interface IProducerService
    {
        List<Person> Get();
    }
}
