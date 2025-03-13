namespace Standings.Application.Seasons.Commands.DeleteSeason;

public class DeleteSeasonHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteSeasonCommand, DeleteSeasonResult>
{
    public async Task<DeleteSeasonResult> Handle(DeleteSeasonCommand command, CancellationToken cancellationToken)
    {
        //Delete Season enity from command object
        //save to database
        //return result

        var seasonId = SeasonId.Of(command.SeasonId);
        var season = await dbContext.Seasons
            .FindAsync([seasonId], cancellationToken: cancellationToken);

        if (season == null)
        {
            throw new SeasonNotFoundException(command.SeasonId);
        }

        dbContext.Seasons.Remove(season);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteSeasonResult(true);
    }
}
