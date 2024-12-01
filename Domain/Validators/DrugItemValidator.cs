using Domain.Entities;
using FluentValidation;
namespace Domain.Validators;
/// <summary>
/// Валидатор для DrugItem, который проверяет правильность написания цены и количества.
/// </summary>
public class DrugItemValidator: AbstractValidator<DrugItem>
{
    /// <summary>
    /// Конструктор DrugItemValidator, который задаёт правила валидации для DrugItem.
    /// </summary>
    public DrugItemValidator()
    {
        RuleFor(d => d.Cost)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.NonNegativeInteger)
            .Must(IsValidDecimal).WithMessage(ValidationMessage.WrongDecimalFormat);
        RuleFor(d => d.Count)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.NonNegativeInteger)
            .LessThanOrEqualTo(10000).WithMessage(ValidationMessage.WrongCount);
    }
    
    /// <summary>
    /// Метод, который проверяет цену на правильный формат (не более 2 значений после запятой).
    /// </summary>
    /// <param name="amount">Цена.</param>
    /// <returns>True, если после запятой не больше 2 значений; иначе False.</returns>
    private bool IsValidDecimal(decimal amount)
    {
        return (amount * 100 % 1 == 0);
    }
}