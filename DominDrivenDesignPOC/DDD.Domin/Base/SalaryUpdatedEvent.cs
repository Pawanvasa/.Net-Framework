namespace DDD.Domin.Base
{
    public class SalaryUpdatedEvent
    {
        public int EmployeeId { get; private set; }
        public decimal NewSalary { get; private set; }
    }
}