using Domain.Entities;

namespace Application.Interfaces.Repositories.ProfileRepository;

/// <summary>
/// Интерфейс репозитория для чтения операций, связанных с сущностью Profile.
/// </summary>
public interface IProfileReadRepository : IReadRepository<Profile>;