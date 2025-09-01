using BargainMagic.Capture.Season.Abstractions;
using BargainMagic.Capture.Season.Scryfall.Core;

using Microsoft.Extensions.DependencyInjection;

namespace BargainMagic.Capture.Season.Core;

public static class CaptureBundle
{
    public static void AddSeasonCaptureServices(this IServiceCollection serviceCollection)
    {
        // SeasonSnapshotCollectors
        serviceCollection.AddScryfallCardSnapshotServices();

        serviceCollection.AddSingleton<ICardSnapshotCollectorProvider, CardSnapshotCollectorProvider>();
        serviceCollection.AddSingleton<ICardCaptureQueue, CardCaptureQueue>();

        serviceCollection.AddHostedService<CaptureService>();
    }
}
