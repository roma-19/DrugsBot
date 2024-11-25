using Application.Interfaces.Repositories.ProfileRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

/// <summary>
/// Обработчик команды CreateProfileCommand для создания нового объекта Profile.
/// </summary>
public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, Profile?>
{
    private readonly IProfileWriteRepository _profileWriteRepository;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="profileWriteRepository">Репозиторий для операций записи.</param>
    public CreateProfileCommandHandler(IProfileWriteRepository profileWriteRepository)
    {
        _profileWriteRepository = profileWriteRepository;
    }
    
    /// <summary>
    /// Обрабатывает команду для создания нового объекта Profile.
    /// </summary>
    /// <param name="request">Команда CreateProfileCommand, содержащая данные для создания профиля.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Созданный объект Profile.</returns>
    public async Task<Profile?> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = new Profile(
            request.Id,
            request.ExternalId,
            request.Email
        );
        
        await _profileWriteRepository.AddAsync(profile, cancellationToken);
        
        return profile;
    }
}