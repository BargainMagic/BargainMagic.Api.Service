using BargainMagic.Capture.Scryfall.Abstractions.Extensions;
using BargainMagic.Capture.Scryfall.Abstractions.Models;
using BargainMagic.Data.Abstractions.Entities;

namespace BargainMagic.Capture.Scryfall.Core.Mappers;

/// <summary>
/// Extension methods for a <see cref="BulkDataCard"/>.
/// </summary>
public static class BulkDataCardExtensions
{
    /// <summary>
    /// Converts a <see cref="BulkDataCard"/> from the Scryfall API into a <see cref="Card"/> entity for the 
    /// BargainMagic service.
    /// </summary>
    /// <param name="bulkDataCard"></param>
    /// <returns></returns>
    public static Card? ToCard(this BulkDataCard bulkDataCard)
    {
        var lowestPrice = bulkDataCard.Prices.GetLowestPrice();

        if (lowestPrice is null)
        {
            return null;
        }

        return new Card
               {
                   Name = bulkDataCard.Name,
                   Price = lowestPrice.Value
               };
    }
}
