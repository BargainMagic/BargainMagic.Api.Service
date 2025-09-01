using BargainMagic.Capture.Season.Scryfall.Abstractions.Models;

namespace BargainMagic.Capture.Season.Scryfall.Abstractions;

public interface IScryfallApiClient
{
    /// <summary>
    /// Requests the GET /bulk-data/:type endpoint on the Scryfall API to retireve metadata on the latest bulk data 
    /// upload.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>A <see cref="BulkDataMetadata"/> with information about the latest bulk data upload.</returns>
    Task<BulkDataMetadata?> GetBulkDataMetadata(CancellationToken cancellationToken = default);

    /// <summary>
    /// Requests a download of the bulk card data from the given GET /bulk-data/:type endpoint on the Scryfall API to retireve metadata on the latest bulk data 
    /// upload.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>A <see cref="BulkDataMetadata"/> with information about the latest bulk data upload.</returns>
    Task<Stream?> GetBulkDataStream(string bulkCardDataUri,
                                    CancellationToken cancellationToken = default);
}
