using BargainMagic.Api.Abstractions.Endpoints.Season;
using BargainMagic.Data.Abstractions.Entities;

namespace BargainMagic.Api.Core.Mappers;

public static class SeasonToSeasonDto
{
    public static SeasonDto ToSeasonDto(this Season season)
    {
        return new SeasonDto(id: season.Id,
                             name: season.Name,
                             createdDateTime: season.CreatedDateTime);
    }
}
