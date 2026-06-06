using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Auth;

namespace VaccinationSystem.Infrastructure.Auth
{
    public class JwtTokenGenerator(JwtConfig config) : IJwtTokenGenerator
    {
        private readonly JwtConfig _config = config;

        public string GenerateToken(User user)
        {
            return _config.Key;
        }
    }
}
