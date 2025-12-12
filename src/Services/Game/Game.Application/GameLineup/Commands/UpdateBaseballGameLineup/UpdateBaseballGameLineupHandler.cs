namespace Game.Application.GameLineup.Commands.UpdateBaseballGameLineup;

internal class UpdateBaseballGameLineupHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateBaseballGameLineupCommand, UpdateBaseballGameLineupResult>
{
    public async Task<UpdateBaseballGameLineupResult> Handle(UpdateBaseballGameLineupCommand command, CancellationToken cancellationToken)
    {
        var gameLineupId = GameLineupId.Of(command.GameLineup.Id);
        var gameLineup = await dbContext.GameLineups.FindAsync([gameLineupId], cancellationToken: cancellationToken);

        if (gameLineup is null)
            throw new GameLineupNotFoundException(command.GameLineup.Id);

        await UpdateNewGameLineupWithNewValues(gameLineup, command.GameLineup);

        dbContext.GameLineups.Update(gameLineup);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateBaseballGameLineupResult(true);
    }

    private async Task UpdateNewGameLineupWithNewValues(Domain.Models.GameLineup gameLineup, GameLineupDto gameLineupDto)
    {
        var updatedBaseballGameLineup = BaseballGameLineup.Of(gameLineupDto.BaseballLineup.First, gameLineupDto.BaseballLineup.Second, gameLineupDto.BaseballLineup.Third, gameLineupDto.BaseballLineup.Fourth,
                                                              gameLineupDto.BaseballLineup.Fifth, gameLineupDto.BaseballLineup.Sixth, gameLineupDto.BaseballLineup.Seventh, gameLineupDto.BaseballLineup.Eighth,
                                                              gameLineupDto.BaseballLineup.Ninth, gameLineupDto.BaseballLineup.StartingPitcher);

        gameLineup.UpdateBaseballLineup(
            gameId: GameId.Of(gameLineupDto.GameId),
            teamId: TeamId.Of(gameLineupDto.TeamId),
            baseballLineup: updatedBaseballGameLineup
            );
    }
}
