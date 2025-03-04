namespace Stats.Application.Stats.BaseballStats.Queries.GetLeagueBaseballStatsBySeason;

public class GetLeagueBaseballStatsBySeasonHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetLeagueBaseballStatsBySeasonQuery, GetLeagueBaseballStatsBySeasonResult>
{
    public async Task<GetLeagueBaseballStatsBySeasonResult> Handle(GetLeagueBaseballStatsBySeasonQuery query, CancellationToken cancellationToken)
    {
        // get league baseball stats by season using dbContext
        // return result

        var baseballStats = await dbContext.BaseballStats.AsNoTracking()
                .Where(o => o.LeagueId == LeagueId.Of(query.LeagueId) && o.SeasonId == SeasonId.Of(query.SeasonId))
                .ToListAsync(cancellationToken);

        return new GetLeagueBaseballStatsBySeasonResult(baseballStats.ToBaseballStatsDtoList());
    }
}