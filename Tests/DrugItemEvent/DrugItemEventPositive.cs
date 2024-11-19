using Domain.DomainEvents;
using Domain.Entities;

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
        var drugItem = new DrugItem(
            Guid.NewGuid(),
            Guid.NewGuid(),
            100,
            10,
            new Drug(),
            new DrugStore()
        );
        var newCount = 15.0;
        
        drugItem.UpdateDrugCount(newCount);
        
        var domainEvents = drugItem.GetDomainEvents();
        Assert.NotEmpty(domainEvents);
        
        var updateEvent = domainEvents.OfType<DrugItemUpdateEvent>().FirstOrDefault();
        Assert.NotNull(updateEvent);
        Assert.Equal(drugItem.Id, updateEvent.DrugItemId);
        Assert.Equal(newCount, updateEvent.NewAmount);
    }
}