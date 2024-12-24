namespace Stats.Application.Stats.BaseballStats.Commands.DeleteBaseballStats;

public class DeleteBaseballStatsHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteBaseballStatsCommand, DeleteBaseballStatsResult>
{
    public async Task<DeleteBaseballStatsResult> Handle(DeleteBaseballStatsCommand command, CancellationToken cancellationToken)
    {
        //Delete Baseball Stats enity from command object
        //save to database
        //return result

        var baseballStatsId = BaseballStatsId.Of(command.BaseballStatsId);
        var baseballStats = await dbContext.BaseballStats
            .FindAsync([baseballStatsId], cancellationToken: cancellationToken);

        if (baseballStats == null)
        {
            throw new BaseballStatsNotFoundException(command.BaseballStatsId);
        }

        dbContext.BaseballStats.Remove(baseballStats);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteBaseballStatsResult(true);
    }
}
