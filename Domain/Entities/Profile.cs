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
    /// <param name="id">Идентификатор профиля.</param>
    /// <param name="externalId">Внешний идентификатор.</param>
    /// <param name="email">Электронная почта.</param>
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
    public Guid Id { get; set; }
    
    /// <summary>
    /// Внешний идентификатор.
    /// </summary>
    public string ExternalId { get; set; }
    
    /// <summary>
    /// Электронная почта.
    /// </summary>
    public Email Email { get; set; }
    
    /// <summary>
    /// Навигационное свойство для связи с Favourite Drug.
    /// </summary>
    public List<FavouriteDrug> FavouriteDrugs { get; private set; }
}