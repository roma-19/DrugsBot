using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

/// <summary>
/// Команда для удаления объекта Profile.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record DeleteProfileCommand(Guid Id) : IRequest<bool>;