namespace Stats.Application.Stats.BaseballStats.Commands.UpdateBaseballStats;

public class UpdateBaseballStatsHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateBaseballStatsCommand, UpdateBaseballStatsResult>
{
    public async Task<UpdateBaseballStatsResult> Handle(UpdateBaseballStatsCommand command, CancellationToken cancellationToken)
    {
        //Update Baseball Stats entity from command object
        //save to database
        //return result

        var baseballStatsId = BaseballStatsId.Of(command.BaseballStats.Id);
        var baseballStats = await dbContext.BaseballStats.FindAsync([baseballStatsId], cancellationToken: cancellationToken);
        if (baseballStats is null)
            throw new BaseballStatsNotFoundException(command.BaseballStats.Id);

        UpdateBaseballStatsWithNewValues(baseballStats, command.BaseballStats);

        dbContext.BaseballStats.Update(baseballStats);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateBaseballStatsResult(true);
    }

    private void UpdateBaseballStatsWithNewValues(Domain.Models.BaseballStats baseballStats, BaseballStatsDto baseballStatsDto)
    {
        var updatedHittingStats = BaseballHittingStats.Of(baseballStatsDto.HittingStats.AtBats, baseballStatsDto.HittingStats.Hits, baseballStatsDto.HittingStats.TotalBases, baseballStatsDto.HittingStats.Runs,
                                                   baseballStatsDto.HittingStats.Doubles, baseballStatsDto.HittingStats.Triples, baseballStatsDto.HittingStats.HomeRuns, baseballStatsDto.HittingStats.RunsBattedIn,
                                                   baseballStatsDto.HittingStats.StolenBases, baseballStatsDto.HittingStats.Strikeouts, baseballStatsDto.HittingStats.Walks, baseballStatsDto.HittingStats.Average, baseballStatsDto.HittingStats.Slugging,
                                                   baseballStatsDto.HittingStats.OnBasePercentage, baseballStatsDto.HittingStats.OnBasePlusSlugging);
        var updatedPitchingStats = BaseballPitchingStats.Of(baseballStatsDto.PitchingStats.Wins, baseballStatsDto.PitchingStats.Losses, baseballStatsDto.PitchingStats.Start, baseballStatsDto.PitchingStats.Saves,
                                                     baseballStatsDto.PitchingStats.Innings, baseballStatsDto.PitchingStats.HitsAllowed, baseballStatsDto.PitchingStats.WalksAllowed, baseballStatsDto.PitchingStats.PitchingStrikeouts,
                                                     baseballStatsDto.PitchingStats.WalksHitsPerInning);

        baseballStats.Update(
                leagueId: LeagueId.Of(baseballStatsDto.LeagueId),
                teamId: TeamId.Of(baseballStatsDto.TeamId),
                playerId: PlayerId.Of(baseballStatsDto.PlayerId),
                seasonId: SeasonId.Of(baseballStatsDto.SeasonId),
                gameId: GameId.Of(baseballStatsDto.GameId),
                hittingStats: updatedHittingStats,
                pitchingStats: updatedPitchingStats);
    }
}
