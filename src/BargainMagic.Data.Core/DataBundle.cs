using BargainMagic.Data.Abstractions.Repositories;
using BargainMagic.Data.Core.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace BargainMagic.Data.Core;

/// <summary>
/// A static dependency helper bundling dependencies specific to the BargainMagic data storage projects.
/// </summary>
public static class DataBundle
{
    /// <summary>
    /// Adds services related to the data store projects.
    /// </summary>
    public static void AddDataServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ICardSnapshotRepository, CardSnapshotRepository>();
        serviceCollection.AddSingleton<ISeasonRepository, SeasonRepository>();
    }
}
