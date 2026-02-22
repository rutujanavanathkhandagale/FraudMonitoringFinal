using FraudMonitoringSystem.Exceptions.Customer;
using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Services.Customer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FraudMonitoringSystem.Controllers.Customer
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _service;

        public ChatController(IChatService service)
        {
            _service = service;
        }

        [HttpGet("{customerId}/{receiverRole}")]
        public async Task<IActionResult> GetConversation(long customerId, string receiverRole)
        {
            try
            {
                var messages = await _service.GetConversationAsync(customerId, receiverRole);
                return Ok(messages);
            }
            catch (ChatNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessage message)
        {
            try
            {
                var result = await _service.SendMessageAsync(message);
                return Ok(new { message = result });
            }
            catch (ChatValidationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}

