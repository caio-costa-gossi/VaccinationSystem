using FluentValidation;

namespace VaccinationSystem.Application.Vaccinations.CreateVaccination
{
    public class CreateVaccinationValidator : AbstractValidator<CreateVaccinationCommand>
    {
        public CreateVaccinationValidator()
        {
            RuleFor(x => x.PersonId)
                .NotEmpty();

            RuleFor(x => x.VaccineId)
                .NotEmpty();

            RuleFor(x => x.DoseNumber)
                .GreaterThanOrEqualTo(0);
        }
    }
}
