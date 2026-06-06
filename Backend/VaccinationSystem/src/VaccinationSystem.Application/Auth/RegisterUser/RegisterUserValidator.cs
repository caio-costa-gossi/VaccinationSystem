using FluentValidation;

namespace VaccinationSystem.Application.Auth.RegisterUser
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255)
                .Must(name => !name.Contains(' '));

            RuleFor(x => x.Password)
                .NotEmpty()
                .MaximumLength(255)
                .Must(pw => !pw.Contains(' '));
        }
    }
}
