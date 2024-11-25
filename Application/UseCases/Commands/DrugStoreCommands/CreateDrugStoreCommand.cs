using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

/// <summary>
/// Команда для создания нового объекта DrugStore.
/// </summary>
/// <param name="DrugNetwork">Сеть аптек.</param>
/// <param name="Number">Номер аптеки.</param>
/// <param name="Address">Адрес аптеки.</param>
public record CreateDrugStoreCommand(
    string DrugNetwork,
    int Number,
    Address Address) : IRequest<DrugStore?>;