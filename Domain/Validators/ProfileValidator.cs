using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

/// <summary>
/// Валидатор для Profile.
/// </summary>
public class ProfileValidator: AbstractValidator<Profile>
{
    /// <summary>
    /// Конструктор ProfileValidator, который задаёт правила валидации для Profile.
    /// </summary>
    public ProfileValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull);
        RuleFor(p => p.ExternalId)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull);
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull);
    }
}