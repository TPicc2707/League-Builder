namespace Game.Application.Dtos;

public record GameDto(
    Guid Id,
    Guid LeagueId,
    Guid? WinningTeamId,
    Guid SeasonId,
    GameDetailDto GameDetail,
    GameStatus GameStatus,
    TeamDto AwayTeam,
    TeamDto HomeTeam);
