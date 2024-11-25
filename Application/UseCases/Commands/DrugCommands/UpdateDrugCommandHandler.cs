using Application.Interfaces.Repositories.DrugRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// Обработчик команды UpdateDrugCommand для обновления объекта Drug.
/// </summary>
public class UpdateDrugCommandHandler : IRequestHandler<UpdateDrugCommand, Drug?>
{
    private readonly IDrugReadRepository _drugReadRepository;
    private readonly IDrugWriteRepository _drugWriteRepository;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="drugWriteRepository">Репозиторий для операций записи.</param>
    /// <param name="drugReadRepository">Репозиторий для операций чтения.</param>
    public UpdateDrugCommandHandler(IDrugWriteRepository drugWriteRepository,
        IDrugReadRepository drugReadRepository)
    {
        _drugWriteRepository = drugWriteRepository;
        _drugReadRepository = drugReadRepository;
    }
    
    /// <summary>
    /// Обрабатывает команду для обновления объекта Drug.
    /// </summary>
    /// <param name="request">Команда UpdateDrugCommand, содержащая данные для обновления лекарства.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновленный объект Drug или null при неудаче.</returns>
    public async Task<Drug?> Handle(UpdateDrugCommand request, CancellationToken cancellationToken)
    {
        var drug = await _drugReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (drug == null) throw new NullReferenceException();

        drug.Name = request.Name;
        drug.Manufacturer = request.Manufacturer;
        drug.CountryCodeId = request.CountryCodeId;
        drug.Country = request.Country;

        await _drugWriteRepository.UpdateAsync(drug, cancellationToken);

        return drug;
    }
}