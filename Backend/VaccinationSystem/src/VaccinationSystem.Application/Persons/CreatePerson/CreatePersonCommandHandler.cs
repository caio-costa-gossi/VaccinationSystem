using MediatR;

namespace VaccinationSystem.Application.Persons.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand,Guid>
    {
        public CreatePersonCommandHandler() { }

        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            return Guid.NewGuid();
        }
    }
}
