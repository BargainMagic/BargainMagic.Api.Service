using BargainMagic.Data.Abstractions.Enumerations;

namespace BargainMagic.Capture.Season.Abstractions;

/// <summary>
/// Interface for classes that retrieve a specific <see cref="ICardSnapshotCollector"/>.
/// </summary>
public interface ICardSnapshotCollectorProvider
{
    /// <summary>
    /// Gets the currently configured <see cref="ICardSnapshotCollector"/> to collect card data.
    /// </summary>
    /// <param name="captureType"></param>
    /// <returns></returns>
    ICardSnapshotCollector GetCardSnapshotCollector(CardCaptureType captureType);
}
