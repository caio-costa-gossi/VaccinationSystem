using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Infrastructure.Auth;
using VaccinationSystem.Infrastructure.Persistence;
using VaccinationSystem.Infrastructure.Persistence.Repositories;

namespace VaccinationSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(
                    configuration.GetConnectionString("DefaultConnection")));

            // Unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // JWT Services
            services.AddSingleton<JwtConfig>(
                configuration.GetSection("Jwt").Get<JwtConfig>() ?? 
                throw new InvalidOperationException("Invalid JWT configuration"));

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            // Repositories
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IVaccineRepository, VaccineRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            return services;
        }
    }
}
