using System.Text.Json.Serialization;

namespace BargainMagic.Capture.Season.Scryfall.Abstractions.Models;

/// <summary>
/// Response from the Scryfall API GET /bulk-data/:type endpoint. Used to collect identifying information on the 
/// collection and where to download it from.
/// </summary>
public record BulkDataMetadata
{
    /// <summary>
    /// The unique identifier for the bulk data collection.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; set; }

    /// <summary>
    /// The DateTime the collection had last been updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedDateTime { get; set; }

    /// <summary>
    /// The Scryfall URI to download the collection.
    /// </summary>
    [JsonPropertyName("download_uri")]
    public required string DownloadUri { get; set; }
}
