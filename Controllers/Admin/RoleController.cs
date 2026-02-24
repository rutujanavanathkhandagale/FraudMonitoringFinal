using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;
using Microsoft.AspNetCore.Mvc;
using FraudMonitoringSystem.Exceptions.Admin;

namespace FraudMonitoringSystem.Controllers.Admin
{
    [ApiController]

    [Route("api/role")]

    public class RoleController : ControllerBase

    {

        private readonly IRoleService _service;

        public RoleController(IRoleService service)

        {

            _service = service;

        }

        [HttpGet]

        public async Task<IActionResult> GetAll()

        {

            return Ok(await _service.GetAllRolesAsync());

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)

        {

            var result = await _service.GetRoleByIdAsync(id);

            if (result == null)

                return NotFound("Role not found");

            return Ok(result);

        }


        [HttpPost]

        public async Task<IActionResult> Create(CreateRoleDto dto)

        {


            try
            {
                var result = await _service.CreateRoleAsync(dto);
                return Ok(result);
            }
            catch (Exceptions.RoleAlreadyExistsException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
        }


        [HttpDelete("delete-by-name/{roleName}")]

        public async Task<IActionResult> DeleteByName(string roleName)

        {

            try
            {
                var result = await _service.DeleteRoleByNameAsync(roleName);
                return Ok(result);
            }
            catch (RoleNotFoundException ex)
            {
                return NotFound(ex.Message);   // 🔥 THIS RETURNS 404
            }


        }



    }

}