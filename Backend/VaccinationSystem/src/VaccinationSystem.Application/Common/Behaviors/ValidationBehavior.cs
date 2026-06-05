using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace VaccinationSystem.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> (IEnumerable<IValidator<TRequest>> validators) :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next(cancellationToken);

            // Montar o context que será testado
            ValidationContext<TRequest> context = new(request);

            // Rodar validators contra o context e achatar a lista de erros
            ValidationResult[] results = 
                await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            List<ValidationFailure> failures = results
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            // Verificar erros
            if (failures.Count != 0)
                throw new ValidationException(failures);
            
            return await next(cancellationToken);
        }
    }
}
