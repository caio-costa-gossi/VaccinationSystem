using FluentValidation.Results;
using VaccinationSystem.Application.Vaccinations.CreateVaccination;
using VaccinationSystem.Application.Vaccinations.DeleteVaccination;

namespace VaccinationSystem.Tests.Application.Vaccinations.DeleteVaccination
{
    public class DeleteVaccinationValidatorTests
    {
        [Fact]
        public void Validate_WhenPersonIdIsValidAndVaccinationIdIsValid_ShouldBeTrue()
        {
            // Arrange
            DeleteVaccinationValidator validator = new();
            DeleteVaccinationCommand command = new(Guid.NewGuid(), Guid.NewGuid());

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenPersonIdIsEmpty_ShouldBeFalse()
        {
            // Arrange
            DeleteVaccinationValidator validator = new();
            DeleteVaccinationCommand command = new(Guid.Empty, Guid.NewGuid());

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_WhenVaccinationIdIsEmpty_ShouldBeFalse()
        {
            // Arrange
            DeleteVaccinationValidator validator = new();
            DeleteVaccinationCommand command = new(Guid.NewGuid(), Guid.Empty);

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
