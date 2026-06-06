using MediatR;
using VaccinationSystem.Application.Common.Interfaces;

namespace VaccinationSystem.Application.Vaccines.DeleteVaccine
{
    public class DeleteVaccineCommandHandler(
        IVaccineRepository vaccineRepository,
        IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteVaccineCommand>
    {
        private readonly IVaccineRepository _vaccineRepository = vaccineRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteVaccineCommand command, CancellationToken cancellationToken)
        {
            await _vaccineRepository.DeleteByIdAsync(command.VaccineId, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
