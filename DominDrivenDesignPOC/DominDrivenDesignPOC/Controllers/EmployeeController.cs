 using DDD.Application.Models.Payload;
using DDD.Domin.Entites.Employee;
using DDD.Infrastucture.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DominDrivenDesignPOC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAppService _employeeAppService;

        public EmployeeController(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        [HttpPost]
        [Route("/HireEmployee")]
        public IActionResult HireEmployee([FromBody] HireEmployeeRequest request)
        {
            var employee = new Employee()
            {
                FirstName = request.FirstName!,
                LastName = request.LastName!,
                DepartmentId = request.DepartmentId,
            };
            _employeeAppService.HireEmployee(employee);
            return Ok("Employee hired successfully.");
        }

        [HttpPost]
        [Route("/UpdateSalary")]
        public IActionResult UpdateSalary(int employeeId, [FromBody] UpdateSalaryRequest request)
        {
            _employeeAppService.UpdateSalary(employeeId, request.Amount);
            return Ok("Salary updated successfully.");
        }
    }
}
