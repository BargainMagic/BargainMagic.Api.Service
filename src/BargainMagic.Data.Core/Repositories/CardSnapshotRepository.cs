using BargainMagic.Data.Abstractions.Entities;
using BargainMagic.Data.Abstractions.Enumerations;
using BargainMagic.Data.Abstractions.Repositories;

using System.Linq.Expressions;

namespace BargainMagic.Data.Core.Repositories;

public class CardSnapshotRepository : ICardSnapshotRepository
{
    // TODO: Replace this with an actual data store.
    private readonly List<CardSnapshot> cardSnapshots = new List<CardSnapshot>();

    private long currentId = 0;

    /// <inheritdoc/>
    public async Task<CardSnapshot> CreateCardDataSnapshot(CardCaptureType captureType,
                                                           List<Card> cards,
                                                           CancellationToken cancellationToken = default)
    {

        var cardSnapshot = new CardSnapshot
                           {
                               Id = ++currentId,
                               CaptureType = captureType,
                               CaptureDateTime = DateTime.UtcNow,
                               Cards = cards
                           };

        cardSnapshots.Add(cardSnapshot);

        return cardSnapshot;
    }

    /// <inheritdoc/>
    public async Task DeleteCardDataSnapshot(long cardSnapshotId,
                                             CancellationToken cancellationToken = default)
    {
        var cardSnapshotToDelete = cardSnapshots.FirstOrDefault(s => s.Id == cardSnapshotId);

        if (cardSnapshotToDelete is null)
        {
            return;
        }

        cardSnapshots.Remove(cardSnapshotToDelete);
    }

    /// <inheritdoc/>
    public async Task<List<CardSnapshot>> GetCardDataSnapshots(Expression<Func<CardSnapshot, bool>>? predicate = null,
                                                               CancellationToken cancellationToken = default)
    {
        var cardSnapshotQuery = this.cardSnapshots.AsQueryable();

        if (predicate is not null)
        {
            cardSnapshotQuery = cardSnapshotQuery.Where(predicate);
        }

        return cardSnapshotQuery.ToList();
    }
}
