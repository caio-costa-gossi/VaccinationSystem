using MediatR;

namespace VaccinationSystem.Application.Persons.CreatePerson
{
    public record CreatePersonCommand(string Name) : IRequest<Guid>;
}
