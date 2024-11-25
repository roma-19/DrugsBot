using Application.Interfaces.Repositories.ProfileRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.ProfileQueries;

/// <summary>
/// Обработчик запроса GetProfileByIdQuery для получения объекта Profile по идентификатору.
/// </summary>
public class GetProfileByIdQueryHandler: IRequestHandler<GetProfileByIdQuery, Profile?>
{
    private readonly IProfileReadRepository _profileReadRepository;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="profileReadRepository">Репозиторий для операций чтения.</param>
    public GetProfileByIdQueryHandler(IProfileReadRepository profileReadRepository)
    {
        _profileReadRepository = profileReadRepository;
    }
    
    /// <summary>
    /// Обрабатывает запрос для получения объекта Profile по идентификатору.
    /// </summary>
    /// <param name="request">Запрос GetProfileByIdQuery, содержащий идентификатор профиля.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект Profile.</returns>
    public async Task<Profile?> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
    {
        return await _profileReadRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}