using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

/// <summary>
/// Конфигурация для FavouriteDrug.
/// </summary>
public class FavouriteDrugConfiguration : IEntityTypeConfiguration<FavouriteDrug>
{
    /// <summary>
    /// Метод конфигурации для FavouriteDrug.
    /// </summary>
    /// <param name="builder">Построитель конфигурации сущности.</param>
    public void Configure(EntityTypeBuilder<FavouriteDrug> builder)
    {
        builder.ToTable(nameof(FavouriteDrug));
        
        builder.HasKey(fd => fd.Id);
        
        builder.Property(fd => fd.DrugId).IsRequired();
        
        builder.Property(fd => fd.DrugStoreId).IsRequired();
        
        builder.Property(fd => fd.ProfileId).IsRequired();
        
        builder.HasOne(fd => fd.Drug)
            .WithMany()
            .HasForeignKey(fd => fd.DrugId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(fd => fd.DrugStore)
            .WithMany()
            .HasForeignKey(fd => fd.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(fd => fd.Profile)
            .WithMany(p => p.FavouriteDrugs)
            .HasForeignKey(fd => fd.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}