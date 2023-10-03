using DDD.Domin.Entites;
using DDD.Domin.Entites.Employee;

namespace DDD.Domain.Aggregate
{
    public class EmployeeAggregate
    {
        public Employee Employee { get; private set; }
        public List<Salary> Salaries { get; private set; }
    }
}