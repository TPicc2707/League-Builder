namespace Game.Application.GameLineup.Queries.AnyBaseballGameLineupByGameId;

public class AnyBaseballGameLineupByGameIdQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<AnyBaseballGameLineupByGameIdQuery, AnyBaseballGameLineupByGameIdResult>
{
    public async Task<AnyBaseballGameLineupByGameIdResult> Handle(AnyBaseballGameLineupByGameIdQuery query, CancellationToken cancellationToken)
    {
        var gameId = GameId.Of(query.GameId);
        var teamId = TeamId.Of(query.TeamId);
        var gameLineup = await dbContext.GameLineups.AnyAsync(x => x.GameId == gameId && x.TeamId == teamId);

        return new AnyBaseballGameLineupByGameIdResult(gameLineup);
    }
}
