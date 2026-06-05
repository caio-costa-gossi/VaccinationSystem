using FluentValidation;

namespace VaccinationSystem.Application.Vaccines.CreateVaccine
{
    public class CreateVaccineValidator : AbstractValidator<CreateVaccineCommand>
    {
        public CreateVaccineValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
