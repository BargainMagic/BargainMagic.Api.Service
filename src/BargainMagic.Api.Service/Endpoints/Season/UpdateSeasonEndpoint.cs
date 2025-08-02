using BargainMagic.Api.Abstractions.Endpoints.Season;
using BargainMagic.Api.Abstractions.Endpoints.Season.Requests;
using BargainMagic.Api.Abstractions.Handlers.Season;

using Microsoft.AspNetCore.Http.HttpResults;

namespace BargainMagic.Api.Service.Endpoints.Season;

public class UpdateSeasonEndpoint
{
    private const string UpdateSeasonEndpointRoute = "/{seasonId}";

    public static async Task<Results<Ok<SeasonDto>, NotFound>> ProcessUpdateSeasonRequest(long seasonId,
                                                                                          UpdateSeasonRequest updateSeasonRequest,
                                                                                          IUpdateSeasonHandler updateSeasonHandler,
                                                                                          CancellationToken cancellationToken)
    {
        var updatedSeasonDto = await updateSeasonHandler.HandleUpdateSeasonRequest(seasonId,
                                                                                   updateSeasonRequest,
                                                                                   cancellationToken);

        if (updatedSeasonDto is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(updatedSeasonDto);
    }

    public static void MapEndpoint(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPut(UpdateSeasonEndpointRoute,
                                    ProcessUpdateSeasonRequest);
    }
}
