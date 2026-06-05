using MediatR;
using VaccinationSystem.Application.Common.Interfaces;

namespace VaccinationSystem.Application.Vaccinations.DeleteVaccination
{
    public class DeleteVaccinationCommandHandler(
        IPersonRepository personRepository) 
        : IRequestHandler<DeleteVaccinationCommand>
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task Handle(DeleteVaccinationCommand request, CancellationToken cancellationToken)
        {
            return;
        }
    }
}
