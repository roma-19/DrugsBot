using Application.Interfaces.Repositories.CountryRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

/// <summary>
/// Обработчик команды UpdateCountryCommand для обновления объекта Country.
/// </summary>
public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Country?>
{
    private readonly ICountryReadRepository _countryReadRepository;
    private readonly ICountryWriteRepository _countryWriteRepository;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="countryWriteRepository">Репозиторий для операций записи.</param>
    /// <param name="countryReadRepository">Репозиторий для операций чтения.</param>
    public UpdateCountryCommandHandler(ICountryWriteRepository countryWriteRepository, ICountryReadRepository countryReadRepository)
    {
        _countryWriteRepository = countryWriteRepository;
        _countryReadRepository = countryReadRepository;
    }
    
    /// <summary>
    /// Обрабатывает команду для обновления объекта Country.
    /// </summary>
    /// <param name="request">Команда UpdateCountryCommand, содержащая данные для обновления страны.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновленный объект Country или null при неудаче.</returns>
    public async Task<Country?> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (country == null) throw new NullReferenceException();

        country.Name = request.Name;
        country.Code = request.Code;

        await _countryWriteRepository.UpdateAsync(country, cancellationToken);

        return country;
    }
}