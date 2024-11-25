using Application.Interfaces.Repositories.DrugRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugQueries;

/// <summary>
/// Обработчик запроса GetDrugByIdQuery для получения объекта Drug по идентификатору.
/// </summary>
public class GetDrugByIdQueryHandler : IRequestHandler<GetDrugByIdQuery, Drug?>
{
    private readonly IDrugReadRepository _drugReadRepository;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="drugReadRepository">Репозиторий для операций чтения.</param>
    public GetDrugByIdQueryHandler(IDrugReadRepository drugReadRepository)
    {
        _drugReadRepository = drugReadRepository;
    }
    
    /// <summary>
    /// Обрабатывает запрос для получения объекта Drug по идентификатору.
    /// </summary>
    /// <param name="request">Запрос GetDrugByIdQuery, содержащий идентификатор лекарства.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект Drug.</returns>
    public async Task<Drug?> Handle(GetDrugByIdQuery request, CancellationToken cancellationToken)
    {
        return await _drugReadRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}