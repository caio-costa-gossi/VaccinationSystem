using FluentValidation;

namespace VaccinationSystem.Application.Persons.DeletePerson
{
    public class DeletePersonValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
