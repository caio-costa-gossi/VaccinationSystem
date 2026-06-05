using System;
using System.Collections.Generic;
using System.Text;

namespace VaccinationSystem.Domain.Aggregates
{
    public class Vaccine
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = "";

        // Para EF Core apenas
        private Vaccine() { }

        public Vaccine(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Nome é necessário");

            Id = default;
            Name = name;
        }
    }
}
