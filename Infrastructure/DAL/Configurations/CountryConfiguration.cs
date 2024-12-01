using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

/// <summary>
/// Конфигурация для Country.
/// </summary>
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    /// <summary>
    /// Метод конфигурации для Country.
    /// </summary>
    /// <param name="builder">Построитель конфигурации сущности.</param>
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable(nameof(Country));
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(2);
        
        builder.HasMany(c => c.Drugs)
            .WithOne(d => d.Country)
            .HasForeignKey(d => d.CountryCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}