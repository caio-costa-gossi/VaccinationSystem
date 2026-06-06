using MediatR;

namespace VaccinationSystem.Application.Vaccines.DeleteVaccine
{
    public record DeleteVaccineCommand(Guid VaccineId) : IRequest;
}
