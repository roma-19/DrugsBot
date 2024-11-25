using Application.Interfaces.Repositories.DrugStoreRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

/// <summary>
/// Обработчик команды UpdateDrugStoreCommand для обновления объекта DrugStore.
/// </summary>
public class UpdateDrugStoreCommandHandler : IRequestHandler<UpdateDrugStoreCommand, DrugStore?>
{
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;
    
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="drugStoreWriteRepository">Репозиторий для операций записи.</param>
    /// <param name="drugStoreReadRepository">Репозиторий для операций чтения.</param>
    public UpdateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository, IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
        _drugStoreReadRepository = drugStoreReadRepository;
    }
    
    /// <summary>
    /// Обрабатывает команду для обновления объекта DrugStore.
    /// </summary>
    /// <param name="request">Команда UpdateDrugStoreCommand, содержащая данные для обновления аптеки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновленный объект DrugStore или null при неудаче.</returns>
    public async Task<DrugStore?> Handle(UpdateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = await _drugStoreReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (drugStore == null) throw new NullReferenceException();

        drugStore.DrugNetwork = request.DrugNetwork;
        drugStore.Number = request.Number;
        drugStore.Address = request.Address;

        await _drugStoreWriteRepository.UpdateAsync(drugStore, cancellationToken);

        return drugStore;
    }
}