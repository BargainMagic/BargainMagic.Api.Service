using BargainMagic.Api.Abstractions.Handlers.Season;
using BargainMagic.Data.Abstractions.Repositories;

namespace BargainMagic.Api.Core.Handlers.Season;

public class DeleteSeasonHandler : IDeleteSeasonHandler
{
    private readonly ISeasonRepository seasonRepository;

    public DeleteSeasonHandler(ISeasonRepository seasonRepository)
    {
        this.seasonRepository = seasonRepository;
    }

    public async Task HandleDeleteSeasonRequest(long seasonId,
                                                CancellationToken cancellationToken)
    {
        await this.seasonRepository.DeleteSeason(seasonId,
                                                 cancellationToken);
    }
}
