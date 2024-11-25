using Application.Interfaces.Repositories.DrugStoreRepository;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

/// <summary>
/// Обработчик команды DeleteDrugStoreCommand для удаления объекта DrugStore.
/// </summary>
public class DeleteDrugStoreCommandHandler : IRequestHandler<DeleteDrugStoreCommand, bool>
{
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;
    
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="drugStoreWriteRepository">Репозиторий для операций записи.</param>
    /// <param name="drugStoreReadRepository">Репозиторий для операций чтения.</param>
    public DeleteDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository, IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
        _drugStoreReadRepository = drugStoreReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду для удаления объекта DrugStore.
    /// </summary>
    /// <param name="request">Команда DeleteDrugStoreCommand для удаления объекта DrugStore.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Возвращает true, если удаление прошло успешно, иначе False.</returns>
    public async Task<bool> Handle(DeleteDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = await _drugStoreReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (drugStore == null) throw new NullReferenceException();

        await _drugStoreWriteRepository.DeleteAsync(request.Id, cancellationToken);

        return true;
    }
}