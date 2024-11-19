using Domain.Validators;

namespace Domain.ValueObjects;

/// <summary>
/// Электронная почта.
/// </summary>
public class Email: BaseValueObject
{
    public Email(string value)
    {
        Value = value;

        ValidateValueObject(new EmailValidator());
    }
    
    /// <summary>
    /// Значение электронной почты.
    /// </summary>
    public string Value { get; private set; }
}