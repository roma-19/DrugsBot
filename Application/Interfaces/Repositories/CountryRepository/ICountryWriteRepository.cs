using Domain.Entities;

namespace Application.Interfaces.Repositories.CountryRepository;

/// <summary>
/// Интерфейс репозитория для записи операций, связанных с сущностью Country.
/// </summary>
public interface ICountryWriteRepository : IWriteRepository<Country>;