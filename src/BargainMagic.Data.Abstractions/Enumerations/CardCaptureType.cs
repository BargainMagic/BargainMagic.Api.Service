namespace BargainMagic.Data.Abstractions.Enumerations;

/// <summary>
/// Enumeration of card capture methods used to determine what source to use when capturing card data.
/// </summary>
public enum CardCaptureType
{
    /// <summary>
    /// Indicates season card information should be retrieved from the Scryfall BulkData API.
    /// </summary>
    Scryfall = 0
}
