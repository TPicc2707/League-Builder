namespace Game.Application.GameLineup.Commands.DeleteBaseballGameLineup;

public class DeleteBaseballGameLineupHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteBaseballGameLineupCommand, DeleteBaseballGameLineupResult>
{
    public async Task<DeleteBaseballGameLineupResult> Handle(DeleteBaseballGameLineupCommand command, CancellationToken cancellationToken)
    {
        var gameLineupId = GameId.Of(command.GameLineupId);
        var gameLineup = await dbContext.GameLineups
            .FindAsync([gameLineupId], cancellationToken: cancellationToken);

        if (gameLineup == null)
        {
            throw new GameLineupNotFoundException(command.GameLineupId);
        }

        dbContext.GameLineups.Remove(gameLineup);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteBaseballGameLineupResult(true);
    }
}
