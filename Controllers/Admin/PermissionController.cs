using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Exceptions.Admin;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;
using Microsoft.AspNetCore.Mvc;

namespace FraudMonitoringSystem.Controllers.Admin
{
    [ApiController]
    [Route("api/permissions")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _service;
        public PermissionController(IPermissionService service)
        {
            _service = service;
        }
        // GET: api/permissions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var permissions = await _service.GetAllPermissionsAsync();
            return Ok(permissions);
        }
        // GET: api/permissions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var permission = await _service.GetPermissionByIdAsync(id);
            return Ok(permission);
        }
        // POST: api/permissions
        [HttpPost]
        public async Task<IActionResult> Create(CreatePermissionDto dto)
        {
            var result = await _service.CreatePermissionAsync(dto);
            return Ok(result);
        }
        // DELETE: api/permissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.DeletePermissionAsync(id);
                return Ok(result);
            }
            catch (PermissionNotFoundException ex)
            {
                return NotFound(ex.Message);   // 404
            }
        }
    }
}
