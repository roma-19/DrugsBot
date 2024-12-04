using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

/// <summary>
/// Конфигурация для DrugItem.
/// </summary>
public class DrugItemConfiguration : IEntityTypeConfiguration<DrugItem>
{
    /// <summary>
    /// Метод конфигурации для DrugItem.
    /// </summary>
    /// <param name="builder">Построитель конфигурации сущности.</param>
    public void Configure(EntityTypeBuilder<DrugItem> builder)
    {
        builder.ToTable(nameof(DrugItem));
        
        builder.HasKey(di => di.Id);
        
        builder.Property(di => di.DrugId)
            .IsRequired();
        
        builder.Property(di => di.DrugStoreId)
            .IsRequired();
        
        builder.Property(di => di.Cost)
            .IsRequired()
            .HasPrecision(7, 2);
        
        builder.Property(di => di.Count)
            .IsRequired();
            
        builder.HasOne(di => di.Drug)
            .WithMany(d => d.DrugItems)
            .HasForeignKey(di => di.DrugId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(di => di.DrugStore)
            .WithMany(ds => ds.DrugItems)
            .HasForeignKey(di => di.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}