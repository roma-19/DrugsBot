using Domain.Entities;
using Infrastructure.DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL;

/// <summary>
/// Контекст базы данных.
/// </summary>
public class DrugsBotDbContext : DbContext
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="options">Опции конфигурации контекста базы данных.</param>
    public DrugsBotDbContext(DbContextOptions<DrugsBotDbContext> options) : base(options)
    {

    }

    /// <summary>
    /// Набор данных для таблицы Drugs.
    /// </summary>
    public DbSet<Drug> Drugs { get; set; }

    /// <summary>
    /// Набор данных для таблицы Countries.
    /// </summary>
    public DbSet<Country> Countries { get; set; }

    /// <summary>
    /// Набор данных для таблицы DrugItems.
    /// </summary>
    public DbSet<DrugItem> DrugItems { get; set; }

    /// <summary>
    /// Набор данных для таблицы DrugStores.
    /// </summary>
    public DbSet<DrugStore> DrugStores { get; set; }

    /// <summary>
    /// Набор данных для таблицы FavouriteDrugs.
    /// </summary>
    public DbSet<FavouriteDrug> FavouriteDrugs { get; set; }

    /// <summary>
    /// Набор данных для таблицы Profiles.
    /// </summary>
    public DbSet<Profile> Profiles { get; set; }

    /// <summary>
    /// Настраивает модели базы данных при создании модели.
    /// </summary>
    /// <param name="modelBuilder">Построитель моделей базы данных.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DrugConfiguration());
    }
}