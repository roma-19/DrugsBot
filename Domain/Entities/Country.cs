using Domain.Validators;

namespace Domain.Entities;

/// <summary>
/// Страна производителя лекарства.
/// </summary>
public class Country : BaseEntity<Country>
{
    /// <summary>
    /// Конструктор для инициализации страны.
    /// </summary>
    /// <param name="name">Название страны.</param>
    /// <param name="code">Код страны.</param>
    public Country(string? name, string? code)
    {
        Name = name;
        Code = code;
        
        ValidateEntity(new CountryValidator());
    }
    
    /// <summary>
    /// Название страны.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Код страны.
    /// </summary>
    public string? Code { get; set; }
    
    
    /// <summary>
    /// Навигационное свойство для связи с препаратами.
    /// </summary>
    public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();
}