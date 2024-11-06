namespace Domain.Entities;

/// <summary>
/// Лекарственный препарат.
/// </summary>
public class DrugItem : BaseEntity
{
    /// <summary>
    /// Идентификатор препарата.
    /// </summary>
    public Guid DrugId { get; set; }
    
    /// <summary>
    /// Идентификатор аптеки.
    /// </summary>
    public Guid DrugStoreId { get; set; }
    
    /// <summary>
    /// Стоимость препарата.
    /// </summary>
    public decimal Cost { get; set; }
    
    /// <summary>
    /// Количество препарата.
    /// </summary>
    public int Count { get; set; }
    
    /// <summary>
    /// Навигационное свойство для связи с Drug.
    /// </summary>
    public Drug Drug { get; private set; }
    
    /// <summary>
    /// Навигационное свойство для связи с DrugStore.
    /// </summary>
    public DrugStore DrugStore { get; private set; }
    
    /// <summary>
    /// Конструктор для инициализации лекарственного препарата.
    /// </summary>
    /// <param name="drugId">идентификатор препарата.</param>
    /// <param name="drugStoreId">идентификатор аптеки.</param>
    /// <param name="cost">стоимотсть препарата.</param>
    /// <param name="count">количество препарата.</param>
    /// <param name="drug">лекарство.</param>
    /// <param name="drugStore">аптека.</param>
    public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, int count, Drug drug, DrugStore drugStore)
    {
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Cost = cost;
        Count = count;
        Drug = drug;
        DrugStore = drugStore;
    }
}