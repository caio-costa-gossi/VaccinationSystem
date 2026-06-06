using FluentValidation.Results;
using VaccinationSystem.Application.Persons.CreatePerson;

namespace VaccinationSystem.Tests.Application.Persons.CreatePerson
{
    public class CreatePersonValidatorTests
    {
        [Fact]
        public void Validate_WhenNameIsValid_ShouldBeTrue()
        {
            // Arrange
            CreatePersonValidator validator = new();
            CreatePersonCommand command = new("person");

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenNameIsEmpty_ShouldBeFalse()
        {
            // Arrange
            CreatePersonValidator validator = new();
            CreatePersonCommand command = new("  ");

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_WhenNameIsTooBig_ShouldBeFalse()
        {
            // Arrange
            CreatePersonValidator validator = new();
            CreatePersonCommand command = new(new('a', 256));

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
