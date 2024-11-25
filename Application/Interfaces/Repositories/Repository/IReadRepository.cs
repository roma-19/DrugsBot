using Microsoft.AspNetCore.OData.Query;

namespace Application.Interfaces.Repositories;

/// <summary>
/// Интерфейс репозитория для чтения.
/// </summary>
/// <typeparam name="T">Тип сущности.</typeparam>
public interface IReadRepository<T> where T : class
{
    /// <summary>
    /// Получение сущности по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Сущность.</returns>
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    
    /// <summary>
    /// Получение запросов с помощью Odata.
    /// </summary>
    /// <param name="queryOptions">Опции запроса OData.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Запрос.</returns>
    Task<IQueryable> GetQueryableAsync(ODataQueryOptions<T> queryOptions, CancellationToken cancellationToken = default);
}