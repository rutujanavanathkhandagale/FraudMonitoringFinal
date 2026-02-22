using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Services.Customer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FraudMonitoringSystem.Models;
using FraudMonitoringSystem.Services.Customer.Interfaces;
namespace FraudMonitoringSystem.Controllers.Customer
{
  

    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _service;

        public RegistrationController(IRegistrationService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Registration reg)
        {
            var result = await _service.RegisterUserAsync(reg);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpGet("ByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _service.GetUserByEmailAsync(email);
            return Ok(user);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Registration reg)
        {
            if (id != reg.CustomerId)
                return BadRequest("ID in URL and body must match");

            var result = await _service.UpdateUserAsync(reg);
            return Ok(result);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _service.DeleteUserAsync(id);
            return Ok(result);
        }
    }
}
