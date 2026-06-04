using MediatR;

namespace VaccinationSystem.Application.Vaccines.GetVaccines
{
    public record GetVaccinesQuery() : IRequest<List<GetVaccinesItemDto>>;
}
