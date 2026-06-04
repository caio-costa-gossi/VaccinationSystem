using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaccinationSystem.Application.Persons.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        public DeletePersonCommandHandler() { }

        public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return;
        }
    }
}
