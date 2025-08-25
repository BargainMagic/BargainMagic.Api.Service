using BargainMagic.Data.Abstractions.Entities;

namespace BargainMagic.Data.Abstractions.Repositories;

public interface ISeasonRepository
{
    /// <summary>
    /// Creates a new <see cref="Season"/> entity in the data store.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="captureType"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The created season entity.</returns>
    public Task<Season> CreateSeason(string name,
                                     string description,
                                     int captureType,
                                     CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a <see cref="Season"/> entity with the given identifier in the data store.
    /// </summary>
    /// <param name="seasonId"></param>
    /// <param name="cancellationToken"></param>
    public Task DeleteSeason(long seasonId,
                             CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all <see cref="Season"/> entities from the data store.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>The collection of stored seasons.</returns>
    public Task<List<Season>> GetSeasons(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the customizable values of a specific season.
    /// </summary>
    /// <param name="seasonId"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="cardSnapshot"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The updated season entity.</returns>
    public Task<Season?> UpdateSeason(long seasonId,
                                      string? name = null,
                                      string? description = null,
                                      CardSnapshot? cardSnapshot = null,
                                      CancellationToken cancellationToken = default);
}
