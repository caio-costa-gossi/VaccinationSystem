using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Infrastructure.Persistence.Repositories
{
    internal class PersonRepository(AppDbContext appDbContext) : IPersonRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        
        public async Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return null;
        }

        public async Task AddAsync(Person person, CancellationToken cancellationToken)
        {

        }

        public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        {

        }
    }
}
