using Application.Interfaces.Repositories.DrugStoreRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands;

/// <summary>
/// Обработчик команды CreateDrugStoreCommand для создания нового объекта DrugStore.
/// </summary>
public class CreateDrugStoreCommandHandler : IRequestHandler<CreateDrugStoreCommand, DrugStore?>
{
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;

    /// <summary>
    /// Конструтор.
    /// </summary>
    /// <param name="drugStoreWriteRepository">Репозиторий для операций записи.</param>
    public CreateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
    }
    
    /// <summary>
    /// Обрабатывает команду для создания нового объекта DrugStore.
    /// </summary>
    /// <param name="request">Команда CreateDrugStoreCommand, содержащая данные для создания аптеки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Созданный объект DrugStore.</returns>
    public async Task<DrugStore?> Handle(CreateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = new DrugStore(
            request.DrugNetwork,
            request.Number,
            request.Address
        );
        
        await _drugStoreWriteRepository.AddAsync(drugStore, cancellationToken);
        
        return drugStore;
    }
}