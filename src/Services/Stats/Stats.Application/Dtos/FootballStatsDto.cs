namespace Stats.Application.Dtos;

public record FootballStatsDto(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    FootballOffensiveStatsDto OffensiveStats,
    FootballDefensiveStatsDto DefensiveStats,
    FootballKickingStatsDto KickingStats
    );
