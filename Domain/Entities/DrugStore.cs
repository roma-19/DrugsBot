using Domain.ValueObjects;

namespace Domain.Entities;
/// <summary>
/// Аптека.
/// </summary>
public class DrugStore: BaseEntity
{
    /// <summary>
    /// Сеть аптек.
    /// </summary>
    public string? DrugNetwork { get; set; }
    
    /// <summary>
    /// Номер аптеки.
    /// </summary>
    public int Number { get; set; }
    
    /// <summary>
    /// Адрес аптеки.
    /// </summary>
    public Address? Address { get; set; }
    
    /// <summary>
    /// Навигационное свойство для связи с DrugItem.
    /// </summary>
    public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
    
    /// <summary>
    /// Конструктор для инициализации аптеки.
    /// </summary>
    /// <param name="drugNetwork">сеть аптек.</param>
    /// <param name="number">номер аптеки.</param>
    /// <param name="address">адрес аптеки.</param>
    public DrugStore(string drugNetwork, int number, Address? address)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Address = address;
    }
}