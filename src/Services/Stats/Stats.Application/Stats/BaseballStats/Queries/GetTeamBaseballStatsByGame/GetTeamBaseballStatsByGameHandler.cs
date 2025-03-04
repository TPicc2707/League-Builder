namespace Stats.Application.Stats.BaseballStats.Queries.GetTeamBaseballStatsByGame;

public class GetTeamBaseballStatsByGameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTeamBaseballStatsByGameQuery, GetTeamBaseballStatsByGameResult>
{
    public async Task<GetTeamBaseballStatsByGameResult> Handle(GetTeamBaseballStatsByGameQuery query, CancellationToken cancellationToken)
    {
        // get team baseball stats by game using dbContext
        // return result
        var baseballStats = await dbContext.BaseballStats.AsNoTracking()
                .Where(o => o.TeamId == TeamId.Of(query.TeamId) && o.GameId == GameId.Of(query.GameId))
                .ToListAsync(cancellationToken);

        return new GetTeamBaseballStatsByGameResult(baseballStats.ToBaseballStatsDtoList());
    }
}