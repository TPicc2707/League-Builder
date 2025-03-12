namespace Game.Application.Games.Commands.UpdateGame;

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

        await UpdateNewGameWithNewValues(game, command.Game);

        dbContext.Games.Update(game);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateGameResult(true);
    }

    private async Task UpdateNewGameWithNewValues(Domain.Models.Game game, GameDto gameDto)
    {
        var updatedGameDetail = GameDetail.Of(gameDto.GameDetail.AwayTeamScore, gameDto.GameDetail.HomeTeamScore, gameDto.GameDetail.StartTime, gameDto.GameDetail.EndTime);

        game.Update(
            leagueId: LeagueId.Of(gameDto.LeagueId),
            awayTeamId: TeamId.Of(gameDto.AwayTeamId),
            homeTeamId: TeamId.Of(gameDto.HomeTeamId),
            winningTeamId: gameDto.WinningTeamId != null ? TeamId.Of((Guid)gameDto.WinningTeamId) : null,
            seasonId: SeasonId.Of(gameDto.SeasonId),
            gameDetail: updatedGameDetail,
            gameStatus: gameDto.GameStatus
            );
    }
}
