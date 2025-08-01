using BargainMagic.Api.Service.Endpoints.Season;

namespace BargainMagic.Api.Service.Endpoints;

public static class EndpointBundle
{
    public static void MapEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        SeasonEndpointGroup.MapEndpoints(endpointRouteBuilder);
    }
}
