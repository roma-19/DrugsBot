using Domain.DomainEvents;
using Domain.Entities;
using FluentAssertions;

namespace Tests.DrugItemEvent;

/// <summary>
/// Позитивные тесты для DrugItemUpdateEvent.
/// </summary>
public class DrugItemEventPositive
{
    /// <summary>
    /// Проверка добавления нового доменного события в список при валидных данных.
    /// </summary>
    [Fact]
    public void UpdateDrugCount_ShouldAddDomainEvent_WhenDataIsValid()
    {
        var drugItemId = Guid.NewGuid();
        var newAmount = 10;
        
        var drugItemUpdateEvent = new DrugItemUpdateEvent(drugItemId, newAmount);
        
        Assert.NotNull(drugItemUpdateEvent);
        Assert.Equal(drugItemId, drugItemUpdateEvent.DrugItemId);
        Assert.Equal(newAmount, drugItemUpdateEvent.NewAmount);
    }
}