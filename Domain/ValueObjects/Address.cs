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
    /// Почтовый индекс.
    /// </summary>
    public int PostalCode { get; set; }
    
    /// <summary>
    /// Код страны.
    /// </summary>
    public string CountryCode { get; set; }
    
    /// <summary>
    /// Конструктор для инициализации адреса.
    /// </summary>
    /// <param name="street">улица.</param>
    /// <param name="city">город.</param>
    /// <param name="postalCode">почтовый индекс.</param>
    /// <param name="countryCode">код страны.</param>
    public Address(string street, string city, int postalCode, string countryCode)
    {
        Street = street;
        City = city;
        PostalCode = postalCode;
        CountryCode = countryCode;
    }
    
    /// <summary>
    /// Возвращает адрес в виде строки.
    /// </summary>
    /// <returns>Строка, представляющая адрес.</returns>
    public override string ToString()
    {
        return $"{City}, {Street}, {PostalCode}, {CountryCode}";
    }
}