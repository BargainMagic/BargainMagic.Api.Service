using BargainMagic.Api.Abstractions;
using BargainMagic.Api.Abstractions.Endpoints.Season.Requests;
using BargainMagic.Api.Abstractions.Handlers.Season;
using BargainMagic.Api.Core.Handlers.Season;
using BargainMagic.Api.Core.RequestValidators.Season;

using Microsoft.Extensions.DependencyInjection;

namespace BargainMagic.Api.Core;

/// <summary>
/// A static dependency helper bundling dependencies specific to the BargainMagic API projects.
/// </summary>
public static class ApiBundle
{
    /// <summary>
    /// Adds services related to the API projects.
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddApiServices(this IServiceCollection serviceCollection)
    {
        // Request Validators
        serviceCollection.AddTransient<IApiRequestValidator<CreateSeasonRequest>, CreateSeasonRequestValidator>();
        serviceCollection.AddTransient<IApiRequestValidator<UpdateSeasonRequest>, UpdateSeasonRequestValidator>();

        // Request Handlers
        serviceCollection.AddSingleton<ICreateSeasonHandler, CreateSeasonHandler>();
        serviceCollection.AddSingleton<IDeleteSeasonHandler, DeleteSeasonHandler>();
        serviceCollection.AddSingleton<IGetSeasonsHandler, GetSeasonsHandler>();
        serviceCollection.AddSingleton<IUpdateSeasonHandler, UpdateSeasonHandler>();
    }
}
