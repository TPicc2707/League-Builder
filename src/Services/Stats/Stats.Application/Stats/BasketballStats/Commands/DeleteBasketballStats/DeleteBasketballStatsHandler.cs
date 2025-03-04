namespace Stats.Application.Stats.BasketballStats.Commands.DeleteBasketballStats;

public class DeleteBasketballStatsHandler(IApplicationDbContext dbContext) :
    ICommandHandler<DeleteBasketballStatsCommand, DeleteBasketballStatsResult>
{
    public async Task<DeleteBasketballStatsResult> Handle(DeleteBasketballStatsCommand command, CancellationToken cancellationToken)
    {
        //Delete Basketball Stats enity from command object
        //save to database
        //return result

        var basketballStatsId = BasketballStatsId.Of(command.BasketballStatsId);
        var basketballStats = await dbContext.BasketballStats
            .FindAsync([basketballStatsId], cancellationToken: cancellationToken);

        if (basketballStats == null)
        {
            throw new BasketballStatsNotFoundException(command.BasketballStatsId);
        }

        dbContext.BasketballStats.Remove(basketballStats);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteBasketballStatsResult(true);
    }
}
