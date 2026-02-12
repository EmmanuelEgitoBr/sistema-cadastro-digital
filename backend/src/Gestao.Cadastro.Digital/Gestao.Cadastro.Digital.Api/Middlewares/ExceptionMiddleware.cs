using Gestao.Cadastro.Digital.Application.DTOs.ApiResponse;
using Gestao.Cadastro.Digital.Domain.Exceptions;

namespace Gestao.Cadastro.Digital.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                await HandleException(context, ex.Message, StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro interno inesperado");

                await HandleException(
                    context,
                    "Erro interno no servidor",
                    StatusCodes.Status500InternalServerError);
            }
        }

        private static async Task HandleException(
            HttpContext context,
            string message,
            int statusCode)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = ApiResponse<object>.Fail(message);

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
