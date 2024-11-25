using Domain.Entities;

namespace Application.Interfaces.Repositories.ProfileRepository;

/// <summary>
/// Интерфейс репозитория для записи операций, связанных с сущностью Profile.
/// </summary>
public interface IProfileWriteRepository : IWriteRepository<Profile>;