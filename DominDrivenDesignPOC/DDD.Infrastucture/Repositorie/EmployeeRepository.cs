using DDD.Domin.Entites.Employee;

namespace DDD.Infrastucture.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public string HireEmployee(Employee employee)
        {
            if (employee == null) { return "Employee Hired"; }
            return "Invalid Employee";
        }
        public void Update(int employeeId, decimal amount)
        {
            var employee = GetById(employeeId);
            if (employee != null)
            {
                Console.WriteLine("Employee salary Updated");
            }
            else
            {
                Console.WriteLine("Employee Not Found");
            }
        }
        public Employee GetById(int id)
        {
            return new Employee() { FirstName = "pavan", LastName = "vasa", DepartmentId = 10, Id = 1 };
        }
    }
}
