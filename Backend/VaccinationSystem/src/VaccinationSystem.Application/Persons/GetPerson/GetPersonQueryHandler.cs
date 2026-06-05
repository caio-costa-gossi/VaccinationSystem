using MediatR;
using VaccinationSystem.Application.Common.Exceptions;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Application.Persons.GetPerson
{
    public class GetPersonQueryHandler(
        IPersonRepository personRepository) 
        : IRequestHandler<GetPersonQuery,GetPersonDto?>
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<GetPersonDto?> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            Person? person = await _personRepository.GetByIdAsync(request.Id, cancellationToken);

            if (person == null)
                throw new NotFoundException($"Person with ID {request.Id} does not exist.");

            return new GetPersonDto(
                    person.Id,
                    person.Name,
                    person.Vaccinations
                        .Select(v => new GetVaccinationDto(v.Id, v.VaccineId, v.DoseNumber, v.AppliedAt)).ToList()
                );
        }
    }
}
