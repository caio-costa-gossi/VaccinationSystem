using MediatR;

namespace VaccinationSystem.Application.Persons.GetPerson
{
    public record GetPersonQuery(Guid Id) : IRequest<GetPersonDto>;
}
