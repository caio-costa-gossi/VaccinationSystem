using MediatR;
using VaccinationSystem.Application.Common.Interfaces;

namespace VaccinationSystem.Application.Persons.CreatePerson
{
    public class CreatePersonCommandHandler(
        IPersonRepository personRepository) 
        : IRequestHandler<CreatePersonCommand,Guid>
    {
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            return Guid.NewGuid();
        }
    }
}
