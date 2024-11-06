namespace Domain.Entities;

/// <summary>
/// Страна производителя лекарства.
/// </summary>
public class Country : BaseEntity
{
    /// <summary>
    /// Название страны.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Код страны.
    /// </summary>
    public string? Code { get; set; }
    
    /// <summary>
    /// Конструктор для инициализации страны.
    /// </summary>
    /// <param name="name">название страны.</param>
    /// <param name="code">код страны.</param>
    public Country(string? name, string? code)
    {
        Name = name;
        Code = code;
    }
    
    /// <summary>
    /// Навигационное свойство для связи с препаратами.
    /// </summary>
    public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();
}