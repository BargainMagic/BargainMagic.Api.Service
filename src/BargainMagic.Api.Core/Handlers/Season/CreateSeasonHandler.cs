using BargainMagic.Api.Abstractions.Endpoints.Season;
using BargainMagic.Api.Abstractions.Endpoints.Season.Requests;
using BargainMagic.Api.Abstractions.Handlers.Season;
using BargainMagic.Api.Core.Mappers;
using BargainMagic.Capture.Season.Abstractions;
using BargainMagic.Capture.Season.Abstractions.Models;
using BargainMagic.Data.Abstractions.Enumerations;
using BargainMagic.Data.Abstractions.Repositories;

namespace BargainMagic.Api.Core.Handlers.Season;

public class CreateSeasonHandler : ICreateSeasonHandler
{
    private readonly ICardCaptureQueue seasonCaptureQueue;
    private readonly ISeasonRepository seasonRepository;

    public CreateSeasonHandler(ICardCaptureQueue seasonCaptureQueue,
                               ISeasonRepository seasonRepository)
    {
        this.seasonCaptureQueue = seasonCaptureQueue;
        this.seasonRepository = seasonRepository;
    }

    /// <inheritdoc/>
    public async Task<SeasonDto?> HandleCreateSeasonRequest(CreateSeasonRequest createSeasonRequest,
                                                            CancellationToken cancellationToken = default)
    {
        var season = await this.seasonRepository.CreateSeason(createSeasonRequest.Name,
                                                              createSeasonRequest.Description,
                                                              createSeasonRequest.SeasonCaptureType,
                                                              cancellationToken);

        // Currently defaults to Scryfall (0), could update this to be configurable once more types are added.
        var seasonCaptureType = Enum.Parse<CardCaptureType>(createSeasonRequest.SeasonCaptureType.ToString());

        var seasonCaptureRequest = new CardCaptureRequest(season.Id,
                                                            seasonCaptureType);

        await this.seasonCaptureQueue.QueueCardCapture(seasonCaptureRequest,
                                                       cancellationToken);

        return season?.ToSeasonDto();
    }
}
