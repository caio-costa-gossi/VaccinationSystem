using FluentValidation.Results;
using VaccinationSystem.Application.Vaccinations.CreateVaccination;

namespace VaccinationSystem.Tests.Application.Vaccinations.CreateVaccination
{
    public class CreateVaccinationValidatorTests
    {
        [Fact]
        public void Validate_WhenPersonIdIsValidVaccineIdIsValidAndDoseNumberIsValid_ShouldBeTrue()
        {
            // Arrange
            CreateVaccinationValidator validator = new();
            CreateVaccinationCommand command = new(Guid.NewGuid(), Guid.NewGuid(), 1);

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenPersonIdIsEmpty_ShouldBeFalse()
        {
            // Arrange
            CreateVaccinationValidator validator = new();
            CreateVaccinationCommand command = new(Guid.Empty, Guid.NewGuid(), 1);

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_WhenVaccineIdIsEmpty_ShouldBeFalse()
        {
            // Arrange
            CreateVaccinationValidator validator = new();
            CreateVaccinationCommand command = new(Guid.NewGuid(), Guid.Empty, 1);

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_WhenDoseNumberIsNegative_ShouldBeFalse()
        {
            // Arrange
            CreateVaccinationValidator validator = new();
            CreateVaccinationCommand command = new(Guid.NewGuid(), Guid.NewGuid(), -1);

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
