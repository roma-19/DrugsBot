using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

/// <summary>
/// Конфигурация для Profile.
/// </summary>
public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    /// <summary>
    /// Метод конфигурации для Profile.
    /// </summary>
    /// <param name="builder">Построитель конфигурации сущности.</param>
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable(nameof(Profile));
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.ExternalId).IsRequired();
        
        builder.Property(p => p.Email).IsRequired();
        
        builder.HasMany(p => p.FavouriteDrugs)
            .WithOne(fd => fd.Profile)
            .HasForeignKey(fd => fd.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}