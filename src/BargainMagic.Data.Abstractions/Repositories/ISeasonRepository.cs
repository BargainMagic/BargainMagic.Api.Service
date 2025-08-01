using BargainMagic.Data.Abstractions.Entities;

namespace BargainMagic.Data.Abstractions.Repositories;

public interface ISeasonRepository
{
    public Task<List<Season>> GetSeasons(CancellationToken cancellationToken);
}
