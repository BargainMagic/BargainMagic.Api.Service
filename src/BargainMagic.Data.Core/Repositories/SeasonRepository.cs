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
                                           CancellationToken cancellationToken)
    {
        var season = new Season(id: ++currentId,
                                name: name,
                                createdDateTime: DateTime.UtcNow);

        seasons.Add(season);

        return season;
    }

    /// <inheritdoc/>
    public async Task<List<Season>> GetSeasons(CancellationToken cancellationToken)
    {
        return seasons;
    }
}
