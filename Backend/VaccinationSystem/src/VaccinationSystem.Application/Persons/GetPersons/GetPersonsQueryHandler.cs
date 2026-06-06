using MediatR;
using VaccinationSystem.Application.Common.Interfaces;

namespace VaccinationSystem.Application.Persons.GetPersons
{
    public class GetPersonsQueryHandler(
        IPersonRepository personRepository) 
        : IRequestHandler<GetPersonsQuery, List<GetPersonsItemDto>>
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<List<GetPersonsItemDto>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            List<GetPersonsItemDto> persons = 
                (await _personRepository.GetAllAsync(cancellationToken))
                .Select(e => new GetPersonsItemDto(e.Id, e.Name))
                .ToList();

            return persons;
        }
    }
}
