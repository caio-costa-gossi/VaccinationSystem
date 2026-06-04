using MediatR;

namespace VaccinationSystem.Application.Vaccines.CreateVaccine
{
    public record CreateVaccineCommand(string Name) : IRequest<Guid>;
}
