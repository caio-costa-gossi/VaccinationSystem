using Moq;
using VaccinationSystem.Application.Common.Exceptions;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Application.Vaccinations.CreateVaccination;
using VaccinationSystem.Application.Vaccinations.DeleteVaccination;
using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Tests.Application.Vaccinations.DeleteVaccination
{
    public class DeleteVaccinationCommandHandlerTests
    {
        private readonly Mock<IPersonRepository> _personRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        private readonly DeleteVaccinationCommandHandler _handler;

        public DeleteVaccinationCommandHandlerTests()
        {
            _personRepository = new();
            _unitOfWork = new();

            _handler = new(
                _personRepository.Object,
                _unitOfWork.Object);
        }

        [Fact]
        public async Task Handle_WhenPersonExists_ShouldDelete()
        {
            // Arrange
            Guid personId = Guid.NewGuid();
            Guid vaccinationId = Guid.NewGuid();

            Person person = new("person");

            _personRepository
                .Setup(r => r.GetByIdAsync(personId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(person);

            DeleteVaccinationCommand command = new(personId, vaccinationId);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _unitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenPersonNotExists_ShouldThrow()
        {
            // Arrange
            Guid personId = Guid.NewGuid();
            Guid vaccinationId = Guid.NewGuid();

            _personRepository
                .Setup(r => r.GetByIdAsync(personId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Person?) null);

            DeleteVaccinationCommand command = new(personId, vaccinationId);

            // Act/Assert
            await Assert.ThrowsAsync<NotFoundException>(() =>
                _handler.Handle(command, CancellationToken.None));
        }
    }
}
