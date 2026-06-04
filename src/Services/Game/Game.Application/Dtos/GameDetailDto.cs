namespace Game.Application.Dtos;

public record GameDetailDto(
    int AwayTeamScore,
    int HomeTeamScore,
    DateTime StartTime,
    DateTime? EndTime,
    List<int>? AwayInningRuns,
    List<int>? HomeInningRuns,
    int? AwayTotalHits,
    int? HomeTotalHits
);
