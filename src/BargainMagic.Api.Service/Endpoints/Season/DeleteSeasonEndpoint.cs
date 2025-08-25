using BargainMagic.Api.Abstractions.Handlers.Season;

using Microsoft.AspNetCore.Http.HttpResults;

namespace BargainMagic.Api.Service.Endpoints.Season;

public class DeleteSeasonEndpoint
{
    private const string DeleteSeasonEndpointRoute = "/{seasonId}";

    public static async Task<Ok> ProcessDeleteSeasonRequest(long seasonId,
                                                            IDeleteSeasonHandler deleteSeasonHandler,
                                                            CancellationToken cancellationToken = default)
    {
        await deleteSeasonHandler.HandleDeleteSeasonRequest(seasonId,
                                                            cancellationToken);

        return TypedResults.Ok();
    }

    public static void MapEndpoint(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapDelete(DeleteSeasonEndpointRoute,
                                       ProcessDeleteSeasonRequest);
    }
}
