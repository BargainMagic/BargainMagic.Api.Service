using BargainMagic.Data.Abstractions.Entities;
using BargainMagic.Data.Abstractions.Enumerations;

namespace BargainMagic.Capture.Season.Abstractions;

/// <summary>
/// Interface for classes to utilize services based on <see cref="CardCaptureType"/> to retrieve a snapshot of card data.
/// </summary>
public interface ICardSnapshotCollector
{
    /// <summary>
    /// The capture type that corresponds with the collector.
    /// </summary>
    CardCaptureType CaptureType { get; }

    /// <summary>
    /// Gets the <see cref="CardSnapshot"/> from the provider. This will return null if data failed to retrieve.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CardSnapshot?> GetCardSnapshot(CancellationToken cancellationToken = default);
}
