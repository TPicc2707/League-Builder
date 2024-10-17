namespace Player.Application.Players.Queries.GetPlayersByTeam;

public class GetPlayersByTeamHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPlayersByTeamQuery, GetPlayersByTeamResult>
{
    public async Task<GetPlayersByTeamResult> Handle(GetPlayersByTeamQuery query, CancellationToken cancellationToken)
    {
        // get players by team using dbContext
        // return result

        var players = await dbContext.Players
        .AsNoTracking()
                .Where(o => o.TeamId == TeamId.Of(query.TeamId))
                .OrderBy(o => o.FirstName.Value)
                .ThenBy(o => o.LastName.Value)
                .ToListAsync(cancellationToken);

        return new GetPlayersByTeamResult(players.ToPlayerDtoList());
    }
}
