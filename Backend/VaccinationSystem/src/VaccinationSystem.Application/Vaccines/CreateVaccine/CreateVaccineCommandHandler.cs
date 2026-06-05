using MediatR;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Aggregates;

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
            Vaccine newVaccine = new(request.Name);

            await _vaccineRepository.AddAsync(newVaccine, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return newVaccine.Id;
        }
    }
}
