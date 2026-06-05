using VaccinationSystem.Domain.Common.Exceptions;
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

        Id = default;
        Name = name;
    }

    public Vaccination AddVaccination(Guid vaccineId, int doseNumber)
    {
        // Validar número da dose
        int lastDose = Vaccinations.Count > 0 ? Vaccinations.Max(e => e.DoseNumber) : 0;

        if (doseNumber != lastDose + 1)
            throw new BusinessRuleViolationException("Dose da vacina inválida.");

        // Criar e adicionar nova vaccination
        Vaccination newVaccination = new()
        {
            Id = default,
            VaccineId = vaccineId,
            PersonId = Id,
            DoseNumber = doseNumber,
            AppliedAt = DateTime.UtcNow,
        };

        Vaccinations.Add(newVaccination);

        return newVaccination;
    }

    public void RemoveVaccination(Guid vaccinationId)
    {
        Vaccinations.RemoveAll(v => v.Id == vaccinationId);
    }
}
