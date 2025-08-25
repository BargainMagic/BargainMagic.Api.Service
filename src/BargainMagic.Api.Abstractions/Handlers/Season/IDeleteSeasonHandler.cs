namespace BargainMagic.Api.Abstractions.Handlers.Season;

/// <summary>
/// Interface for handling business logic for the DeleteSeason endpoint.
/// </summary>
public interface IDeleteSeasonHandler
{
    /// <summary>
    /// Processes a deletion request for the given season identifier.
    /// </summary>
    /// <param name="seasonId"></param>
    /// <param name="cancellationToken"></param>
    Task HandleDeleteSeasonRequest(long seasonId,
                                   CancellationToken cancellationToken = default);
}
