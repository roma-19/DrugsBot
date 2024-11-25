using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.CountryQueries;

/// <summary>
/// Запрос для получения объекта Country по идентификатору.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetCountryByIdQuery(Guid Id) : IRequest<Country?>;