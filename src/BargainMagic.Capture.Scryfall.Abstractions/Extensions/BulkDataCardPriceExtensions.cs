using BargainMagic.Capture.Scryfall.Abstractions.Models;

namespace BargainMagic.Capture.Scryfall.Abstractions.Extensions;

/// <summary>
/// Extension methods for a <see cref="BulkDataCardPrice"/>.
/// </summary>
public static class BulkDataCardPriceExtensions
{
    /// <summary>
    /// Determines the lowest price out of the Etched, Foil, and Standard printings for a <see cref="BulkDataCardPrice"/>.
    /// </summary>
    /// <param name="bulkDataCardPrice"></param>
    /// <returns></returns>
    public static decimal? GetLowestPrice(this BulkDataCardPrice bulkDataCardPrice)
    {
        var potentialPrices = new List<decimal?>
                              {
                                  bulkDataCardPrice.Usd,
                                  bulkDataCardPrice.UsdEtched,
                                  bulkDataCardPrice.UsdFoil
                              };

        if (potentialPrices.All(p => p == null))
        {
            return null;
        }

        return potentialPrices.Where(p => p != null)
                              .Min(p => p!.Value);
    }
}
