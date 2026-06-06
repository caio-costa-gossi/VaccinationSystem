using FluentValidation;

namespace VaccinationSystem.Application.Vaccines.DeleteVaccine
{
    public class DeleteVaccineValidator : AbstractValidator<DeleteVaccineCommand>
    {
        public DeleteVaccineValidator()
        {
            RuleFor(x => x.VaccineId)
                .NotEmpty();
        }
    }
}
