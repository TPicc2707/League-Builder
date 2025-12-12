namespace League.Builder.Web.Server.Models.Game;

public class GameLineupModel
{
    public Guid Id { get; set; }
    public Guid GameId { get; set; }
    public Guid TeamId { get; set; }
    public BaseballGameLineup BaseballLineup { get; set; } = default!;
    public LineupTeamDetail Team { get; set; } = default!;
}

public record CreateBaseballGameLineupRecord(
    Guid GameId,
    Guid TeamId,
    BaseballGameLineup BaseballLineup);

public record UpdateBaseballGameLineupRecord(
    Guid Id,
    Guid GameId,
    Guid TeamId,
    BaseballGameLineup BaseballLineup);

public record BaseballGameLineup(Guid First, Guid Second, Guid Third, Guid Fourth, Guid Fifth, Guid Sixth, Guid Seventh, Guid Eighth, Guid Ninth, Guid StartingPitcher);

public record LineupTeamDetail(Guid Id, string TeamName);

//Request Records
public record CreateBaseballGameLineupRequest(CreateBaseballGameLineupRecord GameLineup);
public record UpdateBaseballGameLineupRequest(UpdateBaseballGameLineupRecord GameLineup);


//Response Records
public record GetBaseballGameLineupByIdResponse(GameLineupModel GameLineup);
public record GetBaseballGameLineupByGameIdResponse(GameLineupModel GameLineup);
public record AnyBaseballGameLineupByGameIdResponse(bool IsLineupCreated);