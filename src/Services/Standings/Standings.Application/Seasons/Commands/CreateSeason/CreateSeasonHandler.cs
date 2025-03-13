namespace Standings.Application.Seasons.Commands.CreateSeason;

public class CreateSeasonHandler(IApplicationDbContext dbContext)
     : ICommandHandler<CreateSeasonCommand, CreateSeasonResult>
{
    public async Task<CreateSeasonResult> Handle(CreateSeasonCommand command, CancellationToken cancellationToken)
    {
        var season = CreateNewSeason(command.Season);

        dbContext.Seasons.Add(season);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CreateSeasonResult(season.Id.Value);
    }

    private Season CreateNewSeason(SeasonDto seasonDto)
    {

        var newSeason = Season.Create(
                id: SeasonId.Of(seasonDto.Id),
                year: seasonDto.Year
                );

        return newSeason;
    }
}
