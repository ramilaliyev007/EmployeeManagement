using EmployeeManagement.Domain.Common.Exceptions;
using EmployeeManagement.WebAPI.Dtos;
using System.Net;

namespace EmployeeManagement.WebAPI.Infrastructure.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                LogException(ex);

                var statusCode = GetHttpStatusCode(ex);

                var response = GetResponse(ex);

                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(response);
            }
        }

        private string GetResponse(Exception exception)
        {
            var message = GetResponseMessage(exception);

            return new ErrorResponse
            {
                Message = message
            }.ToString();
        }

        private string GetResponseMessage(Exception exception)
        {
            return exception switch
            {
                UserFriendlyException userFriendlyException => userFriendlyException.Message,

                _ => "Unhandled error occured. See logs for more information",
            };
        }

        private HttpStatusCode GetHttpStatusCode(Exception exception)
        {
            return exception switch
            {
                DataNotFoundByIdException => HttpStatusCode.NotFound,

                InvalidForeignKeyException => HttpStatusCode.BadRequest,

                _ => HttpStatusCode.InternalServerError
            };
        }

        private void LogException(Exception exception)
        {
            _logger.LogError(exception, "{Method}: Error occured", nameof(LogException));
        }
    }

    public static class ExceptionHandlingMiddlewareRegistrar
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
