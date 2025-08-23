using BargainMagic.Data.Abstractions.Entities;
using BargainMagic.Data.Abstractions.Enumerations;

using System.Linq.Expressions;

namespace BargainMagic.Data.Abstractions.Repositories;

public interface ICardSnapshotRepository
{
    /// <summary>
    /// Creates a new <see cref="CardSnapshot"/> entity in the data store.
    /// </summary>
    /// <param name="captureType"></param>
    /// <param name="cards"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The newly created <see cref="CardSnapshot"/>.</returns>
    Task<CardSnapshot> CreateCardDataSnapshot(CardCaptureType captureType,
                                              List<Card> cards,
                                              CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a <see cref="CardSnapshot"/> entity from the data store.
    /// </summary>
    /// <param name="cardDataSnapshotId"></param>
    /// <param name="cancellationToken"></param>
    Task DeleteCardDataSnapshot(long cardDataSnapshotId,
                                CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all <see cref="CardSnapshot"/> entities from the data store that meets the specified conditions.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<CardSnapshot>> GetCardDataSnapshots(Expression<Func<CardSnapshot, bool>>? predicate = null,
                                                  CancellationToken cancellationToken = default);

}
