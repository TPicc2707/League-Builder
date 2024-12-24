namespace Stats.Application.Games.Commands.UpdateGame;

public class UpdateGameHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateGameCommand, UpdateGameResult>
{
    public async Task<UpdateGameResult> Handle(UpdateGameCommand command, CancellationToken cancellationToken)
    {
        //Update Game entity from command object
        //save to database
        //return result

        var gameId = GameId.Of(command.Game.Id);
        var game = await dbContext.Games.FindAsync([gameId], cancellationToken: cancellationToken);
        if (game is null)
            throw new GameNotFoundException(command.Game.Id);

        dbContext.Games.Update(game);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateGameResult(true);
    }
}
