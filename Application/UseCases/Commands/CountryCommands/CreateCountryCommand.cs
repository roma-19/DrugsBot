using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

/// <summary>
/// Команда для создания нового объекта Country.
/// </summary>
/// <param name="Name">Название страны.</param>
/// <param name="Code">Код старны.</param>
public record CreateCountryCommand(
    string Name,
    string Code) : IRequest<Country?>;