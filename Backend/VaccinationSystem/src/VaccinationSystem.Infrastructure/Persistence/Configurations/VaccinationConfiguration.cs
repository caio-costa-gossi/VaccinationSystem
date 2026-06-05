using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaccinationSystem.Domain.Aggregates;
using VaccinationSystem.Domain.Entities;

namespace VaccinationSystem.Infrastructure.Persistence.Configurations
{
    internal class VaccinationConfiguration : IEntityTypeConfiguration<Vaccination>
    {
        public void Configure(EntityTypeBuilder<Vaccination> builder)
        {
            builder.ToTable("Vaccinations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DoseNumber)
                .IsRequired();

            builder.Property(x => x.AppliedAt)
                .IsRequired();

            builder.HasOne(x => x.Vaccine)
                .WithMany()
                .HasForeignKey(x => x.VaccineId);
        }
    }
}
