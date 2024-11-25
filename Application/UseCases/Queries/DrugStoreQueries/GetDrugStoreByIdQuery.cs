using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries;

/// <summary>
/// Запрос для получения объекта DrugStore по идентификатору.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetDrugStoreByIdQuery(Guid Id) : IRequest<DrugStore?>;