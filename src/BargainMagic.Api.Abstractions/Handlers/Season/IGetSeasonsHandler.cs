using BargainMagic.Api.Abstractions.Endpoints.Season;

namespace BargainMagic.Api.Abstractions.Handlers.Season;

/// <summary>
/// Interface for handling business logic for the GetSeason endpoint.
/// </summary>
public interface IGetSeasonsHandler
{
    /// <summary>
    /// Processes a request to retrieves all seasons. 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<SeasonDto>> HandleGetSeasonsRequest(CancellationToken cancellationToken = default);
}
