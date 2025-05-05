namespace Standings.Application.Dtos;

public record StandingsDto(
    Guid Id,
    Guid LeagueId,
    Guid SeasonId,
    StandingsDetailDto StandingsDetail,
    StandingsStatus StandingsStatus,
    TeamDto Team
    );