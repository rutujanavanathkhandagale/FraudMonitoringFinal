using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;
using Microsoft.AspNetCore.Mvc;

namespace FraudMonitoringSystem.Controllers.Admin
{
    [Route("api/[controller]")]

    [ApiController]

    public class UserController : ControllerBase

    {

        private readonly IUserService _service;

        public UserController(IUserService service)

        {

            _service = service;

        }

        [HttpGet]

        public async Task<IActionResult> GetAll()

        {

            return Ok(await _service.GetAllAsync());

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)

        {

            return Ok(await _service.GetByIdAsync(id));

        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateUserDto dto)

        {

            var result = await _service.CreateUserAsync(dto);

            return Ok(result);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)

        {

            var result = await _service.DeleteUserAsync(id);

            return Ok(result);

        }

    }

}