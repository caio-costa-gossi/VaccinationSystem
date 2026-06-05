using FluentValidation;

namespace VaccinationSystem.Application.Vaccinations.DeleteVaccination
{
    public class DeleteVaccinationValidator : AbstractValidator<DeleteVaccinationCommand>
    {
        public DeleteVaccinationValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
