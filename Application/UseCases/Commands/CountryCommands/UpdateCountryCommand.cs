using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

/// <summary>
/// Команда для обновления обьекта Country.
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Название страны.</param>
/// <param name="Code">Код страны.</param>
public record UpdateCountryCommand(
    Guid Id,
    string Name,
    string Code
    ) : IRequest<Country?>;