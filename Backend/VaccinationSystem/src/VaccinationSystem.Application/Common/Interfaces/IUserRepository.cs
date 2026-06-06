using VaccinationSystem.Domain.Auth;

namespace VaccinationSystem.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);

        Task AddAsync(User user, CancellationToken cancellationToken);
    }
}
