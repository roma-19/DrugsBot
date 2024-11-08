using Domain.Validators;
using FluentValidation;

namespace Domain.Entities;

/// <summary>
/// Лекарство.
/// </summary>
public class Drug : BaseEntity
{
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
    public Country Country { get; private set; }
    
    /// <summary>
    /// Навигационное свойство для связи с DrugItem.
    /// </summary>
    public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
    
    /// <summary>
    /// Код страны производителя.
    /// </summary>
    public string? CountryCodeId { get; set; }
    
    /// <summary>
    /// Конструктор для инициализации лекарства.
    /// </summary>
    /// <param name="name">название.</param>
    /// <param name="manufacturer">производитель.</param>
    /// <param name="countryCodeId">код страны производителя.</param>
    /// <param name="country">страна.</param>
    public Drug(string? name, string? manufacturer, string? countryCodeId, Country country)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = countryCodeId;
        Country = country;
        
        Validate();
    }

    private void Validate()
    {
        var validator = new DrugValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}