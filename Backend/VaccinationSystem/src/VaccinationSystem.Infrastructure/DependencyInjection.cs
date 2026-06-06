using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VaccinationSystem.Application.Common.Interfaces;
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IVaccineRepository, VaccineRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            return services;
        }
    }
}
