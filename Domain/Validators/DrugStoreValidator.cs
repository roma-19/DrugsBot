using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;
 /// <summary>
 /// Валидатор для DrugStore, который проверяет правильность написания сети аптеки и ее номер.
 /// </summary>
public class DrugStoreValidator : AbstractValidator<DrugStore>
{
    /// <summary>
    /// Конструктор DrugStoreValidator, который задаёт правила валидации для DrugStore.
    /// </summary>
    public DrugStoreValidator()
    {
        RuleFor(s => s.DrugNetwork)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength);
        RuleFor(s => s.Number)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.NonNegativeInteger);
    }
}