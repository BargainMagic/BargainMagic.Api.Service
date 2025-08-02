using BargainMagic.Api.Abstractions.Endpoints.Season;

namespace BargainMagic.Api.Abstractions.Handlers.Season;

public interface IGetSeasonsHandler
{
    Task<List<SeasonDto>> HandleGetSeasonsRequest(CancellationToken cancellationToken);
}
