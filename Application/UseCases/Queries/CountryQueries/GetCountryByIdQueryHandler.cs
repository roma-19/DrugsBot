using Application.Interfaces.Repositories.CountryRepository;
using Domain.Entities;

namespace Application.UseCases.Queries.CountryQueries;

/// <summary>
/// Обработчик запроса GetCountryByIdQuery для получения объекта Country по идентификатору.
/// </summary>
public class GetCountryByIdQueryHandler
{
    private readonly ICountryReadRepository _countryReadRepository;

    /// <summary>
    /// Инициализирует новый экземпляр GetCountryByIdQueryHandler.
    /// </summary>
    /// <param name="countryReadRepository">Репозиторий для операций чтения с сущностью Country.</param>
    public GetCountryByIdQueryHandler(ICountryReadRepository countryReadRepository)
    {
        _countryReadRepository = countryReadRepository;
    }
    
    /// <summary>
    /// Обрабатывает запрос для получения объекта Country по идентификатору.
    /// </summary>
    /// <param name="request">Запрос GetCountryByIdQuery, содержащий идентификатор страны.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект Country.</returns>
    public async Task<Country?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _countryReadRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}