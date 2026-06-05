using MediatR;
using VaccinationSystem.Application.Common.Exceptions;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Application.Vaccinations.DeleteVaccination
{
    public class DeleteVaccinationCommandHandler(
        IPersonRepository personRepository,
        IUnitOfWork unitOfWork) 
        : IRequestHandler<DeleteVaccinationCommand>
    {
        private readonly IPersonRepository _personRepository = personRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteVaccinationCommand request, CancellationToken cancellationToken)
        {
            Person? person = await _personRepository.GetByIdAsync(request.PersonId, cancellationToken);

            if (person == null)
                throw new NotFoundException($"Person with ID {request.PersonId} does not exist.");

            person.RemoveVaccination(request.VaccinationId);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
