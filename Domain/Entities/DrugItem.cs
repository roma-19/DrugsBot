using Domain.DomainEvents;
using Domain.Validators;

namespace Domain.Entities;

/// <summary>
/// Лекарственный препарат.
/// </summary>
public class DrugItem : BaseEntity<DrugItem>
{
    /// <summary>
    /// Конструктор для инициализации лекарственного препарата.
    /// </summary>
    /// <param name="drugId">Идентификатор препарата.</param>
    /// <param name="drugStoreId">Идентификатор аптеки.</param>
    /// <param name="cost">Стоимость препарата.</param>
    /// <param name="count">Количество препарата.</param>
    /// <param name="drug">Лекарство.</param>
    /// <param name="drugStore">Аптека.</param>
    public DrugItem(
        Guid drugId,
        Guid drugStoreId,
        decimal cost,
        double count,
        Drug drug,
        DrugStore drugStore)
    {
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Cost = cost;
        Count = count;
        Drug = drug;
        DrugStore = drugStore;
        
        ValidateEntity(new DrugItemValidator());
    }
    
    /// <summary>
    /// Идентификатор препарата.
    /// </summary>
    public Guid DrugId { get; private set; }
    
    /// <summary>
    /// Идентификатор аптеки.
    /// </summary>
    public Guid DrugStoreId { get; private set; }
    
    /// <summary>
    /// Стоимость препарата.
    /// </summary>
    public decimal Cost { get; private set; }
    
    /// <summary>
    /// Количество препарата.
    /// </summary>
    public double Count { get; private set; }
    
    /// <summary>
    /// Навигационное свойство для связи с Drug.
    /// </summary>
    public Drug Drug { get; private set; }
    
    /// <summary>
    /// Навигационное свойство для связи с DrugStore.
    /// </summary>
    public DrugStore DrugStore { get; private set; }
    
    /// <summary>
    /// Обновление количества препарата на складе.
    /// </summary>
    /// <param name="count">Количество.</param>
    public void UpdateDrugCount(double count)
    {
        Count += count;
        
        AddDomainEvent(new DrugItemUpdateEvent(this.Id, count));
        
        ValidateEntity(new DrugItemValidator());
    }
}