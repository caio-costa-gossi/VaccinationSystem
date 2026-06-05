using FluentValidation;

namespace VaccinationSystem.Application.Persons.GetPerson
{
    public class GetPersonValidator : AbstractValidator<GetPersonQuery>
    {
        public GetPersonValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
