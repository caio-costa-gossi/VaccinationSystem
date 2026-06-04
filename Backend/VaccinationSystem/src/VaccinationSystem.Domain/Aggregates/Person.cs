using System.Xml.Linq;

namespace VaccinationSystem.Domain.Aggregates;

public class Person
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public Person(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new Exception("Nome é necessário");

        Id = Guid.NewGuid();
        Name = name;
    }

    public void ChangeName(string newName)
    {
        if (string.IsNullOrEmpty(newName))
            throw new Exception("Nome é necessário");

        Name = newName;
    }
}
