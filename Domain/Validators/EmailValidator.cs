using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validators;

/// <summary>
/// Валидатор для Email, который проверяет правильность написания электронной почты.
/// </summary>
public class EmailValidator : AbstractValidator<Email>
{
    /// <summary>
    /// Конструктор EmailValidator, который задаёт правила валидации для Email.
    /// </summary>
    public EmailValidator()
    {
        RuleFor(e => e.Value)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .Length(7, 255).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$").WithMessage(ValidationMessage.WrongEmail);
    }
}