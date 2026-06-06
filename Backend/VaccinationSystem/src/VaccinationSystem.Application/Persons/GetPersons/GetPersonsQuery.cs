using MediatR;

namespace VaccinationSystem.Application.Persons.GetPersons
{
    public record GetPersonsQuery() : IRequest<List<GetPersonsItemDto>>;
}
