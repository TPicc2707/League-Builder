namespace Stats.Application.Dtos;

public record BaseballStatsDto(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    BaseballHittingStatsDto HittingStats,
    BaseballPitchingStatsDto PitchingStats
    );
