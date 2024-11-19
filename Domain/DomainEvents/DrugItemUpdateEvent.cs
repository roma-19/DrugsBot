using Domain.Interface;
using Domain.Validators;
using FluentValidation;

namespace Domain.DomainEvents;

/// <summary>
/// Доменное событие обновления единицы лекарства.
/// </summary>
public class DrugItemUpdateEvent : IDomainEvent
{
    /// <summary>
    /// Идентификатор препарата.
    /// </summary>
    public Guid DrugItemId { get; }
    
    /// <summary>
    /// Новое кол-во препарата.
    /// </summary>
    public double NewAmount { get; }

    /// <summary>
    /// Конструктор для инициализации.
    /// </summary>
    /// <param name="drugItemId">Идентификатор препарата.</param>
    /// <param name="newAmount">Новое кол-во препарата.</param>
    public DrugItemUpdateEvent(Guid drugItemId, double newAmount)
    {
        DrugItemId = drugItemId;
        NewAmount = newAmount;
        
        Validate();
    }
    
    private void Validate()
    {
        var validator = new DrugItemUpdateEventValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join("; ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
    
}