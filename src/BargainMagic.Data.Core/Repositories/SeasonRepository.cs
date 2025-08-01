using BargainMagic.Data.Abstractions.Entities;
using BargainMagic.Data.Abstractions.Repositories;

namespace BargainMagic.Data.Core.Repositories;

public class SeasonRepository : ISeasonRepository
{
    // TODO: Replace this with an actual data store.
    private readonly List<Season> seasons = new List<Season>();

    public async Task<List<Season>> GetSeasons(CancellationToken cancellationToken)
    {
        return seasons;
    }
}
