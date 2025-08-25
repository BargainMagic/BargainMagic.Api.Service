namespace BargainMagic.Api.Abstractions.Endpoints.Season.Requests;

/// <summary>
/// Request parameters for the UpdateSeason endpoint.
/// </summary>
public record UpdateSeasonRequest
{
    /// <summary>
    /// The updated readable identifier for the season. No updates will be applied if the property is null.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The updated description of the season. No updates will be applied if the property is null.
    /// </summary>
    public string? Description { get; set; }
}
