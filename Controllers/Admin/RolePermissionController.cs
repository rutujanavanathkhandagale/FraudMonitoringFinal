using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;
using Microsoft.AspNetCore.Mvc;

namespace FraudMonitoringSystem.Controllers.Admin
{
    [Route("api/[controller]")]

    [ApiController]

    public class RolePermissionController : ControllerBase

    {

        private readonly IRolePermissionService _service;

        public RolePermissionController(IRolePermissionService service)

        {

            _service = service;

        }

        // POST: api/RolePermission/assign

        [HttpPost("assign")]

        public async Task<IActionResult> AssignPermission([FromBody] AssignPermissionDto dto)

        {

            var result = await _service.AssignPermissionAsync(dto.RoleName, dto.PermissionId);

            return Ok(result);

        }

        // GET: api/RolePermission/{roleName}

        [HttpGet("{roleName}")]

        public async Task<IActionResult> GetRolePermissions(string roleName)

        {

            var result = await _service.GetRolePermissionsAsync(roleName);

            return Ok(result);

        }

    }

}