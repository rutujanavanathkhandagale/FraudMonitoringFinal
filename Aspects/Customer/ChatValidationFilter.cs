using FraudMonitoringSystem.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FraudMonitoringSystem.Aspects.Customer
{
    public class ChatValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("message", out var value) && value is ChatMessage msg)
            {
                if (string.IsNullOrWhiteSpace(msg.Message))
                {
                    context.Result = new BadRequestObjectResult("Message cannot be empty");
                }
                else if (string.IsNullOrWhiteSpace(msg.ReceiverRole))
                {
                    context.Result = new BadRequestObjectResult("ReceiverRole must be specified");
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
