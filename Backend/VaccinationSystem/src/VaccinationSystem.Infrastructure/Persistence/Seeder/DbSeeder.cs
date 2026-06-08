using VaccinationSystem.Domain.Aggregates;
using VaccinationSystem.Domain.Auth;
using VaccinationSystem.Domain.Entities;

namespace VaccinationSystem.Infrastructure.Persistence.Seeder
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            // Users
            if (!db.Users.Any())
            {
                db.Users.Add(new User
                {
                    Name = "user",
                    Password = "AQAAAAIAAYagAAAAECDr/uZdpmtgSDOsFA8cNnhnC2JQwRj8vdzDn3JhDxymLse0/R9Jf7v6TP0+so7sTA=="
                });
            }

            // Persons, Vaccines, Vaccinations
            Guid personId = Guid.NewGuid();
            Guid vaccineId = Guid.NewGuid();

            Person person = new("João");
            Vaccine vaccine = new("COVID-19");
            List<Vaccination> vaccinations = new() {
                new Vaccination() {
                    Id = Guid.NewGuid(),
                    VaccineId = vaccineId,
                    PersonId = personId,
                    DoseNumber = 1,
                    AppliedAt = DateOnly.FromDateTime(DateTime.Now),
                    Vaccine = vaccine
                },
                new Vaccination() {
                    Id = Guid.NewGuid(),
                    VaccineId = vaccineId,
                    PersonId = personId,
                    DoseNumber = 2,
                    AppliedAt = DateOnly.FromDateTime(DateTime.Now),
                    Vaccine = vaccine
                }
            };
            
            typeof(Person).GetProperty("Id")!.SetValue(person, personId);
            typeof(Person).GetProperty("Vaccinations")!.SetValue(person, vaccinations);
            typeof(Vaccine).GetProperty("Id")!.SetValue(vaccine, vaccineId);

            if (!db.Persons.Any() && !db.Vaccines.Any())
            {
                db.Vaccines.Add(vaccine);
                db.Persons.Add(person);
            }

            db.SaveChanges();
        }
    }
}
