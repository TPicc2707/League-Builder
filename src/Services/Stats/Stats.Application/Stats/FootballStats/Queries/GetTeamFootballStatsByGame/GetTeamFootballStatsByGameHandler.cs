namespace Stats.Application.Stats.FootballStats.Queries.GetTeamFootballStatsByGame;

public class GetTeamFootballStatsByGameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTeamFootballStatsByGameQuery, GetTeamFootballStatsByGameResult>
{
    public async Task<GetTeamFootballStatsByGameResult> Handle(GetTeamFootballStatsByGameQuery query, CancellationToken cancellationToken)
    {
        // get team football stats by game using dbContext
        // return result
        var footballStats = await dbContext.FootballStats.AsNoTracking()
                .Where(o => o.TeamId == TeamId.Of(query.TeamId) && o.GameId == GameId.Of(query.GameId))
                .ToListAsync(cancellationToken);

        return new GetTeamFootballStatsByGameResult(footballStats.ToFootballStatsDtoList());
    }
}