namespace Stats.Application.Stats.BaseballStats.Commands.CreateBaseballStats;

public class CreateBaseballStatsHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateBaseballStatsCommand, CreateBaseballStatsResult>
{
    public async Task<CreateBaseballStatsResult> Handle(CreateBaseballStatsCommand command, CancellationToken cancellationToken)
    {
        var baseballStats = CreateNewBaseballStats(command.BaseballStats);

        dbContext.BaseballStats.Add(baseballStats);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateBaseballStatsResult(baseballStats.Id.Value);
    }

    private Domain.Models.BaseballStats CreateNewBaseballStats(BaseballStatsDto baseballStatsDto)
    {
        var hittingStats = BaseballHittingStats.Of(baseballStatsDto.HittingStats.AtBats, baseballStatsDto.HittingStats.Hits, baseballStatsDto.HittingStats.TotalBases, baseballStatsDto.HittingStats.Runs,
                                                   baseballStatsDto.HittingStats.Doubles, baseballStatsDto.HittingStats.Triples, baseballStatsDto.HittingStats.HomeRuns, baseballStatsDto.HittingStats.RunsBattedIn,
                                                   baseballStatsDto.HittingStats.StolenBases, baseballStatsDto.HittingStats.Strikeouts, baseballStatsDto.HittingStats.Walks, 
                                                   baseballStatsDto.HittingStats.HitByPitch, baseballStatsDto.HittingStats.SacrificeFly);
        var pitchingStats = BaseballPitchingStats.Of(baseballStatsDto.PitchingStats.Wins, baseballStatsDto.PitchingStats.Losses, baseballStatsDto.PitchingStats.Start, baseballStatsDto.PitchingStats.Saves,
                                                     baseballStatsDto.PitchingStats.Innings, baseballStatsDto.PitchingStats.HitsAllowed, baseballStatsDto.PitchingStats.WalksAllowed, baseballStatsDto.PitchingStats.PitchingStrikeouts);

        var newBaseballStats = Domain.Models.BaseballStats.Create(
                id: BaseballStatsId.Of(Guid.NewGuid()),
                leagueId: LeagueId.Of(baseballStatsDto.LeagueId),
                teamId: TeamId.Of(baseballStatsDto.TeamId),
                playerId: PlayerId.Of(baseballStatsDto.PlayerId),
                seasonId: SeasonId.Of(baseballStatsDto.SeasonId),
                gameId: GameId.Of(baseballStatsDto.GameId),
                hittingStats: hittingStats,
                pitchingStats: pitchingStats
                );

        return newBaseballStats;
    }
}