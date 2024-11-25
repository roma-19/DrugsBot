using Domain.Entities;

namespace Application.Interfaces.Repositories.DrugStoreRepository;

/// <summary>
/// Интерфейс репозитория для записи операций, связанных с сущностью DrugStore.
/// </summary>
public interface IDrugStoreWriteRepository : IWriteRepository<DrugStore>;