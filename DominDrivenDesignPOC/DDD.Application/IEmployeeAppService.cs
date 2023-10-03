namespace DDD.Application
{
    public interface IEmployeeAppService
    {
        void HireEmployee(string firstName, string lastName, int departmentId);
        void UpdateSalary(int employeeId, decimal amount);
    }
}