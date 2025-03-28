namespace Stats.Application.Stats.FootballStats.Commands.CreateFootballStats;

public class CreateFootballStatsHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateFootballStatsCommand, CreateFootballStatsResult>
{
    public async Task<CreateFootballStatsResult> Handle(CreateFootballStatsCommand command, CancellationToken cancellationToken)
    {
        var footballStats = CreateNewBasketballStats(command.FootballStats);

        dbContext.FootballStats.Add(footballStats);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateFootballStatsResult(footballStats.Id.Value);
    }

    private Domain.Models.FootballStats CreateNewBasketballStats(FootballStatsDto footballStatsDto)
    {
        var offensiveStats = FootballOffensiveStats.Of(footballStatsDto.OffensiveStats.PassingCompletions, footballStatsDto.OffensiveStats.PassingAttempts,  footballStatsDto.OffensiveStats.PassingYards,
                                                   footballStatsDto.OffensiveStats.LongestPassingPlay, footballStatsDto.OffensiveStats.PassingTouchdowns, footballStatsDto.OffensiveStats.PassingInterceptions,
                                                   footballStatsDto.OffensiveStats.Sacks,  footballStatsDto.OffensiveStats.RushingAttempts, footballStatsDto.OffensiveStats.RushingYards,
                                                   footballStatsDto.OffensiveStats.LongestRushingPlay, footballStatsDto.OffensiveStats.RushingTouchdowns, footballStatsDto.OffensiveStats.RushingFumbles, footballStatsDto.OffensiveStats.RushingFumblesLost,
                                                   footballStatsDto.OffensiveStats.Receptions, footballStatsDto.OffensiveStats.Targets, footballStatsDto.OffensiveStats.ReceivingYards, footballStatsDto.OffensiveStats.ReceivingTouchdowns,
                                                   footballStatsDto.OffensiveStats.ReceivingFumbles, footballStatsDto.OffensiveStats.ReceivingFumblesLost, footballStatsDto.OffensiveStats.YardsAfterCatch);

        var defensiveStats = FootballDefensiveStats.Of(footballStatsDto.DefensiveStats.Tackles, footballStatsDto.DefensiveStats.Sacks, footballStatsDto.DefensiveStats.TacklesForLoss, footballStatsDto.DefensiveStats.PassesDefended,
                                                   footballStatsDto.DefensiveStats.DefensiveInterceptions, footballStatsDto.DefensiveStats.DefensiveInterceptionYards, footballStatsDto.DefensiveStats.LongestDefensiveInterceptionPlay, footballStatsDto.DefensiveStats.DefensiveTouchdowns,
                                                   footballStatsDto.DefensiveStats.ForcedFumbles, footballStatsDto.DefensiveStats.RecoveredFumbles);

        var kickingStats = FootballKickingStats.Of(footballStatsDto.KickingStats.FieldGoalsMade, footballStatsDto.KickingStats.FieldGoalsAttempted, footballStatsDto.KickingStats.ExtraPointsMade,
                                                   footballStatsDto.KickingStats.ExtraPointsAttempted, footballStatsDto.KickingStats.Punts, footballStatsDto.KickingStats.PuntingYards,
                                                   footballStatsDto.KickingStats.LongestPunt);

        var newFootballStats = Domain.Models.FootballStats.Create(
                id: FootballStatsId.Of(Guid.NewGuid()),
                leagueId: LeagueId.Of(footballStatsDto.LeagueId),
                teamId: TeamId.Of(footballStatsDto.TeamId),
                playerId: PlayerId.Of(footballStatsDto.PlayerId),
                seasonId: SeasonId.Of(footballStatsDto.SeasonId),
                gameId: GameId.Of(footballStatsDto.GameId),
                offensiveStats: offensiveStats,
                defensiveStats: defensiveStats,
                kickingStats: kickingStats
                );

        return newFootballStats;

    }
}
