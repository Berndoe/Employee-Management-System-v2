using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpPost]
        public ActionResult<Role> Create([FromBody] Role role)
        {
            var existingRole = roleService.Get(role.roleId);

            if (existingRole != null)
                return BadRequest($"The role with ID {role.roleId} already exists");

            roleService.Create(role);
            return role;
             
        }

        [HttpGet("{roleId}")]
        public ActionResult<Role> Get(string roleId)
        {
            var role = roleService.Get(roleId);

            if (role == null)
                return NotFound($"Role with ID {roleId} not found");
            return role;
        }

        [HttpGet]
        public ActionResult<List<Role>> Get()
        {
            return roleService.Get();
        }

        [HttpPut("{roleId}")]
        public ActionResult Put(string roleId, [FromBody] Role role)
        {
            var existingrole = roleService.Get(roleId);

            if (existingrole == null)
                return NotFound($"Role with ID {roleId} not found");

            roleService.Update(roleId, role);
            return Ok($"Role with ID {roleId} has been updated");

        }

        [HttpDelete("{roleId}")]
        public ActionResult Delete(string roleId)
        {
            var role = roleService.Get(roleId);

            if (role == null)
                return NotFound($"Role with ID {roleId} not found");

            roleService.Remove(role.roleId);
            return Ok($"Role with ID {roleId} has been deleted");
        }

    }

}
