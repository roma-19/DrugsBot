using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

/// <summary>
/// Команда для обновления обьекта DrugStore.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="DrugNetwork">Сеть аптек.</param>
/// <param name="Number">Номер аптеки.</param>
/// <param name="Address">Адрес.</param>
public record UpdateDrugStoreCommand(
    Guid Id,
    string DrugNetwork,
    int Number,
    Address Address
    ) : IRequest<DrugStore?>;