namespace BargainMagic.Api.Abstractions.Endpoints.Season.Requests;

public record CreateSeasonRequest
{
    public string Name { get; set; } = string.Empty;
}
