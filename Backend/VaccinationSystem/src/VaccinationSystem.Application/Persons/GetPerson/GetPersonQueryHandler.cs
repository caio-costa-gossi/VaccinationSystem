using MediatR;

namespace VaccinationSystem.Application.Persons.GetPerson
{
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery,GetPersonDto>
    {
        public GetPersonQueryHandler() { }

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
