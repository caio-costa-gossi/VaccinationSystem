using MediatR;

namespace VaccinationSystem.Application.Vaccinations.DeleteVaccination
{
    public record DeleteVaccinationCommand(Guid Id) : IRequest;
}
