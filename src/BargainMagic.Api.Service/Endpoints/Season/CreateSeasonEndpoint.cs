using BargainMagic.Api.Abstractions;
using BargainMagic.Api.Abstractions.Endpoints.Season;
using BargainMagic.Api.Abstractions.Endpoints.Season.Requests;
using BargainMagic.Api.Abstractions.Handlers.Season;

using Microsoft.AspNetCore.Http.HttpResults;

namespace BargainMagic.Api.Service.Endpoints.Season;

public class CreateSeasonEndpoint
{
    private const string CreateSeasonEndpointRoute = "/";

    public static async Task<Results<Ok<SeasonDto>, BadRequest<string>>> ProcessCreateSeasonRequest(CreateSeasonRequest createSeasonRequest,
                                                                                                    IApiRequestValidator<CreateSeasonRequest> apiRequestValidator,
                                                                                                    ICreateSeasonHandler createSeasonsHandler,
                                                                                                    CancellationToken cancellationToken)
    {
        var requestValidation = await apiRequestValidator.ValidateRequest(createSeasonRequest,
                                                                          cancellationToken);

        if (!requestValidation.IsSuccessful)
        {
            return TypedResults.BadRequest(requestValidation.FailureReason);
        }

        var season = await createSeasonsHandler.HandleCreateSeasonRequest(createSeasonRequest,
                                                                          cancellationToken);

        if (season is null)
        {
            return TypedResults.BadRequest("Season could not be created.");
        }

        return TypedResults.Ok(season);
    }

    public static void MapEndpoint(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost(CreateSeasonEndpointRoute,
                                     ProcessCreateSeasonRequest);
    }
}
