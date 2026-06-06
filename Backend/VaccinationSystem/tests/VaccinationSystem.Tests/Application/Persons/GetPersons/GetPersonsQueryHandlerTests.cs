using Moq;
using VaccinationSystem.Application.Common.Interfaces;
using VaccinationSystem.Application.Persons.GetPersons;
using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Tests.Application.Persons.GetPersons
{
    public class GetPersonsQueryHandlerTests
    {
        private readonly Mock<IPersonRepository> _personRepository;

        private readonly GetPersonsQueryHandler _handler;

        public GetPersonsQueryHandlerTests()
        {
            _personRepository = new();

            _handler = new(_personRepository.Object);
        }

        [Fact]
        public async Task Handle_WhenThereIsOnePerson_ShouldReturnOnePerson()
        {
            // Arrange
            Guid personId = Guid.NewGuid();
            Person person = new("person");

            typeof(Person).GetProperty("Id")!.SetValue(person, personId);

            _personRepository
                .Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync([person]);

            GetPersonsQuery query = new();

            // Act
            List<GetPersonsItemDto> persons = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Single(persons);
            Assert.Equal(personId, persons.First().Id);
            Assert.Equal("person", persons.First().Name);
        }

        [Fact]
        public async Task Handle_WhenThereIsNoVaccine_ShouldReturnEmptyList()
        {
            // Arrange
            _personRepository
                .Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync([]);

            GetPersonsQuery query = new();

            // Act
            List<GetPersonsItemDto> persons = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Empty(persons);
        }
    }
}
