using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Application.Common.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task AddAsync(Person person, CancellationToken cancellationToken);

        Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
