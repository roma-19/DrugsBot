using Domain.Interface;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Domain.Entities;

/// <summary>
/// Абстрактный класс сущности.
/// </summary>
public abstract class BaseEntity<T> where T : BaseEntity<T>
{
    
    /// <summary>
    /// Уникальный идентификатор сущности.
    /// </summary>
    public Guid Id { get; protected set; }
    
    /// <summary>
    /// Конструктор по умолчанию, который инициализирует новый уникальный идентификатор.
    /// </summary>
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }
    
    /// <summary>
    /// Выполняет валидацию сущности с использованием указанного валидатора.
    /// </summary>
    /// <param name="validator">Валидатор FluentValidator.</param>
    protected void ValidateEntity(AbstractValidator<T> validator)
    {
        var validationResult = validator.Validate((T)this);
        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException(errorMessages);
        }
    }
    
    /// <summary>
    /// Список для хранения доменных событий.
    /// </summary>
    private readonly List<IDomainEvent> _domainEvents = [];
    
    /// <summary>
    /// Получиение доменных событий.
    /// </summary>
    /// <returns>Список доменных событий.</returns>
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.AsReadOnly();
    }
    
    /// <summary>
    /// Добавление доменного события.
    /// </summary>
    /// <param name="domainEvent">Доменное событие.</param>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Очистка доменных событий.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
    
    /// <summary>
    /// Переопределение метода Equals для сравнения сущностей по идентификатору.
    /// </summary>
    /// <param name="obj">Объект для сравнения.</param>
    /// <returns>True, если идентификаторы совпадают; иначе False.</returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is null || obj.GetType() != GetType())
            return false;
        var other = (BaseEntity<T>)obj;
        return Id.Equals(other.Id);
    }
    
    /// <summary>
    /// Переопределение метода GetHashCode
    /// </summary>
    /// <returns>Хеш-код идентификатора.</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    /// <summary>
    /// Оператор сравнения на равенство по идентификатору.
    /// </summary>
    /// <param name="left">Левая сущность.</param>
    /// <param name="right">Правая сущность.</param>
    /// <returns>True, если идентификаторы равны; иначе False.</returns>
    public static bool operator ==(BaseEntity<T> left, BaseEntity<T> right)
    {
        if (left is null)
            return right is null;
        return left.Equals(right);
    }

    /// <summary>
    /// Оператор сравнения на неравенство по идентификатору.
    /// </summary>
    /// <param name="left">Левая сущность.</param>
    /// <param name="right">Правая сущность.</param>
    /// <returns>True, если идентификаторы не равны; иначе False.</returns>
    public static bool operator !=(BaseEntity<T> left, BaseEntity<T> right)
    {
        return !(left == right);
    }
}