using BargainMagic.Capture.Abstractions;
using BargainMagic.Capture.Scryfall.Core;

using Microsoft.Extensions.DependencyInjection;

namespace BargainMagic.Capture.Core;

public static class CaptureBundle
{
    public static void AddCaptureServices(this IServiceCollection serviceCollection)
    {
        // SeasonSnapshotCollectors
        serviceCollection.AddScryfallCardSnapshotServices();

        serviceCollection.AddSingleton<ICardSnapshotCollectorProvider, CardSnapshotCollectorProvider>();
        serviceCollection.AddSingleton<ICardCaptureQueue, CardCaptureQueue>();

        serviceCollection.AddHostedService<CaptureService>();
    }
}
