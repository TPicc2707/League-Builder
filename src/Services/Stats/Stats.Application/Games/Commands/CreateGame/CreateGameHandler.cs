namespace Stats.Application.Games.Commands.CreateGame;

public class CreateGameHandler(IApplicationDbContext dbContext)
     : ICommandHandler<CreateGameCommand, CreateGameResult>
{
    public async Task<CreateGameResult> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        var game = CreateNewGame(command.Game);

        dbContext.Games.Add(game);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CreateGameResult(game.Id.Value);
    }

    private Game CreateNewGame(GameDto gameDto)
    {

        var newGame = Game.Create(
                id: GameId.Of(gameDto.Id)
                );

        return newGame;
    }
}
