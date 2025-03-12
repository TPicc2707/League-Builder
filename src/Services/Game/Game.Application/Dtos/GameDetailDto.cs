namespace Game.Application.Dtos;

public record GameDetailDto(
    int AwayTeamScore,
    int HomeTeamScore,
    DateTime StartTime,
    DateTime? EndTime);
