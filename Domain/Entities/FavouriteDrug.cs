using Domain.Validators;

namespace Domain.Entities;

/// <summary>
/// Любимое лекарство.
/// </summary>
public class FavouriteDrug : BaseEntity<FavouriteDrug>
{
    /// <summary>
    /// Конструктор для инициализации любимого лекарства.
    /// </summary>
    /// <param name="id">Идентификатор любимого лекарства.</param>
    /// <param name="profileId">Идентификатор профиля.</param>
    /// <param name="drugId">Идентификатор лекарства.</param>
    /// <param name="drug">Лекарство.</param>
    /// <param name="drugStoreId">Идентификатор аптек.</param>
    /// <param name="drugStore">Аптека.</param>
    /// <param name="profile">Профиль.</param>
    public FavouriteDrug(
        Guid id,
        Guid profileId,
        Guid drugId,
        Drug drug,
        Guid? drugStoreId,
        DrugStore? drugStore,
        Profile profile)
    {
        Id = id;
        ProfileId = profileId;
        DrugId = drugId;
        Drug = drug;
        DrugStoreId = drugStoreId;
        DrugStore = drugStore;
        Profile = profile;
        
        ValidateEntity(new FavouriteDrugValidator());
    }
    
    /// <summary>
    /// Идентификатор любимого лекарства.
    /// </summary>
    public Guid Id {get; private set;}
    
    /// <summary>
    /// Идентификатор профиля.
    /// </summary>
    public Guid ProfileId { get; private set; }
    
    /// <summary>
    /// Идентификатор лекарства.
    /// </summary>
    public Guid DrugId { get; private set; }
    
    /// <summary>
    /// Идентификатор аптеки.
    /// </summary>
    public Guid? DrugStoreId { get; private set; }
    
    /// <summary>
    /// Навигационное свойство для связи с Drug.
    /// </summary>
    public Drug Drug { get; private set; }
    
    /// <summary>
    /// Навигационное свойство для связи с DrugStore.
    /// </summary>
    public DrugStore? DrugStore { get; private set; }
    
    /// <summary>
    /// Навигационное свойство для связи с Profile.
    /// </summary>
    public Profile Profile { get; private set; }
}