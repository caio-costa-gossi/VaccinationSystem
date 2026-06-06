using FluentValidation;

namespace VaccinationSystem.Application.Auth.LogIn
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
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
