namespace Game.Application.Dtos;

public record GameLineupDto(
    Guid Id,
    Guid GameId,
    Guid TeamId,
    BaseballGameLineupDto BaseballLineup,
    TeamDto Team);
