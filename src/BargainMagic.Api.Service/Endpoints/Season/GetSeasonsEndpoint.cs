using BargainMagic.Api.Abstractions.Endpoints.Season;
using BargainMagic.Api.Abstractions.Handlers.Season;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BargainMagic.Api.Service.Endpoints.Season;

public static class GetSeasonsEndpoint
{
    private const string GetSeasonsEndpointRoute = "/";

    public static async Task<Results<Ok<List<SeasonDto>>, BadRequest>> ProcessGetSeasonsRequest(IGetSeasonsHandler getSeasonsHandler,
                                                                                                CancellationToken cancellationToken)
    {
        var seasons = await getSeasonsHandler.HandleGetSeasonsRequest();

        return TypedResults.Ok(seasons);
    }

    public static void MapEndpoint(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGet(GetSeasonsEndpointRoute, ProcessGetSeasonsRequest);
    }
}
