namespace Standings.Application.Standings.Commands.CreateStandings;

public class CreateStandingsHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateStandingsCommand, CreateStandingsResult>
{
    public async Task<CreateStandingsResult> Handle(CreateStandingsCommand command, CancellationToken cancellationToken)
    {
        var standings = CreateNewStandings(command.Standings);
        dbContext.Standings.Add(standings);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateStandingsResult(standings.Id.Value);
    }

    private Domain.Models.Standings CreateNewStandings(StandingsDto standingsDto)
    {
        var standingsDetail = StandingsDetail.Of(standingsDto.StandingsDetail.GamesPlayed, standingsDto.StandingsDetail.Wins, standingsDto.StandingsDetail.Losses, standingsDto.StandingsDetail.Ties);

        var newStandings = Domain.Models.Standings.Create(
            id: StandingsId.Of(Guid.NewGuid()),
            leagueId: LeagueId.Of(standingsDto.LeagueId),
            teamId: TeamId.Of(standingsDto.Team.Id),
            seasonId: SeasonId.Of(standingsDto.SeasonId),
            standingsDetail: standingsDetail
            );

        return newStandings;
    }
}
