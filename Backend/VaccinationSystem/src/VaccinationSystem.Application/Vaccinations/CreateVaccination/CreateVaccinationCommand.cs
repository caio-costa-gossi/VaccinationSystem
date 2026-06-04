using MediatR;

namespace VaccinationSystem.Application.Vaccinations.CreateVaccination
{
    public record CreateVaccinationCommand(Guid PersonId, Guid VaccineId, int DoseNumber) : IRequest<Guid>;
}
