using Domain.DomainEvents;
using FluentValidation;

namespace Domain.Validators;

/// <summary>
/// Валидатор для DrugItemUpdateEvent.
/// </summary>
public class DrugItemUpdateEventValidator: AbstractValidator<DrugItemUpdateEvent>
{
    /// <summary>
    /// Конструктор DrugItemUpdateEventValidator, который задаёт правила валидации для DrugItemUpdateEvent.
    /// </summary>
    public DrugItemUpdateEventValidator()
    {
        RuleFor(d => d.DrugItemId)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull);
        RuleFor(d => d.NewAmount)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .GreaterThan(0).WithMessage(ValidationMessage.NonNegativeInteger);
    }
}