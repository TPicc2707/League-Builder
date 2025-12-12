namespace Game.Application.GameLineup.Queries.GetBaseballGameLineupByGameId;

public class GetBaseballGameLineupByGameIdQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBaseballGameLineupByGameIdQuery, GetBaseballGameLineupByGameIdResult>
{
    public async Task<GetBaseballGameLineupByGameIdResult> Handle(GetBaseballGameLineupByGameIdQuery query, CancellationToken cancellationToken)
    {
        var gameId = GameId.Of(query.GameId);
        var teamId = TeamId.Of(query.TeamId);
        var gameLineup = await dbContext.GameLineups.FirstOrDefaultAsync(x => x.GameId == gameId && x.TeamId == teamId);
        if (gameLineup is null)
            throw new GameNotFoundException(query.GameId);

        var team = await dbContext.Teams.FindAsync([gameLineup.TeamId], cancellationToken: cancellationToken);

        if (team is null)
            throw new TeamNotFoundException(gameLineup.TeamId.Value);

        return new GetBaseballGameLineupByGameIdResult(gameLineup.ToSingleBaseballGameLineupDto(team));
    }
}
