using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VaccinationSystem.Application.Common.Behaviors;

namespace VaccinationSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            // FluentValidation
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            // Pipeline behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
