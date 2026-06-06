using FluentValidation.Results;
using VaccinationSystem.Application.Persons.GetPerson;

namespace VaccinationSystem.Tests.Application.Persons.GetPerson
{
    public class GetPersonValidatorTests
    {
        [Fact]
        public void Validate_WhenGuidIsValid_ShouldBeTrue()
        {
            // Arrange
            GetPersonValidator validator = new();
            GetPersonQuery query = new(Guid.NewGuid());

            // Act
            ValidationResult result = validator.Validate(query);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenGuidIsEmpty_ShouldBeTrue()
        {
            // Arrange
            GetPersonValidator validator = new();
            GetPersonQuery query = new(Guid.Empty);

            // Act
            ValidationResult result = validator.Validate(query);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
