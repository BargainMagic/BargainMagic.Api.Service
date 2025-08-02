using BargainMagic.Data.Abstractions.Repositories;
using BargainMagic.Data.Core.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace BargainMagic.Data.Core;

public static class DataBundle
{
    public static void AddDataServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ISeasonRepository, SeasonRepository>();
    }
}
