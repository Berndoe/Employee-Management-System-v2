using System.Security.Claims;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using SharpCompress.Common;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly IAdminUsersService adminService;

        public AdminController(IAdminUsersService adminService)
        {
            this.adminService = adminService;
        }

        public static AdminUsers user = new AdminUsers();

        [HttpPost("register")]
        public async Task<ActionResult<AdminUsers>> Create([FromBody] AdminUsers user)
        { 
            adminService.Create(user);
            return user;             
        }

        private bool verifyPassword(AdminUsers user, string password)
        {
            var existingUser = adminService.Get(user.userId);

            if (existingUser == null)
                return false;
            
            string combinedPassword = password + existingUser.passwordSalt;

            string hashedInput = BCrypt.Net.BCrypt.HashPassword(combinedPassword, existingUser.passwordSalt);

            return hashedInput == user.password;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(AdminUsers user)
        {
            var userEmail = adminService.Get(user.userId).email;
            var userPassword = adminService.Get(user.userId).password;

            if (userEmail == null || !verifyPassword(user, userPassword))
                return BadRequest("Incorrect email or password");

            string token = CreateToken(user);
            return Ok(token);

        }

        private string CreateToken(AdminUsers user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes())
            return string.Empty;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<AdminUsers>> Get(string userId)
        {
            var user = adminService.Get(userId);

            if (user == null)
                return NotFound($"Admin with ID {userId} not found");
            return user;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdminUsers>>> Get() => adminService.Get();

        [HttpPut("{userId}")]
        public async Task<ActionResult> Put(string userId, [FromBody] AdminUsers user)
        {
            var existingAdmin = adminService.Get(userId);

            if (existingAdmin == null)
                return NotFound($"Admin with ID {userId} not found");

            adminService.Update(userId, user);
            return Ok($"Admin with ID {userId} has been updated");
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> Delete(string userId)
        {
            var user = adminService.Get(userId);

            if (user == null)
                return NotFound($"Admin with ID {userId} not found");

            adminService.Remove(user.userId);
            return Ok($"Admin with ID {userId} has been deleted");
        }
    }
}
