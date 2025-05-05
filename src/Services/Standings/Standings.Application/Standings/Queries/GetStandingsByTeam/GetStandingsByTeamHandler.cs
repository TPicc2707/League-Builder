namespace Standings.Application.Standings.Queries.GetStandingsByTeam;

public class GetStandingsByTeamHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetStandingsByTeamQuery, GetStandingsByTeamResult>
{
    public async Task<GetStandingsByTeamResult> Handle(GetStandingsByTeamQuery query, CancellationToken cancellationToken)
    {
        // get standings by team using dbContext
        // return result

        var standings = await dbContext.Standings
        .AsNoTracking()
                .Where(o => o.TeamId == TeamId.Of(query.TeamId))
                .ToListAsync(cancellationToken);

        var teams = await dbContext.Teams.Where(x => x.Id == TeamId.Of(query.TeamId)).ToListAsync();

        return new GetStandingsByTeamResult(standings.ToStandingsDtoList(teams));
    }
}
