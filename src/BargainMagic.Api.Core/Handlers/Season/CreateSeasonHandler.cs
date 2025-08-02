using BargainMagic.Api.Abstractions.Endpoints.Season;
using BargainMagic.Api.Abstractions.Endpoints.Season.Requests;
using BargainMagic.Api.Abstractions.Handlers.Season;
using BargainMagic.Api.Core.Mappers;
using BargainMagic.Data.Abstractions.Repositories;

namespace BargainMagic.Api.Core.Handlers.Season;

public class CreateSeasonHandler : ICreateSeasonHandler
{
    private readonly ISeasonRepository seasonRepository;

    public CreateSeasonHandler(ISeasonRepository seasonRepository)
    {
        this.seasonRepository = seasonRepository;
    }

    public async Task<SeasonDto?> HandleCreateSeasonRequest(CreateSeasonRequest createSeasonRequest,
                                                            CancellationToken cancellationToken)
    {
        var season = await this.seasonRepository.CreateSeason(createSeasonRequest.Name,
                                                              createSeasonRequest.Description,
                                                              cancellationToken);

        return season?.ToSeasonDto();
    }
}
