using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaccinationSystem.Application.Persons.GetPerson
{
    public record GetPersonQuery(Guid Id) : IRequest<GetPersonDto>;
}
