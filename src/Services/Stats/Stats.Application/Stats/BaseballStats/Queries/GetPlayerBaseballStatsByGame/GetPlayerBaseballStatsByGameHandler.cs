namespace Stats.Application.Stats.BaseballStats.Queries.GetPlayerBaseballStatsByGame;

public class GetPlayerBaseballStatsByGameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayerBaseballStatsByGameQuery, GetPlayerBaseballStatsByGameResult>
{
    public async Task<GetPlayerBaseballStatsByGameResult> Handle(GetPlayerBaseballStatsByGameQuery query, CancellationToken cancellationToken)
    {
        // get player baseball stats by game using dbContext
        // return result

        var playerId = PlayerId.Of(query.PlayerId);
        var gameId = GameId.Of(query.GameId);
        var baseballStat = await dbContext.BaseballStats.FirstOrDefaultAsync(b => b.PlayerId == playerId && b.GameId == gameId, cancellationToken: cancellationToken);
        if (baseballStat is null)
            throw new PlayerBaseballStatsByGameNotFoundException(query.PlayerId);

        return new GetPlayerBaseballStatsByGameResult(baseballStat.ToSingleBaseballStatsDto());
    }
}