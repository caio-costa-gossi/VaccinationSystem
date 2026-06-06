using Microsoft.AspNetCore.Identity;
using Moq;
using VaccinationSystem.Application.Auth.LogIn;
using VaccinationSystem.Application.Common.Exceptions;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Auth;

namespace VaccinationSystem.Tests.Application.Auth.LogIn
{
    public class LoginCommandHandlerTests
    {
        public readonly Mock<IUserRepository> _userRepository;
        public readonly Mock<IJwtTokenGenerator> _tokenGenerator;
        public readonly Mock<IPasswordHasher<User>> _passwordHasher;

        public readonly LoginCommandHandler _handler;

        public LoginCommandHandlerTests()
        {
            _userRepository = new();
            _tokenGenerator = new();
            _passwordHasher = new();

            _handler = new(
                _userRepository.Object,
                _tokenGenerator.Object,
                _passwordHasher.Object);
        }

        [Fact]
        public async Task Handle_WhenUserExistsAndPasswordIsCorrect_ShouldReturnToken()
        {
            // Arrange
            User user = new() { Name = "user", Password = "user" };
            string token = "jwt-token";

            _userRepository
                .Setup(r => r.GetByNameAsync("user", It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            _passwordHasher
                .Setup(r => r.VerifyHashedPassword(user, "user", "user"))
                .Returns(PasswordVerificationResult.Success);

            _tokenGenerator
                .Setup(r => r.GenerateToken(user))
                .Returns(token);

            LoginCommand command = new("user", "user");

            // Act
            LoginResponseDto response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(token, response.AccessToken);
        }

        [Fact]
        public async Task Handle_WhenUserNotExists_ShouldThrow()
        {
            // Arrange
            _userRepository
                .Setup(r => r.GetByNameAsync("user", It.IsAny<CancellationToken>()))
                .ReturnsAsync((User?) null);

            LoginCommand command = new("user", "user");

            // Act/Assert
            await Assert.ThrowsAsync<UnauthorizedException>(() =>
                _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_WhenPasswordInvalid_ShouldThrow()
        {
            // Arrange
            User user = new() { Name = "user", Password = "user" };

            _userRepository
                .Setup(r => r.GetByNameAsync("user", It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            _passwordHasher
                .Setup(r => r.VerifyHashedPassword(user, "user", "user"))
                .Returns(PasswordVerificationResult.Failed);

            LoginCommand command = new("user", "user");

            // Act/Assert
            await Assert.ThrowsAsync<UnauthorizedException>(() =>
                _handler.Handle(command, CancellationToken.None));
        }
    }
}
