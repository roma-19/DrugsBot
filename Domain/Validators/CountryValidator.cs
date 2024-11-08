using Domain.Entities;
using FluentValidation;
namespace Domain.Validators;
/// <summary>
/// Валидатор для Country, который проверяет правильность написания имени и кода страны.
/// </summary>
public class CountryValidator : AbstractValidator<Country>
{
    /// <summary>
    /// Конструктор CountryValidator, который задаёт правила валидации для Country.
    /// </summary>
    public CountryValidator()
    {
        RuleFor(country => country.Name)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[A-Za-zА-Яа-яёЁ\s]+$").WithMessage(ValidationMessage.OnlyLettersAndSpaces);
        RuleFor(country => country.Code)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .Length(2, 2).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[A-Z]{2}$").WithMessage(ValidationMessage.OnlyTwoUpperLatinLetters);
    }
}