using VaccinationSystem.Domain.Entities;

namespace VaccinationSystem.Domain.Aggregates;

public class Person
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = "";
    public List<Vaccination> Vaccinations { get; private set; } = [];

    // Para EF Core apenas
    private Person() { }
    
    public Person(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new Exception("Nome é necessário");

        Id = Guid.NewGuid();
        Name = name;
    }
}
