using BargainMagic.Capture.Season.Abstractions;
using BargainMagic.Data.Abstractions.Repositories;

using Microsoft.Extensions.Hosting;

namespace BargainMagic.Capture.Season.Core;

public class CaptureService : BackgroundService
{
    private readonly ICardCaptureQueue cardCaptureQueue;
    private readonly ICardSnapshotCollectorProvider cardSnapshotCollectorProvider;
    private readonly ISeasonRepository seasonRepository;

    public CaptureService(ICardCaptureQueue cardCaptureQueue,
                          ICardSnapshotCollectorProvider cardSnapshotCollectorProvider,
                          ISeasonRepository seasonRepository)
    {
        this.cardCaptureQueue = cardCaptureQueue;
        this.cardSnapshotCollectorProvider = cardSnapshotCollectorProvider;
        this.seasonRepository = seasonRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var cardCaptureRequest = await this.cardCaptureQueue.GetNextCardCaptureRequest(cancellationToken);

            var cardSnapshotCollector = this.cardSnapshotCollectorProvider.GetCardSnapshotCollector(cardCaptureRequest.Type);

            var cardSnapshot = await cardSnapshotCollector.GetCardSnapshot(cancellationToken);

            await this.seasonRepository.UpdateSeason(seasonId: cardCaptureRequest.SeasonId,
                                                     cardSnapshot: cardSnapshot,
                                                     cancellationToken: cancellationToken);
        }
    }
}
