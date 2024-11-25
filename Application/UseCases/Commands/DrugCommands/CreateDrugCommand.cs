using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Команда для создания нового объекта Drug.
/// </summary>
/// <param name="Name">Название лекарства.</param>
/// <param name="Manufacturer">Производитель лекарства.</param>
/// <param name="CountryCodeId">Код страны.</param>
/// <param name="Country">Страна.</param>
public record CreateDrugCommand(
    string Name,
    string Manufacturer,
    string CountryCodeId,
    Country Country) : IRequest<Drug?>;
