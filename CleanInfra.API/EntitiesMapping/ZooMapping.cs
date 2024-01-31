using CleanInfra.API.Constants;
using CleanInfra.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanInfra.API.EntitiesMapping;

public sealed class ZooMapping : IEntityTypeConfiguration<Zoo>
{
    public void Configure(EntityTypeBuilder<Zoo> builder)
    {
        builder.ToTable("Zoos", SchemaConstants.DefaultSchema);

        builder.HasKey(z => z.Id);

        builder.Property(z => z.Name)
            .IsRequired(true)
            .HasColumnName("name")
            .HasColumnType("varchar(100)");

        builder.Property(z => z.Location)
            .IsRequired(true)
            .HasColumnName("location")
            .HasColumnType("varchar(150)");

        builder.Property(z => z.EntryPrice)
            .IsRequired(true)
            .HasColumnName("entry_price")
            .HasColumnType("decimal(18, 2)");

        builder.HasMany(z => z.Animals)
            .WithOne(a => a.Zoo)
            .HasForeignKey(a => a.ZooId)
            .HasConstraintName("FK_Zoo_Animal")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
