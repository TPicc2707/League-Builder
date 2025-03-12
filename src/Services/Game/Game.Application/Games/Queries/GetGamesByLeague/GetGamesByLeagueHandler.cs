namespace Game.Application.Games.Queries.GetGamesByLeague;

public class GetGamesByLeagueHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetGamesByLeagueQuery, GetGamesByLeagueResult>
{
    public async Task<GetGamesByLeagueResult> Handle(GetGamesByLeagueQuery query, CancellationToken cancellationToken)
    {
        // get games by league using dbContext
        // return result

        var games = await dbContext.Games
        .AsNoTracking()
                .Where(o => o.LeagueId == LeagueId.Of(query.LeagueId))
                .ToListAsync(cancellationToken);

        return new GetGamesByLeagueResult(games.ToGameDtoList());
    }
}
