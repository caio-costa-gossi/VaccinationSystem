using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Infrastructure.Persistence.Repositories
{
    internal class VaccineRepository(AppDbContext appDbContext) : IVaccineRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        
        public async Task<Vaccine?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Vaccines
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }
        
        public async Task<List<Vaccine>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Vaccines
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Vaccine vaccine, CancellationToken cancellationToken)
        {
            await _appDbContext.AddAsync(vaccine, cancellationToken);
        }
    }
}
