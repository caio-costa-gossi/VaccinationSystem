using MediatR;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Application.Persons.CreatePerson
{
    public class CreatePersonCommandHandler(
        IPersonRepository personRepository,
        IUnitOfWork unitOfWork) 
        : IRequestHandler<CreatePersonCommand,Guid>
    {
        private readonly IPersonRepository _personRepository = personRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            Person newPerson = new(request.Name);
            
            await _personRepository.AddAsync(newPerson, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return newPerson.Id;
        }
    }
}
