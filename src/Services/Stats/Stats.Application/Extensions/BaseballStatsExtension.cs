namespace Stats.Application.Extensions;

public static class BaseballStatsExtension
{
    public static IEnumerable<BaseballStatsDto> ToBaseballStatsDtoList(this IEnumerable<BaseballStats> stats)
    {
        return stats.Select(stats => new BaseballStatsDto(
            Id: stats.Id.Value,
            LeagueId: stats.LeagueId.Value,
            TeamId: stats.TeamId.Value,
            PlayerId: stats.PlayerId.Value,
            SeasonId: stats.SeasonId.Value,
            GameId: stats.GameId.Value,
            HittingStats: new BaseballHittingStatsDto(
                stats.HittingStats.AtBats,
                stats.HittingStats.Hits,
                stats.HittingStats.TotalBases,
                stats.HittingStats.Runs,
                stats.HittingStats.Doubles,
                stats.HittingStats.Triples,
                stats.HittingStats.HomeRuns,
                stats.HittingStats.RunsBattedIn,
                stats.HittingStats.StolenBases,
                stats.HittingStats.Strikeouts,
                stats.HittingStats.Walks,
                stats.HittingStats.HitByPitch,
                stats.HittingStats.SacrificeFly
            ),
            PitchingStats: new BaseballPitchingStatsDto(
                stats.PitchingStats.Wins,
                stats.PitchingStats.Losses,
                stats.PitchingStats.Runs,
                stats.PitchingStats.Start,
                stats.PitchingStats.Saves,
                stats.PitchingStats.Innings,
                stats.PitchingStats.HitsAllowed,
                stats.PitchingStats.WalksAllowed,
                stats.PitchingStats.PitchingStrikeouts)
            ));
    }

    public static BaseballStatsDto ToSingleBaseballStatsDto(this BaseballStats stats)
    {
        return new BaseballStatsDto(
            Id: stats.Id.Value,
            LeagueId: stats.LeagueId.Value,
            TeamId: stats.TeamId.Value,
            PlayerId: stats.PlayerId.Value,
            SeasonId: stats.SeasonId.Value,
            GameId: stats.GameId.Value,
            HittingStats: new BaseballHittingStatsDto(
                stats.HittingStats.AtBats,
                stats.HittingStats.Hits,
                stats.HittingStats.TotalBases,
                stats.HittingStats.Runs,
                stats.HittingStats.Doubles,
                stats.HittingStats.Triples,
                stats.HittingStats.HomeRuns,
                stats.HittingStats.RunsBattedIn,
                stats.HittingStats.StolenBases,
                stats.HittingStats.Strikeouts,
                stats.HittingStats.Walks,
                stats.HittingStats.HitByPitch,
                stats.HittingStats.SacrificeFly
            ),
            PitchingStats: new BaseballPitchingStatsDto(
                stats.PitchingStats.Wins,
                stats.PitchingStats.Losses,
                stats.PitchingStats.Runs,
                stats.PitchingStats.Start,
                stats.PitchingStats.Saves,
                stats.PitchingStats.Innings,
                stats.PitchingStats.HitsAllowed,
                stats.PitchingStats.WalksAllowed,
                stats.PitchingStats.PitchingStrikeouts)
            );
    }
}
