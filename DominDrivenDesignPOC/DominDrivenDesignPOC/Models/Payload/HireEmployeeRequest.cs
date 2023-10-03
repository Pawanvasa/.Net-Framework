namespace DDD.Application.Models.Payload
{
    public class HireEmployeeRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int DepartmentId { get; set; }
    }
}
