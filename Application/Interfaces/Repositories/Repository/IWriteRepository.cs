namespace Application.Interfaces.Repositories;

/// <summary>
/// Интерфейс репозитория для записи.
/// </summary>
/// <typeparam name="T">Тип сущности.</typeparam>
public interface IWriteRepository<T> where T : class
{
    /// <summary>
    /// Репозиторий для операций чтения.
    /// </summary>
    /// <returns>Экземпляр репозитория для операций чтения.</returns>
    IReadRepository<T> ReadRepository { get; }
    
    /// <summary>
    /// Метод для добавления сущности.
    /// </summary>
    /// <param name="entity">Экземпляр сущности.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Задача, представляющая завершение операции обновления сущности.</returns>
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод для обновления сущности.
    /// </summary>
    /// <param name="entity">Экземпляр сущности.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Задача, представляющая завершение операции обновления сущности.</returns>
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Метод для удаления сущности.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Задача, представляющая завершение операции удаления сущности.</returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}