using DDD.Domin.Entites.Employee;

namespace DDD.Infrastucture
{
    public partial interface IEmployeeRepository
    {
        string HireEmployee(Employee employee);
        Employee GetById(int id);
        void Update(int employeeId, decimal amount);
    }
}
