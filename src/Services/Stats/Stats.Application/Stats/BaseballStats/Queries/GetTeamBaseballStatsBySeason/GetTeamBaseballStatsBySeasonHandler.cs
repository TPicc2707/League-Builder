namespace Stats.Application.Stats.BaseballStats.Queries.GetTeamBaseballStatsBySeason;

public class GetTeamBaseballStatsBySeasonHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTeamBaseballStatsBySeasonQuery, GetTeamBaseballStatsBySeasonResult>
{
    public async Task<GetTeamBaseballStatsBySeasonResult> Handle(GetTeamBaseballStatsBySeasonQuery query, CancellationToken cancellationToken)
    {
        // get team baseball stats by season using dbContext
        // return result

        var baseballStats = await dbContext.BaseballStats.AsNoTracking()
                .Where(o => o.TeamId == TeamId.Of(query.TeamId) && o.SeasonId == SeasonId.Of(query.SeasonId))
                .ToListAsync(cancellationToken);

        return new GetTeamBaseballStatsBySeasonResult(baseballStats.ToBaseballStatsDtoList());
    }
}