using DDD.Domin.Entites.Employee;

namespace DDD.Infrastucture.Repositories
{
    public interface IEmployeeAppService
    {
        void HireEmployee(Employee employee);
        void UpdateSalary(int employeeId, decimal amount);
    }
}