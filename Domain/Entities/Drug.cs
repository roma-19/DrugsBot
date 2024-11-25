using Domain.Validators;

namespace Domain.Entities;

/// <summary>
/// Лекарство.
/// </summary>
public class Drug : BaseEntity<Drug>
{
    /// <summary>
    /// Конструктор для инициализации лекарства.
    /// </summary>
    /// <param name="name">Название.</param>
    /// <param name="manufacturer">Производитель.</param>
    /// <param name="countryCodeId">Код страны производителя.</param>
    /// <param name="country">Страна.</param>
    public Drug(string? name, string? manufacturer, string? countryCodeId, Country country)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = countryCodeId;
        Country = country;
        
        ValidateEntity(new DrugValidator());
    }

    /// <summary>
    /// Название лекарства.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Производитель лекарства.
    /// </summary>
    public string? Manufacturer { get; set; }
    
    /// <summary>
    /// Навигационное свойство для связи с Country.
    /// </summary>
    public Country Country { get; set; }
    
    /// <summary>
    /// Код страны производителя.
    /// </summary>
    public string? CountryCodeId { get; set; }
    
    /// <summary>
    /// Навигационное свойство для связи с DrugItem.
    /// </summary>
    public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
}