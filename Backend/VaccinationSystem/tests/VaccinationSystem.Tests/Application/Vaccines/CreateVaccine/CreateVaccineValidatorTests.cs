using FluentValidation.Results;
using VaccinationSystem.Application.Vaccines.CreateVaccine;

namespace VaccinationSystem.Tests.Application.Vaccines.CreateVaccine
{
    public class CreateVaccineValidatorTests
    {
        [Fact]
        public void Validate_WhenNameIsValid_ShouldBeTrue()
        {
            // Arrange
            CreateVaccineValidator validator = new();
            CreateVaccineCommand command = new("vaccine");

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenNameIsEmpty_ShouldBeFalse()
        {
            // Arrange
            CreateVaccineValidator validator = new();
            CreateVaccineCommand command = new("");

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_WhenNameIsTooBig_ShouldBeFalse()
        {
            // Arrange
            CreateVaccineValidator validator = new();
            CreateVaccineCommand command = new(new('a',256));

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
