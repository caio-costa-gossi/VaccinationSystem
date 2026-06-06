using FluentValidation;
using FluentValidation.Results;
using VaccinationSystem.Application.Auth.RegisterUser;

namespace VaccinationSystem.Tests.Application.Auth.RegisterUser
{
    public class RegisterUserValidatorTests
    {
        [Fact]
        public void Validate_WhenUserAndPasswordAreValid_ShouldBeTrue()
        {
            // Arrange
            RegisterUserValidator validator = new();
            RegisterUserCommand command = new("user", "user");

            // Act
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenNameIsEmpty_ShouldBeFalse()
        {
            // Arrange
            RegisterUserValidator validator = new();
            RegisterUserCommand command = new("", "user");

            // Act/Assert
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_WhenPasswordContainsSpace_ShouldBeFalse()
        {
            // Arrange
            RegisterUserValidator validator = new();
            RegisterUserCommand command = new("user", "my password");

            // Act/Assert
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validate_WhenUserIsTooBig_ShouldBeFalse()
        {
            // Arrange
            RegisterUserValidator validator = new();
            RegisterUserCommand command = new(new('a', 256), "user");

            // Act/Assert
            ValidationResult result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
