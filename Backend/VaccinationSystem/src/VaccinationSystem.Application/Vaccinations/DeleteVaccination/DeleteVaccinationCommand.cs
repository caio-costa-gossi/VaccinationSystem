using MediatR;

namespace VaccinationSystem.Application.Vaccinations.DeleteVaccination
{
    public record DeleteVaccinationCommand(Guid PersonId, Guid VaccinationId) : IRequest;
}
