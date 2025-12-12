namespace Game.Application.GameLineup.Commands.CreateBaseballGameLineup;

public class CreateBaseballGameHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateBaseballGameLineupCommand, CreateBaseballGameLineupResult>
{
    public async Task<CreateBaseballGameLineupResult> Handle(CreateBaseballGameLineupCommand command, CancellationToken cancellationToken)
    {
        var gameLineup = CreateNewGameLineup(command.GameLineup);

        dbContext.GameLineups.Add(gameLineup);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateBaseballGameLineupResult(gameLineup.Id.Value);
    }

    private Domain.Models.GameLineup CreateNewGameLineup(GameLineupDto gameLineupDto)
    {
        var baseballLineup = BaseballGameLineup.Of(
            first: gameLineupDto.BaseballLineup.First,
            second: gameLineupDto.BaseballLineup.Second,
            third: gameLineupDto.BaseballLineup.Third,
            fourth: gameLineupDto.BaseballLineup.Fourth,
            fifth: gameLineupDto.BaseballLineup.Fifth,
            sixth: gameLineupDto.BaseballLineup.Sixth,
            seventh: gameLineupDto.BaseballLineup.Seventh,
            eighth: gameLineupDto.BaseballLineup.Eighth,
            ninth: gameLineupDto.BaseballLineup.Ninth,
            startingPitcher: gameLineupDto.BaseballLineup.StartingPitcher
            );
        var newGameLineup = Domain.Models.GameLineup.CreateBaseballLineup(
            id: GameLineupId.Of(Guid.NewGuid()),
            gameId: GameId.Of(gameLineupDto.GameId),
            teamId: TeamId.Of(gameLineupDto.TeamId),
            baseballLineup: baseballLineup
            );
        return newGameLineup;
    }
}