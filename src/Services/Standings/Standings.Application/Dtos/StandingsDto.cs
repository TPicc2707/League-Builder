namespace Standings.Application.Dtos;

public record StandingsDto(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid SeasonId,
    StandingsDetailDto StandingsDetail,
    StandingsStatus StandingsStatus
    );