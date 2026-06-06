using Microsoft.OpenApi;

namespace VaccinationSystem.Api.Swagger
{
    public static class DependencyInjectionSwaggerGen
    {
        public static IServiceCollection AddSwaggerGenWithAuth(
            this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para sistema de vacinação",
                    Description = "API para gerenciar carteiras de vacinação feita em ASP.NET Core 10"
                });

                options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Insira seu token JWT"
                });

                options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference("bearer", document)] = []
                });
            });

            return services;
        }
    }
}
