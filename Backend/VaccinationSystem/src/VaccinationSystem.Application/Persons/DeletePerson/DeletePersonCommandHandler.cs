using MediatR;
using VaccinationSystem.Application.Common.Interfaces;

namespace VaccinationSystem.Application.Persons.DeletePerson
{
    public class DeletePersonCommandHandler(
        IPersonRepository personRepository) 
        : IRequestHandler<DeletePersonCommand>
    {
        private readonly IPersonRepository _personRepository = personRepository;
        
        public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return;
        }
    }
}
