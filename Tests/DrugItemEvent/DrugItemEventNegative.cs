using System.ComponentModel.DataAnnotations;
using Domain.Entities;

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
        var drugItem = new DrugItem(
            Guid.NewGuid(),
            Guid.NewGuid(),
            100.0m,
            10.0,
            new Drug(),
            new DrugStore()
        );
        var invalidCount = -5.0;
        
        var exception = Assert.Throws<ValidationException>(() =>
        {
            drugItem.UpdateDrugCount(invalidCount);
        });

        Assert.Contains("Новое кол-во препарата должно быть больше нуля", exception.Message);
        var domainEvents = drugItem.GetDomainEvents();
        Assert.Empty(domainEvents);
    }

}