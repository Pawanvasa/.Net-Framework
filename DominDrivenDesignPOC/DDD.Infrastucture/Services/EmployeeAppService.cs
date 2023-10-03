using DDD.Domin.Entites.Employee;

namespace DDD.Infrastucture.Repositories
{

    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeAppService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void HireEmployee(Employee employee)
        {
            var response = _employeeRepository.HireEmployee(employee);
        }

        public void UpdateSalary(int employeeId, decimal amount)
        {
            _employeeRepository.Update(employeeId, amount);
        }
    }
}