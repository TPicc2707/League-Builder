namespace Game.Application.Games.Queries.GetGamesByTeam;

public class GetGamesByTeamHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetGamesByTeamQuery, GetGamesByTeamResult>
{
    public async Task<GetGamesByTeamResult> Handle(GetGamesByTeamQuery query, CancellationToken cancellationToken)
    {
        // get games by team using dbContext
        // return result

        var games = await dbContext.Games
        .AsNoTracking()
                .Where(o => o.AwayTeamId == TeamId.Of(query.TeamId) || o.HomeTeamId == TeamId.Of(query.TeamId))
                .ToListAsync(cancellationToken);

        return new GetGamesByTeamResult(games.ToGameDtoList());
    }
}
