namespace DDD.Domin.Base
{
    // Domain Events
    public class EmployeeHiredEvent
    {
        public int EmployeeId { get; private set; }
        public string? FullName { get; private set; }
        public int DepartmentId { get; private set; }
    }
}