using RabbitMQPublisher.Model;

namespace RabbitMQPublisher.Services
{
    public class ProducerService : IProducerService
    {
        private readonly EmployeeManagementContext _context;
        public ProducerService(EmployeeManagementContext context)
        {
            _context = context;
        }

        public List<Person> Get()
        {
            var persons = _context.People.ToList().GetRange(0, 10000);
            return persons;
        }
    }
}
