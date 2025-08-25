using System.Text.Json.Serialization;

namespace BargainMagic.Capture.Scryfall.Abstractions.Models;

/// <summary>
/// A JSON model containing information about a card given by the Scryfall BulkData endpoint.
/// </summary>
public class BulkDataCard
{
    /// <summary>
    /// The readable identifier of the card.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A collection of pricing data of the card.
    /// </summary>
    [JsonPropertyName("prices")]
    public required BulkDataCardPrice Prices { get; set; }
}
