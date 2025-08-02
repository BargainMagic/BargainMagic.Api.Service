namespace BargainMagic.Api.Abstractions.Handlers.Season;

public interface IDeleteSeasonHandler
{
    Task HandleDeleteSeasonRequest(long seasonId,
                                   CancellationToken cancellationToken);
}
