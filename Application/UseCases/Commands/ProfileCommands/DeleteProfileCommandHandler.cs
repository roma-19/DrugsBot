using Application.Interfaces.Repositories.ProfileRepository;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands;

/// <summary>
/// Обработчик команды DeleteProfileCommand для удаления объекта Profile.
/// </summary>
public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, bool>
{
    private readonly IProfileReadRepository _profileReadRepository;
    private readonly IProfileWriteRepository _profileWriteRepository;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="profileWriteRepository">Репозиторий для операций записи.</param>
    /// <param name="profileReadRepository">Репозиторий для операций чтения.</param>
    public DeleteProfileCommandHandler(IProfileWriteRepository profileWriteRepository, IProfileReadRepository profileReadRepository)
    {
        _profileWriteRepository = profileWriteRepository;
        _profileReadRepository = profileReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду для удаления объекта Profile.
    /// </summary>
    /// <param name="request">Команда DeleteProfileCommand для удаления объекта Profile.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Возвращает true, если удаление прошло успешно, иначе False.</returns>
    public async Task<bool> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await _profileReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (profile == null) throw new NullReferenceException();

        await _profileWriteRepository.DeleteAsync(request.Id, cancellationToken);

        return true;
    }
}