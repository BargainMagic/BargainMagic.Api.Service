namespace BargainMagic.Api.Abstractions.Endpoints.Season.Requests;

/// <summary>
/// Request parameters for the CreateSeason endpoint.
/// </summary>
public record CreateSeasonRequest
{
    /// <summary>
    /// The readable identifier to apply to the created season.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The description to apply to the created season.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The raw SeasonCaptureType that will be converted to an enumerable within the service.
    /// </summary>
    public int SeasonCaptureType { get; set; }
}

