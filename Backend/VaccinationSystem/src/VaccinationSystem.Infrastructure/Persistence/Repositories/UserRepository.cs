using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Auth;

namespace VaccinationSystem.Infrastructure.Persistence.Repositories
{
    public class UserRepository(AppDbContext appDbContext) : IUserRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        
        public async Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _appDbContext.Users
                .Where(e => e.Name == name)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _appDbContext.AddAsync(user, cancellationToken);
        }

        public async Task<bool> UserNameExistsAsync(string name, CancellationToken cancellationToken)
        {
            return await _appDbContext.Users
                .Where(e => e.Name == name)
                .AnyAsync(cancellationToken);
        }
    }
}
