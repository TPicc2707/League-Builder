namespace League.Builder.Web.Models.Standings;

public record StandingsModel(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid SeasonId,
    SeasonDetailModel StandingsDetail,
    StandingsStatus StandingsStatus);

public record CreateStandingsModel(
    Guid LeagueId,
    Guid TeamId,
    Guid SeasonId,
    SeasonDetailModel StandingsDetail
);

public record UpdateStandingsModel(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid SeasonId,
    SeasonDetailModel StandingsDetail,
    int StandingStatus
);


public record SeasonDetailModel(int GamesPlayed, int Wins, int Losses, int Ties);

public enum StandingsStatus
{
    NotStarted = 1,
    InProgress = 2,
    Finished = 3
}


// Request Record
public record CreateStandingsRequest(CreateStandingsModel Standing);
public record UpdateStandingsRequest(UpdateStandingsModel Standing);

// Response Record
public record GetStandingsResponse(PaginatedResult<StandingsModel> Standings);
public record GetStandingsByIdResponse(StandingsModel Standing);
public record GetStandingsByLeagueResponse(IEnumerable<StandingsModel> Standings);
public record GetStandingsByTeamResponse(IEnumerable<StandingsModel> Standings);
public record CreateStandingsResponse(Guid Id);
public record UpdateStandingsResponse(bool IsSuccess);
public record DeleteStandingsResponse(bool IsSuccess);