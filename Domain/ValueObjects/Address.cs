namespace Domain.ValueObjects;

/// <summary>
/// Адрес.
/// </summary>
public class Address
{
    /// <summary>
    /// Город.
    /// </summary>
    public string City { get; set; }
    
    /// <summary>
    /// Улица.
    /// </summary>
    public string Street { get; set; }
    
    /// <summary>
    /// Дом.
    /// </summary>
    public string House { get; set; }
    
    /// <summary>
    /// Конструктор для инициализации адреса.
    /// </summary>
    /// <param name="street">улица.</param>
    /// <param name="city">город.</param>
    /// <param name="house">дом.</param>
    public Address(string street, string city, string house)
    {
        Street = street;
        City = city;
        House = house;
    }
    
    /// <summary>
    /// Возвращает адрес в виде строки.
    /// </summary>
    /// <returns>Строка, представляющая адрес.</returns>
    public override string ToString()
    {
        return $"{City}, {Street}, {House}";
    }
}