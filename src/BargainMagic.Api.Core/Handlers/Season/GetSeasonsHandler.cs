using BargainMagic.Api.Abstractions.Endpoints.Season;
using BargainMagic.Api.Abstractions.Handlers.Season;
using BargainMagic.Api.Core.Mappers;
using BargainMagic.Data.Abstractions.Repositories;

namespace BargainMagic.Api.Core.Handlers.Season;

public class GetSeasonsHandler : IGetSeasonsHandler
{
    private readonly ISeasonRepository seasonRepository;

    public GetSeasonsHandler(ISeasonRepository seasonRepository)
    {
        this.seasonRepository = seasonRepository;
    }

    public async Task<List<SeasonDto>> HandleGetSeasonsRequest(CancellationToken cancellationToken = default)
    {
        var seasons = await this.seasonRepository.GetSeasons(cancellationToken);

        return seasons.Select(s => s.ToSeasonDto())
                      .ToList();
    }
}
