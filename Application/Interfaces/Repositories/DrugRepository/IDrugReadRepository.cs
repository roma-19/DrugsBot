using Domain.Entities;

namespace Application.Interfaces.Repositories.DrugRepository;

/// <summary>
/// Интерфейс репозитория для чтения операций, связанных с сущностью Drug.
/// </summary>
public interface IDrugReadRepository : IReadRepository<Drug>;