namespace League.Builder.Web.Server.Models.Standings;

public class StandingsModel
{
    public Guid Id { get; set; }
    public Guid LeagueId { get; set; }
    public Guid SeasonId { get; set; }
    public string TeamImage { get; set; } = default!;
    public decimal WinPercentage { get; set; } = default!;
    public StandingsDetailModel StandingsDetail { get ; set; } = default!;
    public StandingsStatus StandingsStatus { get; set; } = default!;
    public TeamDetailModel Team { get; set; } = default!;
}

public record CreateStandingsModel(
    Guid LeagueId,
    Guid SeasonId,
    StandingsDetailModel StandingsDetail,
    TeamDetailModel Team
);

public record UpdateStandingsModel(
    Guid Id,
    Guid LeagueId,
    Guid SeasonId,
    StandingsDetailModel StandingsDetail,
    int StandingStatus,
    TeamDetailModel Team
);


public record StandingsDetailModel(int GamesPlayed, int Wins, int Losses, int Ties);

public record TeamDetailModel(Guid Id, string TeamName);

public enum StandingsStatus
{
    NotStarted = 1,
    InProgress = 2,
    Finished = 3
}


// Request Record
public record CreateStandingsRequest(CreateStandingsModel Standings);
public record UpdateStandingsRequest(UpdateStandingsModel Standings);

// Response Record
public record GetStandingsResponse(PaginatedResult<StandingsModel> Standings);
public record GetStandingsByIdResponse(StandingsModel Standing);
public record GetStandingsByLeagueResponse(IEnumerable<StandingsModel> Standings);
public record GetStandingsByTeamResponse(IEnumerable<StandingsModel> Standings);
public record CreateStandingsResponse(Guid Id);
public record UpdateStandingsResponse(bool IsSuccess);
public record DeleteStandingsResponse(bool IsSuccess);