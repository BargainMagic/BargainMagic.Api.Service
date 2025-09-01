using BargainMagic.Capture.Season.Abstractions;
using BargainMagic.Capture.Season.Scryfall.Core;
using BargainMagic.Data.Abstractions.Enumerations;

using Microsoft.Extensions.DependencyInjection;

namespace BargainMagic.Capture.Season.Core;

public class CardSnapshotCollectorProvider(IServiceProvider serviceProvider) : ICardSnapshotCollectorProvider
{
    /// <inheridoc/>
    public ICardSnapshotCollector GetCardSnapshotCollector(CardCaptureType captureType)
    {
        switch (captureType)
        {
            case CardCaptureType.Scryfall:
            default:
                return serviceProvider.GetRequiredKeyedService<ICardSnapshotCollector>(nameof(ScryfallCardSnapshotCollector));
        }
    }
}
