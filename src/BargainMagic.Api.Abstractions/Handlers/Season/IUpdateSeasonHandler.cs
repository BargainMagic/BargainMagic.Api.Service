using BargainMagic.Api.Abstractions.Endpoints.Season;
using BargainMagic.Api.Abstractions.Endpoints.Season.Requests;

namespace BargainMagic.Api.Abstractions.Handlers.Season;


/// <summary>
/// Interface for handling business logic for the UpdateSeason endpoint.
/// </summary>
public interface IUpdateSeasonHandler
{
    /// <summary>
    /// Processes an <see cref="UpdateSeasonRequest"/> to apply updates to a season with the given identifier.
    /// </summary>
    /// <param name="seasonId"></param>
    /// <param name="updateSeasonRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SeasonDto?> HandleUpdateSeasonRequest(long seasonId,
                                               UpdateSeasonRequest updateSeasonRequest,
                                               CancellationToken cancellationToken = default);
}
