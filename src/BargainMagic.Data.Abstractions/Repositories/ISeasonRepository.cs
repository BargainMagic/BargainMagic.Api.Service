using BargainMagic.Data.Abstractions.Entities;

namespace BargainMagic.Data.Abstractions.Repositories;

public interface ISeasonRepository
{
    /// <summary>
    /// Creates a new <see cref="Season"/> entity in the data store.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<Season> CreateSeason(string name,
                                     CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a <see cref="Season"/> entity with the given identifier in the data store.
    /// </summary>
    /// <param name="seasonId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task DeleteSeason(long seasonId,
                             CancellationToken cancellationToken);

    /// <summary>
    /// Gets all <see cref="Season"/> entities from the data store.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<List<Season>> GetSeasons(CancellationToken cancellationToken);
}
