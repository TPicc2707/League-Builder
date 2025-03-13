namespace Standings.Application.Standings.Queries.GetStandingsByLeague;

public class GetStandingsByLeagueHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetStandingsByLeagueQuery, GetStandingsByLeagueResult>
{
    public async Task<GetStandingsByLeagueResult> Handle(GetStandingsByLeagueQuery query, CancellationToken cancellationToken)
    {
        // get standings by league using dbContext
        // return result

        var standings = await dbContext.Standings
        .AsNoTracking()
                .Where(o => o.LeagueId == LeagueId.Of(query.LeagueId))
                .ToListAsync(cancellationToken);

        return new GetStandingsByLeagueResult(standings.ToStandingsDtoList());
    }
}
