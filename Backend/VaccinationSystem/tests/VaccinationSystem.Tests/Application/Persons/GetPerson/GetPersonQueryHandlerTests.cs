using Moq;
using VaccinationSystem.Application.Common.Exceptions;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Application.Persons.CreatePerson;
using VaccinationSystem.Application.Persons.GetPerson;
using VaccinationSystem.Domain.Aggregates;
using VaccinationSystem.Domain.Entities;

namespace VaccinationSystem.Tests.Application.Persons.GetPerson
{
    public class GetPersonQueryHandlerTests
    {
        private readonly Mock<IPersonRepository> _personRepository;

        private readonly GetPersonQueryHandler _handler;

        public GetPersonQueryHandlerTests()
        {
            _personRepository = new();

            _handler = new(_personRepository.Object);
        }

        [Fact]
        public async Task Handle_WhenPersonExistsAndThereIsOneVaccination_ShouldReturnPersonAndVaccination()
        {
            // Arrange
            Guid personId = Guid.NewGuid();
            Guid vaccinationId = Guid.NewGuid();
            Guid vaccineId = Guid.NewGuid();

            Person person = new("person");
            Vaccine vaccine = new("vaccine");
            Vaccination vaccination = new() 
            {
                Id = vaccinationId,
                VaccineId = vaccineId,
                PersonId = personId,
                DoseNumber = 1,
                AppliedAt = DateTime.Now,
                Vaccine = vaccine
            };

            typeof(Person).GetProperty("Id")!.SetValue(person, personId);
            typeof(Person).GetProperty("Vaccinations")!.SetValue(person, new List<Vaccination>() { vaccination });
            typeof(Vaccine).GetProperty("Id")!.SetValue(vaccine, vaccineId);

            GetPersonQuery query = new(personId);

            _personRepository
                .Setup(r => r.GetByIdAsync(personId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(person);

            // Act
            GetPersonDto response = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(person.Name, response.Name);
            Assert.Equal(person.Id, response.Id);
            Assert.Equal(person.Vaccinations.First().VaccineId, vaccine.Id);
            Assert.Equal(person.Vaccinations.First().Vaccine?.Name, vaccine.Name);
            Assert.Equal(person.Vaccinations.First().DoseNumber, vaccination.DoseNumber);
        }

        [Fact]
        public async Task Handle_WhenPersonNotExists_ShouldThrow()
        {
            // Arrange
            Guid personId = Guid.NewGuid();
            GetPersonQuery query = new(personId);

            _personRepository
                .Setup(r => r.GetByIdAsync(personId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Person?) null);

            // Act/Assert
            await Assert.ThrowsAsync<NotFoundException>(() =>
                _handler.Handle(query, CancellationToken.None));
        }
    }
}
