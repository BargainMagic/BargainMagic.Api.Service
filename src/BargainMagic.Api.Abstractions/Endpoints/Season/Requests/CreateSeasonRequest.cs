namespace BargainMagic.Api.Abstractions.Endpoints.Season.Requests;

public record UpdateSeasonRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
