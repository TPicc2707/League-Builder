namespace Stats.Application.Extensions;

public static class FootballStatsExtension
{
    public static IEnumerable<FootballStatsDto> ToFootballStatsDtoList(this IEnumerable<FootballStats> stats)
    {
        return stats.Select(stats => new FootballStatsDto(
            Id: stats.Id.Value,
            LeagueId: stats.LeagueId.Value,
            TeamId: stats.TeamId.Value,
            PlayerId: stats.PlayerId.Value,
            SeasonId: stats.SeasonId.Value,
            GameId: stats.GameId.Value,
            OffensiveStats: new FootballOffensiveStatsDto(
                PassingCompletions: stats.OffensiveStats.PassingCompletions,
                PassingAttempts: stats.OffensiveStats.PassingAttempts,
                PassingYards: stats.OffensiveStats.PassingYards,
                LongestPassingPlay: stats.OffensiveStats.LongestPassingPlay,
                PassingTouchdowns: stats.OffensiveStats.PassingTouchdowns,
                PassingInterceptions: stats.OffensiveStats.PassingInterceptions,
                Sacks: stats.OffensiveStats.Sacks,
                RushingAttempts: stats.OffensiveStats.RushingAttempts,
                RushingYards: stats.OffensiveStats.RushingYards,
                LongestRushingPlay: stats.OffensiveStats.LongestRushingPlay,
                RushingTouchdowns: stats.OffensiveStats.RushingTouchdowns,
                RushingFumbles: stats.OffensiveStats.RushingFumbles,
                RushingFumblesLost: stats.OffensiveStats.RushingFumblesLost,
                Receptions: stats.OffensiveStats.Receptions,
                Targets: stats.OffensiveStats.Targets,
                ReceivingYards: stats.OffensiveStats.ReceivingYards,
                ReceivingTouchdowns: stats.OffensiveStats.ReceivingTouchdowns,
                ReceivingFumbles: stats.OffensiveStats.ReceivingFumbles,
                ReceivingFumblesLost: stats.OffensiveStats.ReceivingFumblesLost,
                YardsAfterCatch: stats.OffensiveStats.YardsAfterCatch
                ),
            DefensiveStats: new FootballDefensiveStatsDto(
                Tackles: stats.DefensiveStats.Tackles,
                Sacks: stats.DefensiveStats.Sacks,
                TacklesForLoss: stats.DefensiveStats.TacklesForLoss,
                PassesDefended: stats.DefensiveStats.PassesDefended,
                DefensiveInterceptions: stats.DefensiveStats.DefensiveInterceptions,
                DefensiveInterceptionYards: stats.DefensiveStats.DefensiveInterceptionYards,
                LongestDefensiveInterceptionPlay: stats.DefensiveStats.LongestDefensiveInterceptionPlay,
                DefensiveTouchdowns: stats.DefensiveStats.DefensiveTouchdowns,
                ForcedFumbles: stats.DefensiveStats.ForcedFumbles,
                RecoveredFumbles: stats.DefensiveStats.RecoveredFumbles
                ),
            KickingStats: new FootballKickingStatsDto(
                FieldGoalsMade: stats.KickingStats.FieldGoalsMade,
                FieldGoalsAttempted: stats.KickingStats.FieldGoalsAttempted,
                ExtraPointsMade: stats.KickingStats.ExtraPointsMade,
                ExtraPointsAttempted: stats.KickingStats.ExtraPointsAttempted,
                LongestKick: stats.KickingStats.LongestKick,
                Points: stats.KickingStats.Points,
                Punts: stats.KickingStats.Punts,
                PuntingYards: stats.KickingStats.PuntingYards,
                LongestPunt: stats.KickingStats.LongestPunt
                )
            ));
    }


    public static FootballStatsDto ToSingleFootballStatsDto(this FootballStats stats)
    {
        return new FootballStatsDto(
            Id: stats.Id.Value,
            LeagueId: stats.LeagueId.Value,
            TeamId: stats.TeamId.Value,
            PlayerId: stats.PlayerId.Value,
            SeasonId: stats.SeasonId.Value,
            GameId: stats.GameId.Value,
            OffensiveStats: new FootballOffensiveStatsDto(
                PassingCompletions: stats.OffensiveStats.PassingCompletions,
                PassingAttempts: stats.OffensiveStats.PassingAttempts,
                PassingYards: stats.OffensiveStats.PassingYards,
                LongestPassingPlay: stats.OffensiveStats.LongestPassingPlay,
                PassingTouchdowns: stats.OffensiveStats.PassingTouchdowns,
                PassingInterceptions: stats.OffensiveStats.PassingInterceptions,
                Sacks: stats.OffensiveStats.Sacks,
                RushingAttempts: stats.OffensiveStats.RushingAttempts,
                RushingYards: stats.OffensiveStats.RushingYards,
                LongestRushingPlay: stats.OffensiveStats.LongestRushingPlay,
                RushingTouchdowns: stats.OffensiveStats.RushingTouchdowns,
                RushingFumbles: stats.OffensiveStats.RushingFumbles,
                RushingFumblesLost: stats.OffensiveStats.RushingFumblesLost,
                Receptions: stats.OffensiveStats.Receptions,
                Targets: stats.OffensiveStats.Targets,
                ReceivingYards: stats.OffensiveStats.ReceivingYards,
                ReceivingTouchdowns: stats.OffensiveStats.ReceivingTouchdowns,
                ReceivingFumbles: stats.OffensiveStats.ReceivingFumbles,
                ReceivingFumblesLost: stats.OffensiveStats.ReceivingFumblesLost,
                YardsAfterCatch: stats.OffensiveStats.YardsAfterCatch
                ),
            DefensiveStats: new FootballDefensiveStatsDto(
                Tackles: stats.DefensiveStats.Tackles,
                Sacks: stats.DefensiveStats.Sacks,
                TacklesForLoss: stats.DefensiveStats.TacklesForLoss,
                PassesDefended: stats.DefensiveStats.PassesDefended,
                DefensiveInterceptions: stats.DefensiveStats.DefensiveInterceptions,
                DefensiveInterceptionYards: stats.DefensiveStats.DefensiveInterceptionYards,
                LongestDefensiveInterceptionPlay: stats.DefensiveStats.LongestDefensiveInterceptionPlay,
                DefensiveTouchdowns: stats.DefensiveStats.DefensiveTouchdowns,
                ForcedFumbles: stats.DefensiveStats.ForcedFumbles,
                RecoveredFumbles: stats.DefensiveStats.RecoveredFumbles
                ),
            KickingStats: new FootballKickingStatsDto(
                FieldGoalsMade: stats.KickingStats.FieldGoalsMade,
                FieldGoalsAttempted: stats.KickingStats.FieldGoalsAttempted,
                ExtraPointsMade: stats.KickingStats.ExtraPointsMade,
                ExtraPointsAttempted: stats.KickingStats.ExtraPointsAttempted,
                LongestKick: stats.KickingStats.LongestKick,
                Points: stats.KickingStats.Points,
                Punts: stats.KickingStats.Punts,
                PuntingYards: stats.KickingStats.PuntingYards,
                LongestPunt: stats.KickingStats.LongestPunt
                )
            );
    }
}
