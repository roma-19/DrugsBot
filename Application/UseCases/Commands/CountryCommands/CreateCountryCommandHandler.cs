using Application.Interfaces.Repositories.CountryRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands;

/// <summary>
/// Обработчик команды CreateCountryCommand для создания нового объекта Country.
/// </summary>
public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Country?>
{
    private readonly ICountryWriteRepository _countryWriteRepository;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="countryWriteRepository">Репозиторий для операций записи.</param>
    public CreateCountryCommandHandler(ICountryWriteRepository countryWriteRepository)
    {
        _countryWriteRepository = countryWriteRepository;
    }
    
    /// <summary>
    /// Обрабатывает команду для создания нового объекта Country.
    /// </summary>
    /// <param name="request">Команда CreateCountryCommand, содержащая данные для создания страны.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Созданный объект Country.</returns>
    public async Task<Country?> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new Country(
            request.Name,
            request.Code
        );
        
        await _countryWriteRepository.AddAsync(country, cancellationToken);
        
        return country;
    }
}