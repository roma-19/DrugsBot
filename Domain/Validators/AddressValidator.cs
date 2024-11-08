using Domain.ValueObjects;
using FluentValidation;
using static Domain.ValueObjects.CountryCodes;
namespace Domain.Validators;

/// <summary>
/// Валидатор для Address, который проверяет правильность написания улицы, города, почтового кода и кода страны.
/// </summary>
public class AddressValidator : AbstractValidator<Address>
{
    /// <summary>
    /// Конструктор AddressValidator, который задаёт правила валидации для Address.
    /// </summary>
    public AddressValidator()
    {
        RuleFor(a => a.Street)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .Length(3, 100).WithMessage(ValidationMessage.WrongLength);
        RuleFor(a => a.City)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .Length(2, 50).WithMessage(ValidationMessage.WrongLength);
        RuleFor(a => a.PostalCode)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .GreaterThanOrEqualTo(10000).WithMessage(ValidationMessage.WrongPostalCode)
            .LessThanOrEqualTo(999999).WithMessage(ValidationMessage.WrongPostalCode);
        RuleFor(a => a.CountryCode)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .Must(IsValidCountryCode).WithMessage(ValidationMessage.WrongCountryCodeId);
    }
    
}