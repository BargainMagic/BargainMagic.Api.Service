using BargainMagic.Api.Abstractions.Endpoints.Season;
using BargainMagic.Api.Abstractions.Handlers.Season;

namespace BargainMagic.Api.Core.Handlers.Season;

public class GetSeasonsHandler : IGetSeasonsHandler
{
    public async Task<List<SeasonDto>> HandleGetSeasonsRequest()
    {
        // TODO: This should pull from a data store.
        return new List<SeasonDto>
               {
                   new SeasonDto(name: "TestSeason01",
                                 createdDateTime: DateTime.UtcNow.Subtract(TimeSpan.FromHours(96))),
                   new SeasonDto(name: "TestSeason02",
                                 createdDateTime: DateTime.UtcNow.Subtract(TimeSpan.FromHours(48))),
                   new SeasonDto(name: "TestSeason03",
                                 createdDateTime: DateTime.UtcNow),
               };
    }
}
