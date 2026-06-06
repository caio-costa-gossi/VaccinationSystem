using Moq;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Application.Persons.DeletePerson;

namespace VaccinationSystem.Tests.Application.Persons.DeletePerson
{
    public class DeletePersonCommandHandlerTests
    {
        private readonly Mock<IPersonRepository> _personRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        private readonly DeletePersonCommandHandler _handler;

        public DeletePersonCommandHandlerTests()
        {
            _personRepository = new();
            _unitOfWork = new();

            _handler = new(
                _personRepository.Object,
                _unitOfWork.Object);
        }

        [Fact]
        public async Task Handle_ShouldDeletePerson()
        {
            // Arrange
            Guid personGuid = Guid.NewGuid();
            DeletePersonCommand command = new(personGuid);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _personRepository.Verify(r => r.DeleteByIdAsync(personGuid, It.IsAny<CancellationToken>()), Times.Once);
            _unitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
