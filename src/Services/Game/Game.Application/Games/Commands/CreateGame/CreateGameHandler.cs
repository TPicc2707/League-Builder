namespace Game.Application.Games.Commands.CreateGame;

public class CreateGameHandler(IApplicationDbContext dbContext, IBus _bus)
    : ICommandHandler<CreateGameCommand, CreateGameResult>
{
    public async Task<CreateGameResult> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        var game = CreateNewGame(command.Game);

        dbContext.Games.Add(game);
        await dbContext.SaveChangesAsync(cancellationToken);

        var eventMessage = new GameCreationEvent()
        {
            Id = game.Id.Value
        };

        await _bus.Publish(eventMessage);

        return new CreateGameResult(game.Id.Value);
    }

    private Domain.Models.Game CreateNewGame(GameDto gameDto)
    {
        var gameDetail = GameDetail.Of(gameDto.GameDetail.AwayTeamScore, gameDto.GameDetail.HomeTeamScore, gameDto.GameDetail.StartTime, gameDto.GameDetail.EndTime);

        var newGame = Domain.Models.Game.Create(
            id: GameId.Of(Guid.NewGuid()),
            leagueId: LeagueId.Of(gameDto.LeagueId),
            awayTeamId: TeamId.Of(gameDto.AwayTeam.Id),
            homeTeamId: TeamId.Of(gameDto.HomeTeam.Id),
            seasonId: SeasonId.Of(gameDto.SeasonId),
            gameDetail: gameDetail
            );

        return newGame;
    }
}
