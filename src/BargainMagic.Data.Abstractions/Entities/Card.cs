namespace BargainMagic.Data.Abstractions.Entities;

/// <summary>
/// Card information entity for storage within the data store. This 
/// </summary>
public class Card
{
    /// <summary>
    /// The readable identifier of the card.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The lowest captured price of the card.
    /// </summary>
    public required decimal Price { get; set; }
}
