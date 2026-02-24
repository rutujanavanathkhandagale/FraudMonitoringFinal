using FraudMonitoringSystem.Exceptions.Admin;
using FraudMonitoringSystem.Exceptions.Customer;
using System.Net;
using System.Text.Json;

namespace FraudMonitoringSystem.Aspects.Admin
{
    public class GlobalException

    {

        private readonly RequestDelegate _next;

        public GlobalException(RequestDelegate next)

        {

            _next = next;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex switch
                {
                    Exceptions.Admin.UserAlreadyExistsException => (int)HttpStatusCode.BadRequest,
                    Exceptions.Admin.UserNotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError
                };
                var response = new
                {
                    statusCode = context.Response.StatusCode,
                    message = ex.Message
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)

        {

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            string message = ex.Message;

            switch (ex)

            {

                case PermissionNotFoundException:

                case RoleNotFoundException:

                    statusCode = HttpStatusCode.NotFound;

                    break;

                case RoleAlreadyExistsException:

                    statusCode = HttpStatusCode.Conflict;

                    break;

                case ArgumentException:

                    statusCode = HttpStatusCode.BadRequest;

                    break;

            }

            var response = new

            {

                status = (int)statusCode,

                error = message

            };

            var jsonResponse = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(jsonResponse);

        }

    }

}