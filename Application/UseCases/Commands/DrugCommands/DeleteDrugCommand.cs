using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Команда для удаления объекта Drug.
/// </summary>
/// <param name="Id">Идентификатор</param>
public record DeleteDrugCommand(Guid Id) : IRequest<bool>;