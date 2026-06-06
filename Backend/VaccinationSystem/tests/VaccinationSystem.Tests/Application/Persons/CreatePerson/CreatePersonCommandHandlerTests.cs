using Moq;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Application.Persons.CreatePerson;

namespace VaccinationSystem.Tests.Application.Persons.CreatePerson
{
    public class CreatePersonCommandHandlerTests
    {
        private readonly Mock<IPersonRepository> _personRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        private readonly CreatePersonCommandHandler _handler;

        public CreatePersonCommandHandlerTests()
        {
            _personRepository = new();
            _unitOfWork = new();

            _handler = new(
                _personRepository.Object,
                _unitOfWork.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreatePerson()
        {
            // Arrange
            CreatePersonCommand command = new("person");

            // Act
            Guid response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(Guid.Empty, response);
            _unitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
