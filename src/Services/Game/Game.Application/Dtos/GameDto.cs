using Game.Domain.Enum;

namespace Game.Application.Dtos;

public record GameDto(
    Guid Id,
    Guid LeagueId,
    Guid AwayTeamId,
    Guid HomeTeamId,
    Guid? WinningTeamId,
    Guid SeasonId,
    GameDetailDto GameDetail,
    GameStatus GameStatus);
