using Domain.Validators;
using Domain.ValueObjects;

namespace Domain.Entities;

/// <summary>
/// Профиль.
/// </summary>
public class Profile : BaseEntity<Profile>
{
    /// <summary>
    /// Конструктор для инициализации профиля.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="externalId"></param>
    /// <param name="email"></param>
    public Profile(Guid id, string externalId, Email email)
    {
        Id = id;
        ExternalId = externalId;
        Email = email;
        
        ValidateEntity(new ProfileValidator());
    }
    
    /// <summary>
    /// Идентификатор профиля.
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Внешний идентификатор.
    /// </summary>
    public string ExternalId { get; private set; }
    
    /// <summary>
    /// Электронная почта.
    /// </summary>
    public Email Email { get; private set; }
    
    /// <summary>
    /// Навигационное свойство для связи с Favourite Drug.
    /// </summary>
    public List<FavouriteDrug> FavouriteDrugs { get; private set; }
}