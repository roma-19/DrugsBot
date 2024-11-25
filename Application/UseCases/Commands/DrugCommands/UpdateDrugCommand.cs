using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Команда для обновления обьекта Drug.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Название лекарства.</param>
/// <param name="Manufacturer">Производитель лекарства.</param>
/// <param name="CountryCodeId">Код страны.</param>
/// <param name="Country">Страна.</param>
public record UpdateDrugCommand(
    Guid Id,
    string Name,
    string Manufacturer,
    string CountryCodeId,
    Country Country
) : IRequest<Drug?>;