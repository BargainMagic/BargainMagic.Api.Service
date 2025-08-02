using BargainMagic.Api.Abstractions.Endpoints.Season;
using BargainMagic.Api.Abstractions.Endpoints.Season.Requests;

namespace BargainMagic.Api.Abstractions.Handlers.Season;

public interface ICreateSeasonHandler
{
    Task<SeasonDto?> HandleCreateSeasonRequest(CreateSeasonRequest createSeasonRequest,
                                               CancellationToken cancellationToken);
}
