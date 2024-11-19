using Domain.Validators;
using Domain.ValueObjects;

namespace Domain.Entities;
/// <summary>
/// Аптека.
/// </summary>
public class DrugStore: BaseEntity<DrugStore>
{
    /// <summary>
    /// Конструктор без параметров.
    /// </summary>
    public DrugStore() {}
    
    /// <summary>
    /// Конструктор для инициализации аптеки.
    /// </summary>
    /// <param name="drugNetwork">Сеть аптек.</param>
    /// <param name="number">Номер аптеки.</param>
    /// <param name="address">Адрес аптеки.</param>
    public DrugStore(string drugNetwork, int number, Address? address)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Address = address;
        
        ValidateEntity(new DrugStoreValidator());
    }
    
    /// <summary>
    /// Сеть аптек.
    /// </summary>
    public string? DrugNetwork { get; private set; }
    
    /// <summary>
    /// Номер аптеки.
    /// </summary>
    public int Number { get; private set; }
    
    /// <summary>
    /// Адрес аптеки.
    /// </summary>
    public Address? Address { get; private set; }
    
    /// <summary>
    /// Навигационное свойство для связи с DrugItem.
    /// </summary>
    public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
    
}