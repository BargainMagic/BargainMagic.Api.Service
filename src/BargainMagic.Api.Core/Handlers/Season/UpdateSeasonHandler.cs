using BargainMagic.Api.Abstractions.Endpoints.Season;
using BargainMagic.Api.Abstractions.Endpoints.Season.Requests;
using BargainMagic.Api.Abstractions.Handlers.Season;
using BargainMagic.Api.Core.Mappers;
using BargainMagic.Data.Abstractions.Repositories;

namespace BargainMagic.Api.Core.Handlers.Season;

public class UpdateSeasonHandler : IUpdateSeasonHandler
{
    private readonly ISeasonRepository seasonRepository;

    public UpdateSeasonHandler(ISeasonRepository seasonRepository)
    {
        this.seasonRepository = seasonRepository;
    }

    /// <inheritdoc/>
    public async Task<SeasonDto?> HandleUpdateSeasonRequest(long seasonId,
                                                            UpdateSeasonRequest updateSeasonRequest,
                                                            CancellationToken cancellationToken = default)
    {
        var updatedSeason = await this.seasonRepository.UpdateSeason(seasonId: seasonId,
                                                                     name: updateSeasonRequest.Name,
                                                                     description: updateSeasonRequest.Description,
                                                                     cancellationToken: cancellationToken);

        return updatedSeason?.ToSeasonDto();
    }
}
