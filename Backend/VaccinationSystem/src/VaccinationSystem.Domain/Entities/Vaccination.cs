using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Domain.Entities
{
    public class Vaccination
    {
        public Guid Id { get; set; }
        public Guid VaccineId { get; set; }
        public Guid PersonId { get; set; }
        public int DoseNumber { get; set; }
        public DateOnly AppliedAt { get; set; }

        public Vaccine? Vaccine { get; set; }
    }
}
