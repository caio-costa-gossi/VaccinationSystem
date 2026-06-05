using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Infrastructure.Persistence.Repositories
{
    internal class PersonRepository(AppDbContext appDbContext) : IPersonRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        
        public async Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Persons
                .Where(e => e.Id == id)
                .Include(e => e.Vaccinations)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task AddAsync(Person person, CancellationToken cancellationToken)
        {
            await _appDbContext.AddAsync(person, cancellationToken);
        }

        public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            Person? e = await _appDbContext.Persons
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (e == null)
                return;

            _appDbContext.Remove(e);
        }
    }
}
