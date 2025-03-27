namespace Team.Application.Teams.Queries.GetTeamsBySport;

public class GetTeamsBySportHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTeamsBySportQuery, GetTeamsBySportResult>
{
    public async Task<GetTeamsBySportResult> Handle(GetTeamsBySportQuery query, CancellationToken cancellationToken)
    {
        //get teams by sport using dbContext
        //return result

        List<Domain.Models.Team> teams = new List<Domain.Models.Team>();

        var leagues = await dbContext.Leagues
                .AsNoTracking()
                .Where(o => o.Sport.Value.Contains(query.Sport))
                .ToListAsync(cancellationToken);

        foreach (var league in leagues)
        {
            var leagueTeams = await dbContext.Teams
                            .AsNoTracking()
                            .Where(o => o.LeagueId == league.Id)
                            .ToListAsync(cancellationToken);

            teams.AddRange(leagueTeams);
        }

        return new GetTeamsBySportResult(teams.ToTeamDtoList());
    }
}
