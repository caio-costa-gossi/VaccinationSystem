using Moq;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Application.Vaccines.CreateVaccine;

namespace VaccinationSystem.Tests.Application.Vaccines.CreateVaccine
{
    public class CreateVaccineCommandHandlerTests
    {
        private readonly Mock<IVaccineRepository> _vaccineRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        private readonly CreateVaccineCommandHandler _handler;

        public CreateVaccineCommandHandlerTests()
        {
            _vaccineRepository = new();
            _unitOfWork = new();

            _handler = new(
                _vaccineRepository.Object,
                _unitOfWork.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreate()
        {
            // Arrange
            CreateVaccineCommand command = new("vaccine");

            // Act
            Guid newVaccineId = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _unitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal(Guid.Empty, newVaccineId);
        }
    }
}
