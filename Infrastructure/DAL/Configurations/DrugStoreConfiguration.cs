using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

/// <summary>
/// Конфигурация для DrugStore.
/// </summary>
public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugStore>
{
    /// <summary>
    /// Метод конфигурации для DrugStore.
    /// </summary>
    /// <param name="builder">Построитель конфигурации сущности.</param>
    public void Configure(EntityTypeBuilder<DrugStore> builder)
    {
        builder.ToTable(nameof(DrugStore));
        
        builder.HasKey(ds => ds.Id);
        
        builder.Property(ds => ds.DrugNetwork)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ds => ds.Number)
            .IsRequired();
        
        builder.Property(ds => ds.Address)
            .IsRequired();
        
        builder.HasMany(ds => ds.DrugItems)
            .WithOne(di => di.DrugStore)
            .HasForeignKey(di => di.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}