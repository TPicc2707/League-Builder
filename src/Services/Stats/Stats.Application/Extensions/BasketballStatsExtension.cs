namespace Stats.Application.Extensions;

public static class BasketballStatsExtension
{
    public static IEnumerable<BasketballStatsDto> ToBasketballStatsDtoList(this IEnumerable<BasketballStats> stats)
    {
        return stats.Select(stats => new BasketballStatsDto(
            Id: stats.Id.Value,
            LeagueId: stats.LeagueId.Value,
            TeamId: stats.TeamId.Value,
            PlayerId: stats.PlayerId.Value,
            SeasonId: stats.SeasonId.Value,
            GameId: stats.GameId.Value,
            Stats: new BasketballPlayerStatsDto(
                stats.Stats.Start,
                stats.Stats.Minutes,
                stats.Stats.Points,
                stats.Stats.FieldGoalsMade,
                stats.Stats.FieldGoalsAttempted,
                stats.Stats.ThreePointersMade,
                stats.Stats.ThreePointersAttempted,
                stats.Stats.FreeThrowsMade,
                stats.Stats.FreeThrowsAttempted,
                stats.Stats.Rebounds,
                stats.Stats.Assists,
                stats.Stats.Steals,
                stats.Stats.Blocks,
                stats.Stats.Turnovers,
                stats.Stats.Fouls
            )));
    }

    public static BasketballStatsDto ToSingleBasketballStatsDto(this BasketballStats stats)
    {
        return new BasketballStatsDto(
            Id: stats.Id.Value,
            LeagueId: stats.LeagueId.Value,
            TeamId: stats.TeamId.Value,
            PlayerId: stats.PlayerId.Value,
            SeasonId: stats.SeasonId.Value,
            GameId: stats.GameId.Value,
            Stats: new BasketballPlayerStatsDto(
                stats.Stats.Start,
                stats.Stats.Minutes,
                stats.Stats.Points,
                stats.Stats.FieldGoalsMade,
                stats.Stats.FieldGoalsAttempted,
                stats.Stats.ThreePointersMade,
                stats.Stats.ThreePointersAttempted,
                stats.Stats.FreeThrowsMade,
                stats.Stats.FreeThrowsAttempted,
                stats.Stats.Rebounds,
                stats.Stats.Assists,
                stats.Stats.Steals,
                stats.Stats.Blocks,
                stats.Stats.Turnovers,
                stats.Stats.Fouls
            ));
    }

}
