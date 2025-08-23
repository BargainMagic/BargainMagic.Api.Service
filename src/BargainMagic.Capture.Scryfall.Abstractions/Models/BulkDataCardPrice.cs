using System.Text.Json.Serialization;

namespace BargainMagic.Capture.Scryfall.Abstractions.Models;

/// <summary>
/// A model of pricing data of a given card.
/// </summary>
public class BulkDataCardPrice
{
    /// <summary>
    /// The price string of the standard printing for this version of the card.
    /// </summary>
    [JsonPropertyName("usd")]
    public string? UsdString { get; set; }

    /// <summary>
    /// The price string of the etched foil printing for this version of the card.
    /// </summary>
    [JsonPropertyName("usd_etched")]
    public string? UsdEtchedString { get; set; }

    /// <summary>
    /// The price string of the foil printing for this version of the card.
    /// </summary>
    [JsonPropertyName("usd_foil")]
    public string? UsdFoilString { get; set; }

    /// <summary>
    /// The converted price of the standard printing for this version of the card.
    /// </summary>
    [JsonIgnore]
    public decimal? Usd => UsdString is not null ? decimal.Parse(UsdString) : null;

    /// <summary>
    /// The converted price of the etched foil printing for this version of the card.
    /// </summary>
    [JsonIgnore]
    public decimal? UsdEtched => UsdEtchedString is not null ? decimal.Parse(UsdEtchedString) : null;

    /// <summary>
    /// The converted price of the foil printing for this version of the card.
    /// </summary>
    [JsonIgnore]
    public decimal? UsdFoil => UsdFoilString is not null ? decimal.Parse(UsdFoilString) : null;
}
