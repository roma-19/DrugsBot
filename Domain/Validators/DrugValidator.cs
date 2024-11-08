using Domain.Entities;
using FluentValidation;
using static Domain.ValueObjects.CountryCodes;

namespace Domain.Validators;
/// <summary>
/// Валидатор для Drug, который проверяет правильность написания его названия, производителя и кода страны.
/// </summary>
public class DrugValidator : AbstractValidator<Drug>
{
    /// <summary>
    /// Конструктор DrugValidator, который задает правила валидации для Drug.
    /// </summary>
    public DrugValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 150).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[A-Za-zА-Яа-яёЁ0-9]+$").WithMessage(ValidationMessage.NoSpecialCharacters);
        RuleFor(m => m.Manufacturer)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[A-Za-zА-Яа-яёЁ\s-]+$").WithMessage(ValidationMessage.OnlyLettersSpacesAndHyphen);
        RuleFor(d => d.CountryCodeId)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .Matches(@"^[A-Z]{2}$").WithMessage(ValidationMessage.OnlyTwoUpperLatinLetters)
            .Must(IsValidCountryCode).WithMessage(ValidationMessage.WrongCountryCodeId);
    }
}