using FluentValidation;

namespace VaccinationSystem.Application.Vaccinations.DeleteVaccination
{
    public class DeleteVaccinationValidator : AbstractValidator<DeleteVaccinationCommand>
    {
        public DeleteVaccinationValidator()
        {
            RuleFor(x => x.PersonId)
                .NotEmpty();

            RuleFor(x => x.VaccinationId)
                .NotEmpty();
        }
    }
}
