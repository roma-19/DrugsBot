using Domain.DomainEvents;
using FluentValidation;

namespace Tests.DrugItemEvent;

/// <summary>
/// Негативные тесты для DrugItemUpdateEvent.
/// </summary>
public class DrugItemEventNegative
{
    /// <summary>
    /// Проверка, что при некорректных данных событие не добавляется в список.
    /// </summary>
    [Fact]
    public void UpdateDrugCount_ShouldNotAddDomainEvent_WhenCountIsInvalid()
    {
        var drugItemId = Guid.Empty;
        var newAmount = -5;
        
        Assert.Throws<ValidationException>(() => new DrugItemUpdateEvent(drugItemId, newAmount));
    }
}