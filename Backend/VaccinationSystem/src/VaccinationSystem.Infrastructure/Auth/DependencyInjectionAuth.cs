using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Auth;

namespace VaccinationSystem.Infrastructure.Auth
{
    public static class DependencyInjectionAuth
    {
        public static IServiceCollection AddAuthServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // JWT Config
            JwtConfig config = configuration.GetSection("Jwt").Get<JwtConfig>() ??
                throw new InvalidOperationException("Invalid JWT configuration");

            services.AddSingleton(config);

            // Token generator
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            // JWT Bearer config
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Key)),
                        
                        ValidateIssuer = true,
                        ValidIssuer = config.Issuer,

                        ValidateAudience = true,
                        ValidAudience = config.Audience,

                        ValidateLifetime = true
                    };
                });

            services.AddAuthorization();

            // Password Hasher
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            return services;
        }
    }
}
