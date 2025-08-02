using BargainMagic.Api.Abstractions.Endpoints.Season;
using BargainMagic.Api.Abstractions.Endpoints.Season.Requests;

namespace BargainMagic.Api.Abstractions.Handlers.Season;

public interface IUpdateSeasonHandler
{
    Task<SeasonDto?> HandleUpdateSeasonRequest(long seasonId,
                                               UpdateSeasonRequest updateSeasonRequest,
                                               CancellationToken cancellationToken);
}
