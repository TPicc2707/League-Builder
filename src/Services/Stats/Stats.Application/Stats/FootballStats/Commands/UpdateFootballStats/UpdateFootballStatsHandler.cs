namespace Stats.Application.Stats.FootballStats.Commands.UpdateFootballStats;

public class UpdateFootballStatsHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateFootballStatsCommand, UpdateFootballStatsResult>
{
    public async Task<UpdateFootballStatsResult> Handle(UpdateFootballStatsCommand command, CancellationToken cancellationToken)
    {
        //Update Football Stats entity from command object
        //save to database
        //return result

        var footballStatsId = FootballStatsId.Of(command.FootballStats.Id);
        var footballStats = await dbContext.FootballStats.FindAsync([footballStatsId], cancellationToken: cancellationToken);
        if (footballStats is null)
            throw new FootballStatsNotFoundException(command.FootballStats.Id);

        UpdateBasketballStatsWithNewValues(footballStats, command.FootballStats);

        dbContext.FootballStats.Update(footballStats);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateFootballStatsResult(true);

    }

    private void UpdateBasketballStatsWithNewValues(Domain.Models.FootballStats footballStats, FootballStatsDto footballStatsDto)
    {
        var offensiveStats = FootballOffensiveStats.Of(footballStatsDto.OffensiveStats.PassingCompletions, footballStatsDto.OffensiveStats.PassingAttempts, footballStatsDto.OffensiveStats.PassingCompletionPercentage, footballStatsDto.OffensiveStats.PassingYards,
                                                   footballStatsDto.OffensiveStats.PassingYardsPerPlay, footballStatsDto.OffensiveStats.LongestPassingPlay, footballStatsDto.OffensiveStats.PassingTouchdowns, footballStatsDto.OffensiveStats.PassingInterceptions,
                                                   footballStatsDto.OffensiveStats.Sacks, footballStatsDto.OffensiveStats.PasserRating, footballStatsDto.OffensiveStats.RushingAttempts, footballStatsDto.OffensiveStats.RushingYards, footballStatsDto.OffensiveStats.RushingYardsAverage,
                                                   footballStatsDto.OffensiveStats.LongestRushingPlay, footballStatsDto.OffensiveStats.RushingTouchdowns, footballStatsDto.OffensiveStats.RushingFumbles, footballStatsDto.OffensiveStats.RushingFumblesLost,
                                                   footballStatsDto.OffensiveStats.Receptions, footballStatsDto.OffensiveStats.Targets, footballStatsDto.OffensiveStats.ReceivingYards, footballStatsDto.OffensiveStats.ReceivingYardsPerPlay, footballStatsDto.OffensiveStats.ReceivingTouchdowns,
                                                   footballStatsDto.OffensiveStats.ReceivingFumbles, footballStatsDto.OffensiveStats.ReceivingFumblesLost, footballStatsDto.OffensiveStats.YardsAfterCatch);

        var defensiveStats = FootballDefensiveStats.Of(footballStatsDto.DefensiveStats.Tackles, footballStatsDto.DefensiveStats.Sacks, footballStatsDto.DefensiveStats.TacklesForLoss, footballStatsDto.DefensiveStats.PassesDefended,
                                                   footballStatsDto.DefensiveStats.DefensiveInterceptions, footballStatsDto.DefensiveStats.DefensiveInterceptionYards, footballStatsDto.DefensiveStats.LongestDefensiveInterceptionPlay, footballStatsDto.DefensiveStats.DefensiveTouchdowns,
                                                   footballStatsDto.DefensiveStats.ForcedFumbles, footballStatsDto.DefensiveStats.RecoveredFumbles);

        var kickingStats = FootballKickingStats.Of(footballStatsDto.KickingStats.FieldGoalsMade, footballStatsDto.KickingStats.FieldGoalsAttempted, footballStatsDto.KickingStats.FieldGoalPercentage, footballStatsDto.KickingStats.ExtraPointsMade,
                                                   footballStatsDto.KickingStats.ExtraPointsAttempted, footballStatsDto.KickingStats.ExtraPointPercentage, footballStatsDto.KickingStats.Punts, footballStatsDto.KickingStats.PuntingYards,
                                                   footballStatsDto.KickingStats.LongestPunt);

        footballStats.Update(
                leagueId: LeagueId.Of(footballStatsDto.LeagueId),
                teamId: TeamId.Of(footballStatsDto.TeamId),
                playerId: PlayerId.Of(footballStatsDto.PlayerId),
                seasonId: SeasonId.Of(footballStatsDto.SeasonId),
                gameId: GameId.Of(footballStatsDto.GameId),
                offensiveStats: offensiveStats,
                defensiveStats: defensiveStats,
                kickingStats: kickingStats);

    }

}
