using FluentValidation;
using VaccinationSystem.Application.Common.Exceptions;
using VaccinationSystem.Domain.Common.Exceptions;

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
                        ErrorCode = 6,
                        Errors = ex.Errors.Select(e => new
                        {
                            e.PropertyName,
                            e.ErrorMessage,
                            e.Severity
                        })
                    });
            }
            catch (BusinessRuleViolationException ex)
            {
                if (context.Response.HasStarted)
                    throw;

                // Status 400 e mensagem de erro
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        ErrorCode = 5,
                        Message = ex.Message
                    });
            }
            catch (NotFoundException ex)
            {
                if (context.Response.HasStarted)
                    throw;

                // Status 400 e mensagem de erro
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        ErrorCode = 4,
                        Message = ex.Message
                    });
            }
            catch (ConflictException ex)
            {
                if (context.Response.HasStarted)
                    throw;

                // Status 409 e mensagem de erro
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status409Conflict;

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        ErrorCode = 409,
                        Message = ex.Message
                    });
            }
            catch (UnauthorizedException ex)
            {
                if (context.Response.HasStarted)
                    throw;

                // Status 403 e mensagem de erro
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status403Forbidden;

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        ErrorCode = 403,
                        Message = ex.Message
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
                        ErrorCode = 500,
                        Message = ex.Message
                    });
            }
        }
    }
}
