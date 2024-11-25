using Domain.Entities;

namespace Application.Interfaces.Repositories.CountryRepository;

/// <summary>
/// Интерфейс репозитория для чтения операций, связанных с сущностью Country.
/// </summary>
public interface ICountryReadRepository : IReadRepository<Country>;