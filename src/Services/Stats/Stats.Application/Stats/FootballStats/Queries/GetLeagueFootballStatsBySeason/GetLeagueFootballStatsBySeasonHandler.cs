namespace Stats.Application.Stats.FootballStats.Queries.GetLeagueFootballStatsBySeason;

public class GetLeagueFootballStatsBySeasonHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetLeagueFootballStatsBySeasonQuery, GetLeagueFootballStatsBySeasonResult>
{
    public async Task<GetLeagueFootballStatsBySeasonResult> Handle(GetLeagueFootballStatsBySeasonQuery query, CancellationToken cancellationToken)
    {
        // get league football stats by season using dbContext
        // return result

        var footballStats = await dbContext.FootballStats.AsNoTracking()
                .Where(o => o.LeagueId == LeagueId.Of(query.LeagueId) && o.SeasonId == SeasonId.Of(query.SeasonId))
                .ToListAsync(cancellationToken);

        return new GetLeagueFootballStatsBySeasonResult(footballStats.ToFootballStatsDtoList());
    }
}

