using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugQueries;

/// <summary>
/// Запрос для получения объекта Drug по идентификатору.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetDrugByIdQuery(Guid Id) : IRequest<Drug?>;