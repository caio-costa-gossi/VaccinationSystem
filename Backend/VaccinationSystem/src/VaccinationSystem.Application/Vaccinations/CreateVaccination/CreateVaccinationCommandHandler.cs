using MediatR;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Aggregates;
using VaccinationSystem.Domain.Entities;

namespace VaccinationSystem.Application.Vaccinations.CreateVaccination
{
    public class CreateVaccinationCommandHandler(
        IPersonRepository personRepository,
        IUnitOfWork unitOfWork) 
        : IRequestHandler<CreateVaccinationCommand, Guid>
    {
        private readonly IPersonRepository _personRepository = personRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateVaccinationCommand request, CancellationToken cancellationToken)
        {
            Person? person = await _personRepository.GetByIdAsync(request.PersonId, cancellationToken);
            
            if (person == null)
                return Guid.Empty;

            Vaccination? newVaccination = person.AddVaccination(request.VaccineId, request.DoseNumber);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newVaccination != null ? newVaccination.Id : Guid.Empty;
        }
    }
}
