using MediatR;
using VaccinationSystem.Application.Common.Interfaces;

namespace VaccinationSystem.Application.Vaccines.GetVaccines
{
    public class GetVaccinesQueryHandler(
        IVaccineRepository vaccineRepository) 
        : IRequestHandler<GetVaccinesQuery, List<GetVaccinesItemDto>>
    {
        private readonly IVaccineRepository _vaccineRepository = vaccineRepository;

        public async Task<List<GetVaccinesItemDto>> Handle(GetVaccinesQuery request, CancellationToken cancellationToken)
        {
            return [new GetVaccinesItemDto(Guid.NewGuid(), "Vaccine name")];
        }
    }
}
