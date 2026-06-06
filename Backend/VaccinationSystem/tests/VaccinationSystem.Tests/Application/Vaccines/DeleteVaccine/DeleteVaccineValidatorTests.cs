using FluentValidation.Results;
using VaccinationSystem.Application.Vaccines.DeleteVaccine;

namespace VaccinationSystem.Tests.Application.Vaccines.DeleteVaccine
{
    public class DeleteVaccineValidatorTests
    {
        [Fact]
        public void Validate_WhenGuidIsValid_ShouldBeTrue()
        {
            // Arrange
            DeleteVaccineValidator validator = new();
            DeleteVaccineCommand command = new(Guid.NewGuid());

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenGuidIsEmpty_ShouldBeFalse()
        {
            // Arrange
            DeleteVaccineValidator validator = new();
            DeleteVaccineCommand command = new(Guid.Empty);

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
