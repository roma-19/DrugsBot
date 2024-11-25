using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

/// <summary>
/// Команда для удаления объекта DrugStore.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record DeleteDrugStoreCommand(Guid Id) : IRequest<bool>;