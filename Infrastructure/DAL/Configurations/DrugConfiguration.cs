using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

/// <summary>
/// Конфигурация для Drug.
/// </summary>
public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    /// <summary>
    /// Метод конфигурации для Drug.
    /// </summary>
    /// <param name="builder">Построитель конфигурации сущности.</param>
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        builder.ToTable(nameof(Drug));
        
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(d => d.Manufacturer)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.HasOne(d => d.Country)
            .WithMany(c => c.Drugs)
            .HasForeignKey(d => d.CountryCodeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(d => d.CountryCodeId)
            .IsRequired()
            .HasMaxLength(2);

        builder.HasMany(d => d.DrugItems)
            .WithOne(di => di.Drug)
            .HasForeignKey(di => di.DrugId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}