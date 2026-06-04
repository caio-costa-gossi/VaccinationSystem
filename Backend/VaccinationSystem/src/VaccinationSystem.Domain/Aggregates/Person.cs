using System.Xml.Linq;
using VaccinationSystem.Domain.Entities;

namespace VaccinationSystem.Domain.Aggregates;

public class Person
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = "";

    private readonly List<Vaccination> _vaccinations = [];

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
