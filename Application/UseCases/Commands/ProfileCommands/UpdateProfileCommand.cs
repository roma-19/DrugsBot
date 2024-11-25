using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

/// <summary>
/// Команда для обновления объекта Profile.
/// </summary>
/// <param name="Id">Идентификатор профиля.</param>
/// <param name="ExternalId">Внешний идентификатор.</param>
/// <param name="Email">Электронная почта.</param>
public record UpdateProfileCommand(
    Guid Id,
    string ExternalId,
    Email Email
    ) : IRequest<Profile?>;