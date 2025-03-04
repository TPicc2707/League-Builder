namespace Stats.Application.Stats.FootballStats.Queries.GetPlayerFootballStatsByGame;

public class GetPlayerFootballStatsByGameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayerFootballStatsByGameQuery, GetPlayerFootballStatsByGameResult>
{
    public async Task<GetPlayerFootballStatsByGameResult> Handle(GetPlayerFootballStatsByGameQuery query, CancellationToken cancellationToken)
    {
        // get player football stats by game using dbContext
        // return result

        var playerId = PlayerId.Of(query.PlayerId);
        var gameId = GameId.Of(query.GameId);
        var footballStat = await dbContext.FootballStats.FirstOrDefaultAsync(b => b.PlayerId == playerId && b.GameId == gameId, cancellationToken: cancellationToken);
        if (footballStat is null)
            throw new PlayerFootballStatsByGameNotFoundException(query.PlayerId);

        return new GetPlayerFootballStatsByGameResult(footballStat.ToSingleFootballStatsDto());
    }
}
