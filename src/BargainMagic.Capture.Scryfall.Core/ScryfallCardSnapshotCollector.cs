using BargainMagic.Capture.Abstractions;
using BargainMagic.Capture.Scryfall.Abstractions;
using BargainMagic.Capture.Scryfall.Abstractions.Extensions;
using BargainMagic.Capture.Scryfall.Abstractions.Models;
using BargainMagic.Capture.Scryfall.Core.Mappers;
using BargainMagic.Data.Abstractions.Entities;
using BargainMagic.Data.Abstractions.Enumerations;
using BargainMagic.Data.Abstractions.Repositories;

using System.Text.Json;

namespace BargainMagic.Capture.Scryfall.Core;

public class ScryfallCardSnapshotCollector : ICardSnapshotCollector
{
    private readonly ICardSnapshotRepository cardSnapshotRepository;
    private readonly IScryfallApiClient scryfallApiClient;

    /// <inheritdoc/>
    public CardCaptureType CaptureType => CardCaptureType.Scryfall;

    public ScryfallCardSnapshotCollector(ICardSnapshotRepository cardSnapshotRepository,
                                         IScryfallApiClient scryfallApiClient)
    {
        this.cardSnapshotRepository = cardSnapshotRepository;
        this.scryfallApiClient = scryfallApiClient;
    }

    /// <inheridoc/>
    public async Task<CardSnapshot?> GetCardSnapshot(CancellationToken cancellationToken = default)
    {
        var bulkDataMetadata = await this.scryfallApiClient.GetBulkDataMetadata(cancellationToken);

        if (bulkDataMetadata is null)
        {
            return null;
        }

        var cardSnapshot = await GetExistingCardSnapshot(bulkDataMetadata,
                                                         cancellationToken);

        if (cardSnapshot is not null)
        {
            return cardSnapshot;
        }

       using (var bulkDataDownloadStream = await this.scryfallApiClient.GetBulkDataStream(bulkDataMetadata.DownloadUri,
                                                                                          cancellationToken))
       {
           if (bulkDataDownloadStream is null)
           {
               return null;
           }
           
            var bulkDataCards = JsonSerializer.DeserializeAsyncEnumerable<BulkDataCard>(utf8Json: bulkDataDownloadStream,
                                                                                        cancellationToken: cancellationToken);

            var snapshotCards = new List<Card>();

            await foreach (var bulkDataCard in bulkDataCards)
            {
                if (bulkDataCard is null)
                {
                    continue;
                }

                var snapshotCard = snapshotCards.FirstOrDefault(c => c.Name == bulkDataCard.Name);

                // If the card has already been processed, replace the price with any lower than the one currently saved.
                if (snapshotCard is not null)
                {
                    var lowestPrice = bulkDataCard.Prices.GetLowestPrice();

                    if (lowestPrice is null)
                    {
                        continue;
                    }

                    if (snapshotCard.Price > lowestPrice)
                    {
                        snapshotCard.Price = lowestPrice.Value;
                    }

                    continue;
                }

                snapshotCard = bulkDataCard.ToCard();

                if (snapshotCard is null)
                {
                    continue;
                }

                snapshotCards.Add(snapshotCard);
            }

            cardSnapshot = await this.cardSnapshotRepository.CreateCardDataSnapshot(CaptureType,
                                                                                    snapshotCards,
                                                                                    cancellationToken);

            return cardSnapshot;
       }
    }

    /// <summary>
    /// For the Scryfall bulk data endpoint, prices are only updated once daily. If there is a stored card snapshot
    /// that was created after the <see cref="BulkDataMetadata.UpdatedDateTime"/>, pull its values instead of creating
    /// a new snapshot.
    /// </summary>
    /// <param name="bulkDataMetadata"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task<CardSnapshot?> GetExistingCardSnapshot(BulkDataMetadata bulkDataMetadata,
                                                              CancellationToken cancellationToken)
    {
       var cardSnapshotsAfterLastUpdate =
            await this.cardSnapshotRepository.GetCardDataSnapshots(s => s.CaptureDateTime > bulkDataMetadata.UpdatedDateTime);

        return cardSnapshotsAfterLastUpdate.OrderByDescending(s => s.CaptureDateTime)
                                           .FirstOrDefault();
    }
}
