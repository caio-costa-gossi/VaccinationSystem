using FluentValidation.Results;
using VaccinationSystem.Application.Persons.DeletePerson;

namespace VaccinationSystem.Tests.Application.Persons.DeletePerson
{
    public class DeletePersonValidatorTests
    {
        [Fact]
        public void Validate_WhenGuidIsValid_ShouldBeTrue()
        {
            // Arrange
            DeletePersonValidator validator = new();
            DeletePersonCommand command = new(Guid.NewGuid());

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenGuidIsEmpty_ShouldBeTrue()
        {
            // Arrange
            DeletePersonValidator validator = new();
            DeletePersonCommand command = new(Guid.Empty);

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
