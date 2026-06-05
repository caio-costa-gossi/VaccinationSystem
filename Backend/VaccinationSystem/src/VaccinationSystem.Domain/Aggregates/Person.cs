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

    public Guid AddVaccination(Guid vaccineId, int doseNumber)
    {
        // Validar número da dose
        int lastDose = Vaccinations.Max(e => e.DoseNumber);

        if (doseNumber != lastDose + 1)
            return Guid.Empty;

        // Criar e adicionar nova vaccination
        Vaccination newVaccination = new()
        {
            Id = Guid.NewGuid(),
            VaccineId = vaccineId,
            PersonId = Id,
            DoseNumber = doseNumber,
            AppliedAt = DateTime.UtcNow,
        };

        Vaccinations.Add(newVaccination);

        return newVaccination.Id;
    }

    public void RemoveVaccination(Guid vaccinationId)
    {
        Vaccinations.RemoveAll(v => v.Id == vaccinationId);
    }
}
