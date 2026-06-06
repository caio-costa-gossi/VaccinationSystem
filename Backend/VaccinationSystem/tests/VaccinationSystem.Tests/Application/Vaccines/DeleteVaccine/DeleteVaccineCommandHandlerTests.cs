using Moq;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Application.Vaccines.DeleteVaccine;

namespace VaccinationSystem.Tests.Application.Vaccines.DeleteVaccine
{
    public class DeleteVaccineCommandHandlerTests
    {
        private readonly Mock<IVaccineRepository> _vaccineRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        private readonly DeleteVaccineCommandHandler _handler;

        public DeleteVaccineCommandHandlerTests()
        {
            _vaccineRepository = new();
            _unitOfWork = new();

            _handler = new(
                _vaccineRepository.Object,
                _unitOfWork.Object);
        }

        [Fact]
        public async Task Handle_ShouldDeleteVaccine()
        {
            // Arrange
            Guid vaccineId = Guid.NewGuid();
            DeleteVaccineCommand command = new(vaccineId);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _vaccineRepository.Verify(r => r.DeleteByIdAsync(vaccineId, It.IsAny<CancellationToken>()), Times.Once);
            _unitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
