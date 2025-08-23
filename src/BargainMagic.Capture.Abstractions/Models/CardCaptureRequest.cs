using BargainMagic.Data.Abstractions.Enumerations;

namespace BargainMagic.Capture.Abstractions.Models;

/// <summary>
/// Request parameters for an <see cref="ICardCaptureQueue"/> to store for sequential processing.
/// </summary>
public record CardCaptureRequest
{
    /// <summary>
    /// The unique identifier of the season data is being captured for.
    /// </summary>
    public long SeasonId { get; set; }

    /// <summary>
    /// The type of capture to collect season card data.
    /// </summary>
    public CardCaptureType Type { get; set; }

    public CardCaptureRequest(long seasonId,
                              CardCaptureType type)
    {
        SeasonId = seasonId;
        Type = type;
    }
}
