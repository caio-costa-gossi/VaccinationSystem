using Microsoft.AspNetCore.Identity;
using Moq;
using VaccinationSystem.Application.Auth.RegisterUser;
using VaccinationSystem.Application.Common.Exceptions;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Domain.Auth;

namespace VaccinationSystem.Tests.Application.Auth.RegisterUser
{
    public class RegisterUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IPasswordHasher<User>> _passwordHasher;

        private readonly RegisterUserCommandHandler _handler;

        public RegisterUserCommandHandlerTests()
        {
            _userRepository = new();
            _unitOfWork = new();
            _passwordHasher = new();

            _handler = new(
                _userRepository.Object, 
                _unitOfWork.Object, 
                _passwordHasher.Object);
        }

        [Fact]
        public async Task Handle_WhenUserAndPasswordAreValidAndUserNotExists_ShouldRegister()
        {
            // Arrange
            _userRepository
                .Setup(r => r.UserNameExistsAsync("user", It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            RegisterUserCommand command = new("user", "user");

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _unitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenUserAndPasswordAreValidAndUserExists_ShouldThrow()
        {
            // Arrange
            _userRepository
                .Setup(r => r.UserNameExistsAsync("user", It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            RegisterUserCommand command = new("user", "user");

            // Act and Assert
            await Assert.ThrowsAsync<ConflictException>(() =>
                _handler.Handle(command, CancellationToken.None));
        }
    }
}
