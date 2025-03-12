using Game.Application.Extensions;

namespace Game.Application.Games.Queries.GetGameById;

public class GetGameByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetGameByIdQuery, GetGameByIdResult>
{
    public async Task<GetGameByIdResult> Handle(GetGameByIdQuery query, CancellationToken cancellationToken)
    {
        // get game by id using dbContext
        // return result
        var playerId = GameId.Of(query.Id);
        var player = await dbContext.Games.FindAsync([playerId], cancellationToken: cancellationToken);
        if (player is null)
            throw new GameNotFoundException(query.Id);

        return new GetGameByIdResult(player.ToSingleGameDto());
    }
}

