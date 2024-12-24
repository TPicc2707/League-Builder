namespace Stats.Application.Dtos;

public record BasketballStatsDto(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    BasketballPlayerStatsDto Stats
    );
