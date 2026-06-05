using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Application.Common.Interfaces
{
    public interface IVaccineRepository
    {
        Task<List<Vaccine>> GetAllAsync(CancellationToken cancellationToken);

        Task AddAsync(Vaccine vaccine, CancellationToken cancellationToken);
    }
}
