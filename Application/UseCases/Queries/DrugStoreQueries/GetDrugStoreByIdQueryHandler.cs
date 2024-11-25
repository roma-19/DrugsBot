using Application.Interfaces.Repositories.DrugStoreRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries;

/// <summary>
/// Обработчик запроса GetDrugStoreByIdQuery для получения объекта DrugStore по идентификатору.
/// </summary>
public class GetDrugStoreByIdQueryHandler : IRequestHandler<GetDrugStoreByIdQuery, DrugStore?>
{
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;

    /// <summary>
    /// Конструтор.
    /// </summary>
    /// <param name="drugStoreReadRepository">Репозиторий для операций чтения.</param>
    public GetDrugStoreByIdQueryHandler(IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugStoreReadRepository = drugStoreReadRepository;
    }
    
    /// <summary>
    /// Обрабатывает запрос для получения объекта DrugStore по идентификатору.
    /// </summary>
    /// <param name="request">Запрос GetDrugStoreByIdQuery, содержащий идентификатор аптеки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект DrugStore.</returns>
    public async Task<DrugStore?> Handle(GetDrugStoreByIdQuery request, CancellationToken cancellationToken)
    {
        return await _drugStoreReadRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}