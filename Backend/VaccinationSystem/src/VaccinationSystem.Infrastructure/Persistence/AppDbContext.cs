using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Domain.Aggregates;

namespace VaccinationSystem.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<Person> Persons => Set<Person>();

        public DbSet<Vaccine> Vaccines => Set<Vaccine>();


    }
}
