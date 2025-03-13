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

        return new GetGameByIdResult(game.ToSingleGameDto());
    }
}

