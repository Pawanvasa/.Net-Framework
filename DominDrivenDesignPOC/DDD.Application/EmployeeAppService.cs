using DDD.Domin.Base;
using DDD.Domin.Entites.Employee;

namespace DDD.Application
{

    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeAppService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void HireEmployee(string firstName, string lastName, int departmentId)
        {
            _employeeService.HireEmployee(firstName, lastName, departmentId);
        }

        public void UpdateSalary(int employeeId, decimal amount)
        {
            _employeeService.UpdateSalary(employeeId, amount);
        }
    }
}