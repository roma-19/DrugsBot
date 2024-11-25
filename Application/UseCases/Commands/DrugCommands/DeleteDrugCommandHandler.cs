using Application.Interfaces.Repositories.DrugRepository;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Обработчик команды DeleteDrugCommand для удаления объекта Drug.
/// </summary>
public class DeleteDrugCommandHandler : IRequestHandler<DeleteDrugCommand, bool>
{
    private readonly IDrugReadRepository _drugReadRepository;
    private readonly IDrugWriteRepository _drugWriteRepository;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="drugWriteRepository">Репозиторий для операций записи.</param>
    /// <param name="drugReadRepository">Репозиторий для операций чтения.</param>
    public DeleteDrugCommandHandler(IDrugWriteRepository drugWriteRepository, IDrugReadRepository drugReadRepository)
    {
        _drugWriteRepository = drugWriteRepository;
        _drugReadRepository = drugReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду для удаления объекта Drug.
    /// </summary>
    /// <param name="request">Команда DeleteDrugCommand для удаления объекта Drug.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Возвращает true, если удаление прошло успешно, иначе False.</returns>
    public async Task<bool> Handle(DeleteDrugCommand request, CancellationToken cancellationToken)
    {
        var drug = await _drugReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (drug == null) throw new NullReferenceException();

        await _drugWriteRepository.DeleteAsync(request.Id, cancellationToken);

        return true;
    }
}