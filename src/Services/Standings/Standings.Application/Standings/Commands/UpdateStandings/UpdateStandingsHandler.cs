namespace Standings.Application.Standings.Commands.UpdateStandings;

public class UpdateStandingsHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateStandingsCommand, UpdateStandingsResult>
{
    public async Task<UpdateStandingsResult> Handle(UpdateStandingsCommand command, CancellationToken cancellationToken)
    {
        //Update Standings entity from command object
        //save to database
        //return result

        var standingsId = StandingsId.Of(command.Standings.Id);
        var standings = await dbContext.Standings.FindAsync([standingsId], cancellationToken: cancellationToken);

        if (standings is null)
            throw new StandingsNotFoundException(command.Standings.Id);

        await UpdateNewStandingsWithNewValues(standings, command.Standings);

        dbContext.Standings.Update(standings);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateStandingsResult(true);
    }

    private async Task UpdateNewStandingsWithNewValues(Domain.Models.Standings standings, StandingsDto standingsDto)
    {
        var updatedStandingsDetail = StandingsDetail.Of(standingsDto.StandingsDetail.GamesPlayed, standingsDto.StandingsDetail.Wins, standingsDto.StandingsDetail.Losses, standingsDto.StandingsDetail.Ties, standingsDto.StandingsDetail.PlayoffTeam, standingsDto.StandingsDetail.Champion);

        standings.Update(
            leagueId: LeagueId.Of(standingsDto.LeagueId),
            teamId: TeamId.Of(standingsDto.Team.Id),
            seasonId: SeasonId.Of(standingsDto.SeasonId),
            standingsDetail: updatedStandingsDetail,
            standingsStatus: standingsDto.StandingsStatus
            );
    }
}
