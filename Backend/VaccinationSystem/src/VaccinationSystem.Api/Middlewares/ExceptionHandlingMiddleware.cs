using FluentValidation;

namespace VaccinationSystem.Api.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                if (context.Response.HasStarted)
                    throw;

                // Status 400 e descrição dos erros de validação
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                
                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        Errors = ex.Errors.Select(e => new
                        {
                            e.PropertyName,
                            e.ErrorMessage,
                            e.Severity
                        })
                    });
            }
            catch (Exception ex)
            {
                if (context.Response.HasStarted)
                    throw;

                // Status 500 e mensagem de erro
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                
                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        Error = ex.Message
                    });
            }
        }
    }
}
