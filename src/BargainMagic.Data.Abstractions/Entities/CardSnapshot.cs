using BargainMagic.Data.Abstractions.Enumerations;

namespace BargainMagic.Data.Abstractions.Entities;

/// <summary>
/// A collection of card information captured to be used to enforce rules for a <see cref="Season"/>.
/// </summary>
public class CardSnapshot
{
    /// <summary>
    /// Unique identifier for the <see cref="CardSnapshot"/>.
    /// </summary>
    public required long Id { get; set; }

    /// <summary>
    /// The <see cref="CardCaptureType"/> indicating what method was used to capture the card information.
    /// </summary>
    public required CardCaptureType CaptureType { get; set; }

    /// <summary>
    /// The date and time the card information was captured.
    /// </summary>
    public required DateTime CaptureDateTime { get; set; }

    /// <summary>
    /// The stored card information for the snapshot.
    /// </summary>
    public required List<Card> Cards { get; set; }

    /// <summary>
    /// A collection of <see cref="Season"/> that utilize this <see cref="CardSnapshot"/> for rules enforcement.
    /// </summary>
    public List<Season> Seasons { get; set; } = [];
}
