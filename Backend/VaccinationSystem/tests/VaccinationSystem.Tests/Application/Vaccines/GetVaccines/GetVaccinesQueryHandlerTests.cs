using Moq;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Application.Vaccines.GetVaccines;
using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Tests.Application.Vaccines.GetVaccines
{
    public class GetVaccinesQueryHandlerTests
    {
        private readonly Mock<IVaccineRepository> _vaccineRepository;

        private readonly GetVaccinesQueryHandler _handler;

        public GetVaccinesQueryHandlerTests()
        {
            _vaccineRepository = new();

            _handler = new(_vaccineRepository.Object);
        }

        [Fact]
        public async Task Handle_WhenThereIsOneVaccine_ShouldReturnOneVaccine()
        {
            // Arrange
            Guid vaccineId = Guid.NewGuid();
            Vaccine vaccine = new("vaccine");
            
            typeof(Vaccine).GetProperty("Id")!.SetValue(vaccine, vaccineId);

            _vaccineRepository
                .Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync([vaccine]);
            
            GetVaccinesQuery query = new();

            // Act
            List<GetVaccinesItemDto> vaccines = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Single(vaccines);
            Assert.Equal(vaccineId, vaccines.First().Id);
            Assert.Equal("vaccine", vaccines.First().Name);
        }

        [Fact]
        public async Task Handle_WhenThereIsNoVaccine_ShouldReturnEmptyList()
        {
            // Arrange
            _vaccineRepository
                .Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync([]);

            GetVaccinesQuery query = new();

            // Act
            List<GetVaccinesItemDto> vaccines = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Empty(vaccines);
        }
    }
}
