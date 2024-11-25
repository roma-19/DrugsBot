using Application.Interfaces.Repositories.DrugRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Обработчик команды CreateDrugCommand для создания нового объекта Drug.
/// </summary>
public class CreateDrugCommandHandler : IRequestHandler<CreateDrugCommand, Drug?>
{
    private readonly IDrugWriteRepository _drugWriteRepository;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="drugWriteRepository">Репозиторий для операций записи.</param>
    public CreateDrugCommandHandler(IDrugWriteRepository drugWriteRepository)
    {
        _drugWriteRepository = drugWriteRepository;
    }
    
    /// <summary>
    /// Обрабатывает команду для создания нового объекта Drug.
    /// </summary>
    /// <param name="request">Команда CreateDrugCommand, содержащая данные для создания лекарства.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Созданный объект Drug.</returns>
    public async Task<Drug?> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
    {
        var drug = new Drug(
            request.Name,
            request.Manufacturer,
            request.CountryCodeId,
            request.Country
        );
        
        await _drugWriteRepository.AddAsync(drug, cancellationToken);
        
        return drug;
    }
}