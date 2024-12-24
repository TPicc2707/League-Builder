namespace Stats.Application.Players.Commands.DeletePlayer;

public class DeletePlayerHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeletePlayerCommand, DeletePlayerResult>
{
    public async Task<DeletePlayerResult> Handle(DeletePlayerCommand command, CancellationToken cancellationToken)
    {
        //Delete Player enity from command object
        //save to database
        //return result

        var playerId = PlayerId.Of(command.PlayerId);
        var player = await dbContext.Players
            .FindAsync([playerId], cancellationToken: cancellationToken);

        if (player == null)
        {
            throw new PlayerNotFoundException(command.PlayerId);
        }

        dbContext.Players.Remove(player);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeletePlayerResult(true);
    }
}
