using Application.Interfaces.Repositories.ProfileRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

/// <summary>
/// Обработчик команды UpdateProfileCommand для обновления объекта Profile.
/// </summary>
public class UpdateProfileCommandHandler: IRequestHandler<UpdateProfileCommand, Profile?>
{
    private readonly IProfileReadRepository _profileReadRepository;
    private readonly IProfileWriteRepository _profileWriteRepository;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="profileWriteRepository">Репозиторий для операций записи.</param>
    /// <param name="profileReadRepository">Репозиторий для операций чтения.</param>
    public UpdateProfileCommandHandler(IProfileWriteRepository profileWriteRepository, IProfileReadRepository profileReadRepository)
    {
        _profileWriteRepository = profileWriteRepository;
        _profileReadRepository = profileReadRepository;
    }
    
    /// <summary>
    /// Обрабатывает команду для обновления объекта Profile.
    /// </summary>
    /// <param name="request">Команда UpdateProfileCommand, содержащая данные для обновления профиля.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновленный объект Profile или null при неудаче.</returns>
    public async Task<Profile?> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await _profileReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (profile == null) throw new NullReferenceException();

        profile.Id = request.Id;
        profile.ExternalId = request.ExternalId;
        profile.Email = request.Email;

        await _profileWriteRepository.UpdateAsync(profile, cancellationToken);

        return profile;
    }
}