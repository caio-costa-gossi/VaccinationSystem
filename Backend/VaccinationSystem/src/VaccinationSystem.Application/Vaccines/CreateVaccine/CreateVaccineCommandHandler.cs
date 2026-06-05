using MediatR;
using VaccinationSystem.Application.Common.Interfaces;

namespace VaccinationSystem.Application.Vaccines.CreateVaccine
{
    public class CreateVaccineCommandHandler(
        IVaccineRepository vaccineRepository,
        IUnitOfWork unitOfWork) 
        : IRequestHandler<CreateVaccineCommand,Guid>
    {
        private readonly IVaccineRepository _vaccineRepository = vaccineRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateVaccineCommand request, CancellationToken cancellationToken)
        {
            return Guid.NewGuid();
        }
    }
}
