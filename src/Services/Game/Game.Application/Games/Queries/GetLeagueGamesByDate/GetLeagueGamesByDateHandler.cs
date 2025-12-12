namespace Game.Application.Games.Queries.GetLeagueGamesByDate;

public class GetLeagueGamesByDateHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetLeagueGamesByDateQuery, GetLeagueGamesByDateResult>
{
    public async Task<GetLeagueGamesByDateResult> Handle(GetLeagueGamesByDateQuery query, CancellationToken cancellationToken)
    {
        var games = await dbContext.Games
                .AsNoTracking()
                .Where(o => o.LeagueId == LeagueId.Of(query.LeagueId))
                .ToListAsync(cancellationToken);

        games = games.Where(o => o.GameDetail.StartTime.ToShortDateString() == query.Date.ToShortDateString()).ToList();

        var teams = await dbContext.Teams.AsNoTracking().ToListAsync();

        return new GetLeagueGamesByDateResult(games.ToGameDtoList(teams));
    }
}
