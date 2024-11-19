using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

/// <summary>
/// Валидатор для FavouriteDrug.
/// </summary>
public class FavouriteDrugValidator : AbstractValidator<FavouriteDrug>
{
    /// <summary>
    /// Конструктор FavouriteDrugValidator, который задаёт правила валидации для FavouriteDrug.
    /// </summary>
    public FavouriteDrugValidator()
    {
        RuleFor(f => f.Id)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull);
        RuleFor(f => f.ProfileId)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull);
        RuleFor(f => f.DrugId)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull);
        RuleFor(f => f.Drug)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull);
        RuleFor(f => f.DrugStoreId)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull);
        RuleFor(f => f.DrugStore)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull);
        RuleFor(f => f.Profile)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull);
    }
}