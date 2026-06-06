using VaccinationSystem.Domain.Auth;

namespace VaccinationSystem.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
