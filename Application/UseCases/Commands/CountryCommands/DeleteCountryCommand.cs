using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

/// <summary>
/// Команда для удаления объекта Country.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record DeleteCountryCommand(Guid Id) : IRequest<bool>;