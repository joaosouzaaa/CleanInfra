using CleanInfra.API.Constants;
using CleanInfra.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanInfra.API.EntitiesMapping;

public sealed class AnimalMapping : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.ToTable("Animals", SchemaConstants.DefaultSchema);

        builder.HasKey(a => a.Id);

        builder.Property(a => a.ScientificName)
            .IsRequired(true)
            .HasColumnName("scientific_name")
            .HasColumnType("varchar(100)");

        builder.Property(a => a.Species)
            .IsRequired(true)
            .HasColumnName("species")
            .HasColumnType("varchar(100)");
    }
}
