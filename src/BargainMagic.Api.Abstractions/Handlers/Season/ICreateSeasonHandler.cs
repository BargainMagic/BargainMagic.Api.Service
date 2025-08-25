using BargainMagic.Api.Abstractions.Endpoints.Season;
using BargainMagic.Api.Abstractions.Endpoints.Season.Requests;

namespace BargainMagic.Api.Abstractions.Handlers.Season;

/// <summary>
/// Interface for handling business logic for the CreateSeason endpoint.
/// </summary>
public interface ICreateSeasonHandler
{
    /// <summary>
    /// Processes a <see cref="CreateSeasonRequest"/> and creates a new season. 
    /// </summary>
    /// <param name="createSeasonRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The created season.</returns>
    Task<SeasonDto?> HandleCreateSeasonRequest(CreateSeasonRequest createSeasonRequest,
                                               CancellationToken cancellationToken = default);
}
