namespace Stats.Application.Games.Commands.DeleteGame;

public class DeleteGameHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteGameCommand, DeleteGameResult>
{
    public async Task<DeleteGameResult> Handle(DeleteGameCommand command, CancellationToken cancellationToken)
    {
        //Delete Game enity from command object
        //save to database
        //return result

        var gameId = GameId.Of(command.GameId);
        var game = await dbContext.Games
            .FindAsync([gameId], cancellationToken: cancellationToken);

        if (game == null)
        {
            throw new GameNotFoundException(command.GameId);
        }

        dbContext.Games.Remove(game);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteGameResult(true);
    }
}