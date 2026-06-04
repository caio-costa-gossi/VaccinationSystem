using System;
using System.Collections.Generic;
using System.Text;

namespace VaccinationSystem.Domain.Entities
{
    internal class Vaccination
    {
        public Guid Id { get; set; }
        public Guid VaccineId { get; set; }
        public int DoseNumber { get; set; }
        public DateTime AppliedAt { get; set; }
    }
}
