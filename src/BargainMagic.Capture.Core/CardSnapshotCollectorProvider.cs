using BargainMagic.Capture.Abstractions;
using BargainMagic.Capture.Scryfall.Core;
using BargainMagic.Data.Abstractions.Enumerations;

using Microsoft.Extensions.DependencyInjection;

namespace BargainMagic.Capture.Core;

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
