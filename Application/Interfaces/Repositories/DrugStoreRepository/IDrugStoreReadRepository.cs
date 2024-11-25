using Domain.Entities;

namespace Application.Interfaces.Repositories.DrugStoreRepository;

/// <summary>
/// Интерфейс репозитория для чтения операций, связанных с сущностью DrugStore.
/// </summary>
public interface IDrugStoreReadRepository : IReadRepository<DrugStore>;