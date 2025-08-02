namespace BargainMagic.Api.Service.Endpoints.Season;

public static class SeasonEndpointGroup
{
    private const string SeasonEndpointGroupRoute = "/season";

    public static void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        var seasonEndpointGroup = endpointRouteBuilder.MapGroup(SeasonEndpointGroupRoute);

        CreateSeasonEndpoint.MapEndpoint(seasonEndpointGroup);
        DeleteSeasonEndpoint.MapEndpoint(seasonEndpointGroup);
        GetSeasonsEndpoint.MapEndpoint(seasonEndpointGroup);
        UpdateSeasonEndpoint.MapEndpoint(seasonEndpointGroup);
    }
}
