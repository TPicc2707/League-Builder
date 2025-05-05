namespace Game.Application.Games.Commands.DeleteGame;

public class DeleteGameHandler(IApplicationDbContext dbContext, IPublishEndpoint publishEndpoint)
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

        var eventMessage = new GameDeletionEvent()
        {
            Id = command.GameId
        };

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        return new DeleteGameResult(true);
    }
}
