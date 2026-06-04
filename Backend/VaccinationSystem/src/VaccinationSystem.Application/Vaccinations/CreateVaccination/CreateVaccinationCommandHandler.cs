using MediatR;

namespace VaccinationSystem.Application.Vaccinations.CreateVaccination
{
    public class CreateVaccinationCommandHandler : IRequestHandler<CreateVaccinationCommand, Guid>
    {
        public CreateVaccinationCommandHandler() { }

        public async Task<Guid> Handle(CreateVaccinationCommand request, CancellationToken cancellationToken)
        {
            return Guid.NewGuid();
        }
    }
}
