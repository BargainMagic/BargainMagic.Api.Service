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
                                           CancellationToken cancellationToken)
    {
        var season = new Season(id: ++currentId,
                                name: name,
                                createdDateTime: DateTime.UtcNow,
                                description: description);

        seasons.Add(season);

        return season;
    }

    /// <inheritdoc/>
    public async Task DeleteSeason(long seasonId,
                                   CancellationToken cancellationToken)
    {
        var seasonToDelete = seasons.FirstOrDefault(s => s.Id == seasonId);

        if (seasonToDelete is null)
        {
            return;
        }

        seasons.Remove(seasonToDelete);
    }

    /// <inheritdoc/>
    public async Task<List<Season>> GetSeasons(CancellationToken cancellationToken)
    {
        return seasons;
    }

    /// <inheritdoc/>
    public async Task<Season?> UpdateSeason(long seasonId,
                                            string name,
                                            string description,
                                            CancellationToken cancellationToken)
    {
        var seasonToUpdate = seasons.FirstOrDefault(s => s.Id == seasonId);

        if (seasonToUpdate is null)
        {
            return null;
        }

        seasonToUpdate.Name = name;
        seasonToUpdate.Description = description;

        return seasonToUpdate;
    }
}
