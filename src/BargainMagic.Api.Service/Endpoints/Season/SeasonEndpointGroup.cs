namespace BargainMagic.Api.Service.Endpoints.Season;

public static class SeasonEndpointGroup
{
    private const string SeasonEndpointGroupRoute = "/season";

    public static void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        var seasonEndpointGroup = endpointRouteBuilder.MapGroup(SeasonEndpointGroupRoute);

        GetSeasonsEndpoint.MapEndpoint(seasonEndpointGroup);
    }
}
