using Domain.Validators;

namespace Domain.ValueObjects;

/// <summary>
/// Адрес.
/// </summary>
public class Address: BaseValueObject
{
    /// <summary>
    /// Конструктор для инициализации адреса.
    /// </summary>
    /// <param name="street">Улица.</param>
    /// <param name="city">Город.</param>
    /// <param name="house">Дом.</param>
    public Address(string street, string city, string house)
    {
        Street = street;
        City = city;
        House = house;
        
        ValidateValueObject(new AddressValidator());
    }
    
    /// <summary>
    /// Город.
    /// </summary>
    public string City { get; private set; }
    
    /// <summary>
    /// Улица.
    /// </summary>
    public string Street { get; private set; }
    
    /// <summary>
    /// Дом.
    /// </summary>
    public string House { get; private set; }
    
    /// <summary>
    /// Почтовый индекс.
    /// </summary>
    public int PostalCode { get; private set; }
    
    /// <summary>
    /// Код страны.
    /// </summary>
    public string CountryCode { get; private set; }
    
    /// <summary>
    /// Возвращает адрес в виде строки.
    /// </summary>
    /// <returns>Строка, представляющая адрес.</returns>
    public override string ToString()
    {
        return $"{City}, {Street}, {House}";
    }
}