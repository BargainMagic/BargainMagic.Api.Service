using BargainMagic.Capture.Abstractions;
using BargainMagic.Capture.Scryfall.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace BargainMagic.Capture.Scryfall.Core;

/// <summary>
/// A static dependency helper bundling dependencies specific to the BargainMagic Scryfall Card Snapshot projects.
/// </summary>
public static class ScryfallCardSnapshotBundle
{
    /// <summary>
    /// Adds services related to the Scryfall Card Snapshot projects.
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddScryfallCardSnapshotServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient();

        serviceCollection.AddSingleton<IScryfallApiClient, ScryfallApiClient>();

        serviceCollection.AddKeyedSingleton<ICardSnapshotCollector, ScryfallCardSnapshotCollector>(nameof(ScryfallCardSnapshotCollector));
    }
}
