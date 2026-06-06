using FluentValidation.Results;
using VaccinationSystem.Application.Auth.LogIn;

namespace VaccinationSystem.Tests.Application.Auth.LogIn
{
    public class LoginValidatorTests
    {
        [Fact]
        public void Validate_WhenUserAndPasswordAreValid_ShouldBeTrue()
        {
            // Arrange
            LoginValidator validator = new();
            LoginCommand command = new("user", "user");

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenNameIsEmpty_ShouldBeFalse()
        {
            // Arrange
            LoginValidator validator = new();
            LoginCommand command = new(" ", "user");

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_WhenPasswordContainsSpace_ShouldBeFalse()
        {
            // Arrange
            LoginValidator validator = new();
            LoginCommand command = new("user", "my user");

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_WhenUserIsTooBig_ShouldBeFalse()
        {
            // Arrange
            LoginValidator validator = new();
            LoginCommand command = new(new('a', 256), "my user");

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
