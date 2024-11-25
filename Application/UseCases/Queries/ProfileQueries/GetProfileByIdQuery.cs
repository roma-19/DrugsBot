using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.ProfileQueries;

/// <summary>
/// Запрос для получения объекта Profile по идентификатору.
/// </summary>
/// <param name="Id">Идентификатор</param>
public record GetProfileByIdQuery(Guid Id) : IRequest<Profile?>;