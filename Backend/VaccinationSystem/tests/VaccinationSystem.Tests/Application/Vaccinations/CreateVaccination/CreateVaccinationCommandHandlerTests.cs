using Moq;
using VaccinationSystem.Application.Common.Exceptions;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Application.Vaccinations.CreateVaccination;
using VaccinationSystem.Domain.Aggregates;
using VaccinationSystem.Domain.Common.Exceptions;

namespace VaccinationSystem.Tests.Application.Vaccinations.CreateVaccination
{
    public class CreateVaccinationCommandHandlerTests
    {
        private readonly Mock<IPersonRepository> _personRepository;
        private readonly Mock<IVaccineRepository> _vaccineRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        private readonly CreateVaccinationCommandHandler _handler;

        public CreateVaccinationCommandHandlerTests()
        {
            _personRepository = new();
            _vaccineRepository = new();
            _unitOfWork = new();

            _handler = new(
                _personRepository.Object,
                _vaccineRepository.Object,
                _unitOfWork.Object);
        }

        [Fact]
        public async Task Handle_WhenPersonExistsVaccineExistsAndDoseIsValid_ShouldCreate()
        {
            // Arrange
            Guid personId = Guid.NewGuid();
            Guid vaccineId = Guid.NewGuid();

            Person person = new("person");
            Vaccine vaccine = new("vaccine");

            _personRepository
                .Setup(r => r.GetByIdAsync(personId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(person);

            _vaccineRepository
                .Setup(r => r.GetByIdAsync(vaccineId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(vaccine);

            CreateVaccinationCommand command = new(personId, vaccineId, 1, DateOnly.FromDateTime(DateTime.Now));

            // Act
            Guid newVaccination = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _unitOfWork.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

            Assert.Single(person.Vaccinations);
            Assert.Equal(Guid.Empty, person.Vaccinations.First().Id);
            Assert.Equal(1, person.Vaccinations.First().DoseNumber);
        }

        [Fact]
        public async Task Handle_WhenPersonExistsVaccineExistsAndDoseIsNotValid_ShouldThrow()
        {
            // Arrange
            Guid personId = Guid.NewGuid();
            Guid vaccineId = Guid.NewGuid();

            Person person = new("person");
            Vaccine vaccine = new("vaccine");

            _personRepository
                .Setup(r => r.GetByIdAsync(personId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(person);

            _vaccineRepository
                .Setup(r => r.GetByIdAsync(vaccineId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(vaccine);

            CreateVaccinationCommand command = new(personId, vaccineId, 2, DateOnly.FromDateTime(DateTime.Now));

            // Act/Assert
            await Assert.ThrowsAsync<BusinessRuleViolationException>(() =>
                _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_WhenPersonNotExistsAndVaccineExists_ShouldThrow()
        {
            // Arrange
            Guid personId = Guid.NewGuid();
            Guid vaccineId = Guid.NewGuid();

            Vaccine vaccine = new("vaccine");

            _personRepository
                .Setup(r => r.GetByIdAsync(personId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Person?) null);

            _vaccineRepository
                .Setup(r => r.GetByIdAsync(vaccineId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(vaccine);

            CreateVaccinationCommand command = new(personId, vaccineId, 2, DateOnly.FromDateTime(DateTime.Now));

            // Act/Assert
            await Assert.ThrowsAsync<NotFoundException>(() =>
                _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_WhenPersonExistsAndVaccineNotExists_ShouldThrow()
        {
            // Arrange
            Guid personId = Guid.NewGuid();
            Guid vaccineId = Guid.NewGuid();

            Person person = new("person");

            _personRepository
                .Setup(r => r.GetByIdAsync(personId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(person);

            _vaccineRepository
                .Setup(r => r.GetByIdAsync(vaccineId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Vaccine?) null);

            CreateVaccinationCommand command = new(personId, vaccineId, 2, DateOnly.FromDateTime(DateTime.Now));

            // Act/Assert
            await Assert.ThrowsAsync<NotFoundException>(() =>
                _handler.Handle(command, CancellationToken.None));
        }
    }
}
