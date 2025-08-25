using BargainMagic.Data.Abstractions.Entities;
using BargainMagic.Data.Abstractions.Repositories;

namespace BargainMagic.Data.Core.Repositories;

public class SeasonRepository : ISeasonRepository
{
    // TODO: Replace this with an actual data store.
    private readonly List<Season> seasons = new List<Season>();

    private long currentId = 0;

    /// <inheritdoc/>
    public async Task<Season> CreateSeason(string name,
                                           string description,
                                           int captureType,
                                           CancellationToken cancellationToken = default)
    {
        var season = new Season
                     {
                         Id = ++currentId,
                         Name = name,
                         CreatedDateTime = DateTime.UtcNow,
                         Description = description
                     };

        seasons.Add(season);

        return season;
    }

    /// <inheritdoc/>
    public async Task DeleteSeason(long seasonId,
                                   CancellationToken cancellationToken = default)
    {
        var seasonToDelete = seasons.FirstOrDefault(s => s.Id == seasonId);

        if (seasonToDelete is null)
        {
            return;
        }

        seasons.Remove(seasonToDelete);
    }

    /// <inheritdoc/>
    public async Task<List<Season>> GetSeasons(CancellationToken cancellationToken = default)
    {
        return seasons;
    }

    // TODO: Once this is an actual data store, the CardSnapshot should only be the card snapshot identifier.
    /// <inheritdoc/>
    public async Task<Season?> UpdateSeason(long seasonId,
                                            string? name = null,
                                            string? description = null,
                                            CardSnapshot? cardSnapshot = null,
                                            CancellationToken cancellationToken = default)
    {
        var seasonToUpdate = seasons.FirstOrDefault(s => s.Id == seasonId);

        if (seasonToUpdate is null)
        {
            return null;
        }

        if (name is not null)
        {
            seasonToUpdate.Name = name;
        }

        if (description is not null)
        {
            seasonToUpdate.Description = description;
        }

        if (cardSnapshot is not null)
        {
            seasonToUpdate.CardSnapshotId = cardSnapshot?.Id;
            seasonToUpdate.CardSnapshot = cardSnapshot;
        }

        return seasonToUpdate;
    }
}
