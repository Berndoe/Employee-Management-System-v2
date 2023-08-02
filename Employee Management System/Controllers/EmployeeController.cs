using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        private bool verifyDepartmentRole()
        {
            return true;

        }
        [HttpPost]
        public ActionResult<Employee> Create([FromBody] Employee employee)
        {
            var existingEmployee = employeeService.Get(employee.employeeId);

            if (existingEmployee != null)
                return BadRequest($"The employee with ID {employee.employeeId} already exists");

            employeeService.Create(employee);
            return employee;
             
        }

        [HttpGet("{employeeId}")]
        public ActionResult<Employee> Get(int employeeId)
        {
            var employee = employeeService.Get(employeeId);

            if (employee == null)
                return NotFound($"Employee with ID {employeeId} not found");
            return employee;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return employeeService.Get();
        }

        [HttpPut("{employeeId}")]
        public ActionResult Put(int employeeId, [FromBody] Employee employee)
        {
            var existingEmployee = employeeService.Get(employeeId);

            if (existingEmployee == null)
                return NotFound($"Employee with ID {employeeId} not found");

            employeeService.Update(employeeId, employee);
            return Ok(employee);

        }

        [HttpDelete("{employeeId}")]
        public ActionResult Delete(int employeeId)
        {
            var employee = employeeService.Get(employeeId);

            if (employee == null)
                return NotFound($"Employee with ID {employeeId} not found");

            employeeService.Remove(employee.employeeId);
            return Ok($"Employee with ID {employeeId} has been deleted");
        }

    }

}
