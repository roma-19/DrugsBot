using Application.Interfaces.Repositories.CountryRepository;
using Application.Interfaces.Repositories.DrugRepository;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

/// <summary>
/// Обработчик команды DeleteCountryCommand для удаления объекта Country.
/// </summary>
public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, bool>
{
    private readonly ICountryReadRepository _countryReadRepository;
    private readonly ICountryWriteRepository _countryWriteRepository;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="countryWriteRepository">Репозиторий для операций записи.</param>
    /// <param name="countryReadRepository">Репозиторий для операций чтения.</param>
    public DeleteCountryCommandHandler(ICountryWriteRepository countryWriteRepository, ICountryReadRepository countryReadRepository)
    {
        _countryWriteRepository = countryWriteRepository;
        _countryReadRepository = countryReadRepository;
    }
    
    /// <summary>
    /// Обрабатывает команду для удаления объекта Country.
    /// </summary>
    /// <param name="request">Команда DeleteCountryCommand для удаления объекта Country.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Возвращает true, если удаление прошло успешно, иначе False.</returns>
    public async Task<bool> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (country == null) throw new NullReferenceException();

        await _countryWriteRepository.DeleteAsync(request.Id, cancellationToken);

        return true;
    }
}