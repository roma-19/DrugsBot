namespace Domain.Validators;
/// <summary>
/// Класс, содержащий сообщения об ошибках.
/// </summary>
public static class ValidationMessage
{
    /// <summary>
    /// Сообщение об ошибке, если значение является Null.
    /// </summary>
    public static readonly string NotNull = "{PropertyName} не может быть Null";
    
    /// <summary>
    /// Сообщение об ошибке, если значение является пустым.
    /// </summary>
    public static readonly string NotEmpty = "{PropertyName} не может быть пустым";
    
    /// <summary>
    /// Сообщение об ошибке, если длина значения не входит в допустимый диапазон. 
    /// </summary>
    public static readonly string WrongLength = "{PropertyName должен быть от {min} до {max} символов}";
    
    /// <summary>
    /// Сообщение об ошибке, если у значения неверный формат (только буквы и пробелы).
    /// </summary>
    public static readonly string OnlyLettersAndSpaces = "{PropertyName} должен содержать только буквы";
    
    /// <summary>
    /// Сообщение об ошибке, если у значения неверный формат (только 2 заглавные латинские буквы).
    /// </summary>
    public static readonly string OnlyTwoUpperLatinLetters = "{PropertyName} должен содержать только две заглавные латинские буквы";

    /// <summary>
    /// Сообщение об ошибке, если у значения неверный формат (без специальных символов).
    /// </summary>
    public static readonly string NoSpecialCharacters = "{PropertyName} не должен содержать специальных символов";
    
    /// <summary>
    /// Сообщение об ошибке, если у значения неверный формат (только буквы, пробелы и дефис).
    /// </summary>
    public static readonly string OnlyLettersSpacesAndHyphen = "{PropertyName} должен содержать только буквы";

    /// <summary>
    /// Сообщение об ошибке, если значение является отрицательным.
    /// </summary>
    public static readonly string NonNegativeInteger = "{PropertyName} не должен быть отрицательным";

    /// <summary>
    /// Сообщение об ошибке, если значение больше 10 000.
    /// </summary>
    public static readonly string WrongCount = "{PropertyName} не должен быть больше 10 000";
    
    /// <summary>
    /// Сообщение об ошибке, если значение не имеет 5-6 символов.
    /// </summary>
    public static readonly string WrongPostalCode = "{PropertyName} должен содержать 5-6 числовых символов";

    /// <summary>
    /// Сообщение об ошибке, если значение отсутствует в справочнике стран.
    /// </summary>
    public static readonly string WrongCountryCodeId = "{PropertyName} должен быть в справочнике стран";

    /// <summary>
    /// Сообщение об ошибке, если у значения больше двух значений после запятой.
    /// </summary>
    public static readonly string WrongDecimalFormat = "{PropertyName} не должень иметь больше 2 значений после запятой";
}