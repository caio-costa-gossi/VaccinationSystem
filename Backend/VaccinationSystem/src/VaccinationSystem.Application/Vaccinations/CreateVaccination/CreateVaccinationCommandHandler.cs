using MediatR;
using VaccinationSystem.Application.Common.Interfaces;

namespace VaccinationSystem.Application.Vaccinations.CreateVaccination
{
    public class CreateVaccinationCommandHandler(
        IPersonRepository personRepository) 
        : IRequestHandler<CreateVaccinationCommand, Guid>
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<Guid> Handle(CreateVaccinationCommand request, CancellationToken cancellationToken)
        {
            return Guid.NewGuid();
        }
    }
}
