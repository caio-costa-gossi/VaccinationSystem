using MediatR;

namespace VaccinationSystem.Application.Vaccines.CreateVaccine
{
    public class CreateVaccineCommandHandler : IRequestHandler<CreateVaccineCommand,Guid>
    {
        public CreateVaccineCommandHandler() { }

        public async Task<Guid> Handle(CreateVaccineCommand request, CancellationToken cancellationToken)
        {
            return Guid.NewGuid();
        }
    }
}
