using Domain.Entities;

namespace Application.Interfaces.Repositories.DrugRepository;

/// <summary>
/// Интерфейс репозитория для записи операций, связанных с сущностью Drug.
/// </summary>
public interface IDrugWriteRepository : IWriteRepository<Drug>;