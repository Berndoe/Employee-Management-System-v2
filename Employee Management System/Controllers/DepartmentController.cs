using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpPost]
        public ActionResult<Department> Create([FromBody] Department department)
        {
            var existingDepartment = departmentService.Get(department.departmentId);

            if (existingDepartment != null)
                return BadRequest($"The department with ID {department.departmentId} already exists");

            departmentService.Create(department);
            return department;
             
        }

        [HttpGet("{departmentId}")]
        public ActionResult<Department> Get(int departmentId)
        {
            var department = departmentService.Get(departmentId);

            if (department == null)
                return NotFound($"Department with ID {departmentId} not found");
            return department;
        }

        [HttpGet]
        public ActionResult<List<Department>> Get()
        {
            return departmentService.Get();
        }

        [HttpPut("{departmentId}")]
        public ActionResult Put(int departmentId, [FromBody] Department department)
        {
            var existingDepartment = departmentService.Get(departmentId);

            if (existingDepartment == null)
                return NotFound($"Department with ID {departmentId} not found");

            departmentService.Update(departmentId, department);
            return Ok($"Department with ID {departmentId} has been updated");

        }

        [HttpDelete("{departmentId}")]
        public ActionResult Delete(int departmentId)
        {
            var department = departmentService.Get(departmentId);

            if (department == null)
                return NotFound($"Department with ID {departmentId} not found");

            departmentService.Remove(department.departmentId);
            return Ok($"Department with ID {departmentId} has been deleted");
        }

    }

}
