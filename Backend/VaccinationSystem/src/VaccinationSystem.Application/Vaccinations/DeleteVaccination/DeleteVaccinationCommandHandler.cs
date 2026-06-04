using MediatR;

namespace VaccinationSystem.Application.Vaccinations.DeleteVaccination
{
    public class DeleteVaccinationCommandHandler : IRequestHandler<DeleteVaccinationCommand>
    {
        public DeleteVaccinationCommandHandler() { }

        public async Task Handle(DeleteVaccinationCommand request, CancellationToken cancellationToken)
        {
            return;
        }
    }
}
