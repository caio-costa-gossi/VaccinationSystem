using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Infrastructure.Persistence.Repositories
{
    internal class VaccineRepository : IVaccineRepository
    {
        public async Task<List<Vaccine>> GetAllAsync(CancellationToken cancellationToken)
        {
            return [];
        }

        public async Task AddAsync(Vaccine vaccine)
        {

        }
    }
}
