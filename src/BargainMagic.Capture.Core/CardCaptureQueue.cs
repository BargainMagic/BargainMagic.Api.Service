using BargainMagic.Capture.Abstractions;
using BargainMagic.Capture.Abstractions.Models;

using System.Threading.Channels;

namespace BargainMagic.Capture.Core;

public class CardCaptureQueue : ICardCaptureQueue
{
    private readonly Channel<CardCaptureRequest> cardCaptureRequestChannel;

    public CardCaptureQueue()
    {
        this.cardCaptureRequestChannel = Channel.CreateUnbounded<CardCaptureRequest>();
    }

    /// <inheritdoc/>
    public async Task<CardCaptureRequest> GetNextCardCaptureRequest(CancellationToken cancellationToken = default)
    {
        return await this.cardCaptureRequestChannel.Reader.ReadAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task QueueCardCapture(CardCaptureRequest seasonCaptureRequest,
                                         CancellationToken cancellationToken = default)
    {
        await this.cardCaptureRequestChannel.Writer.WriteAsync(seasonCaptureRequest,
                                                                 cancellationToken);
    }
}
