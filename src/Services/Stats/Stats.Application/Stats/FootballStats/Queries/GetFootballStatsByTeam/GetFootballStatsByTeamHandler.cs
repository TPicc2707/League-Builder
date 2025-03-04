namespace Stats.Application.Stats.FootballStats.Queries.GetFootballStatsByTeam;

public class GetFootballStatsByTeamHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetFootballStatsByTeamQuery, GetFootballStatsByTeamResult>
{
    public async Task<GetFootballStatsByTeamResult> Handle(GetFootballStatsByTeamQuery query, CancellationToken cancellationToken)
    {
        // get football stats by team using dbContext
        // return result

        var footballstats = await dbContext.FootballStats
        .AsNoTracking()
                .Where(o => o.TeamId == TeamId.Of(query.TeamId))
                .ToListAsync(cancellationToken);

        return new GetFootballStatsByTeamResult(footballstats.ToFootballStatsDtoList());
    }
}
