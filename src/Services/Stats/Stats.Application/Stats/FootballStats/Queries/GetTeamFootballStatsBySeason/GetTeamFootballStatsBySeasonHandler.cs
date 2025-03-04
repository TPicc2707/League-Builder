namespace Stats.Application.Stats.FootballStats.Queries.GetTeamFootballStatsBySeason;

public class GetTeamFootballStatsBySeasonHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTeamFootballStatsBySeasonQuery, GetTeamFootballStatsBySeasonResult>
{
    public async Task<GetTeamFootballStatsBySeasonResult> Handle(GetTeamFootballStatsBySeasonQuery query, CancellationToken cancellationToken)
    {
        // get team football stats by season using dbContext
        // return result

        var footballStats = await dbContext.FootballStats.AsNoTracking()
                .Where(o => o.TeamId == TeamId.Of(query.TeamId) && o.SeasonId == SeasonId.Of(query.SeasonId))
                .ToListAsync(cancellationToken);

        return new GetTeamFootballStatsBySeasonResult(footballStats.ToFootballStatsDtoList());
    }
}