namespace Standings.Application.Seasons.Commands.UpdateSeason;

public class UpdateSeasonHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateSeasonCommand, UpdateSeasonResult>
{
    public async Task<UpdateSeasonResult> Handle(UpdateSeasonCommand command, CancellationToken cancellationToken)
    {
        //Update Season entity from command object
        //save to database
        //return result

        var seasonId = SeasonId.Of(command.Season.Id);
        var season = await dbContext.Seasons.FindAsync([seasonId], cancellationToken: cancellationToken);
        if (season is null)
            throw new SeasonNotFoundException(command.Season.Id);

        UpdateSeasonWithNewValues(season, command.Season);

        dbContext.Seasons.Update(season);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateSeasonResult(true);
    }

    private void UpdateSeasonWithNewValues(Season season, SeasonDto seasonDto)
    {
        season.Update(
            year: seasonDto.Year);
    }
}
