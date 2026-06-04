using MediatR;

namespace VaccinationSystem.Application.Persons.DeletePerson
{
    public record DeletePersonCommand(Guid Id) : IRequest;
}
