using FluentValidation;
using FluentValidation.Results;

namespace VaccinationSystem.Application.Persons.CreatePerson
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
