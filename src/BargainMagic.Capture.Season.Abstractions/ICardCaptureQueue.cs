using BargainMagic.Capture.Season.Abstractions.Models;

namespace BargainMagic.Capture.Season.Abstractions;

/// <summary>
/// Interface for <see cref="CardCaptureRequest"/> storage and processing implementations.
/// </summary>
public interface ICardCaptureQueue
{
    /// <summary>
    /// Gets the next <see cref="CardCaptureRequest"/> from the queue.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CardCaptureRequest> GetNextCardCaptureRequest(CancellationToken cancellationToken);

    /// <summary>
    /// Adds a <see cref="CardCaptureRequest"/> to the queue.
    /// </summary>
    /// <param name="cardCaptureRequest"></param>
    /// <param name="cancellationToken"></param>
    Task QueueCardCapture(CardCaptureRequest cardCaptureRequest,
                          CancellationToken cancellationToken = default);
}
