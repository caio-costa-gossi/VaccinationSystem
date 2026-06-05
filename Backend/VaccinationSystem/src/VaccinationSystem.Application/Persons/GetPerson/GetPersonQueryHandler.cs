using MediatR;
using VaccinationSystem.Application.Common.Interfaces;

namespace VaccinationSystem.Application.Persons.GetPerson
{
    public class GetPersonQueryHandler(
        IPersonRepository personRepository) 
        : IRequestHandler<GetPersonQuery,GetPersonDto>
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<GetPersonDto> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            return new GetPersonDto(
                Guid.NewGuid(), 
                "Mock", 
                [new VaccinationDto(Guid.NewGuid(), Guid.NewGuid(), 1, DateTime.Now)]
            );
        }
    }
}
