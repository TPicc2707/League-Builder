namespace Game.Application.Games.Queries.GetGameById;

public class GetGameByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetGameByIdQuery, GetGameByIdResult>
{
    public async Task<GetGameByIdResult> Handle(GetGameByIdQuery query, CancellationToken cancellationToken)
    {
        // get game by id using dbContext
        // return result
        var gameId = GameId.Of(query.Id);
        var game = await dbContext.Games.FindAsync([gameId], cancellationToken: cancellationToken);
        if (game is null)
            throw new GameNotFoundException(query.Id);

        var awayTeam = await dbContext.Teams.FindAsync([game.AwayTeamId], cancellationToken: cancellationToken);
        var homeTeam = await dbContext.Teams.FindAsync([game.HomeTeamId], cancellationToken: cancellationToken);

        if (awayTeam is null)
            throw new TeamNotFoundException(game.AwayTeamId.Value);

        if (homeTeam is null)
            throw new TeamNotFoundException(game.HomeTeamId.Value);

        return new GetGameByIdResult(game.ToSingleGameDto(awayTeam, homeTeam));
    }
}

