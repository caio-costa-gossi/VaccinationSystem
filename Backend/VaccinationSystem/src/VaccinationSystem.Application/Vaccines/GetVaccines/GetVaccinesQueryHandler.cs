using MediatR;

namespace VaccinationSystem.Application.Vaccines.GetVaccines
{
    public class GetVaccinesQueryHandler : IRequestHandler<GetVaccinesQuery, List<GetVaccinesItemDto>>
    {
        public GetVaccinesQueryHandler() { }

        public async Task<List<GetVaccinesItemDto>> Handle(GetVaccinesQuery request, CancellationToken cancellationToken)
        {
            return [new GetVaccinesItemDto(Guid.NewGuid(), "Vaccine name")];
        }
    }
}
