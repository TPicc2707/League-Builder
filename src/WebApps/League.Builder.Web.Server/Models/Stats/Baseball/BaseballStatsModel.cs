namespace League.Builder.Web.Server.Models.Stats.Baseball;

public record BaseballStatsModel(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    BaseballHittingStatsModel HittingStats,
    BaseballPitchingStatsModel PitchingStats);


public record CreateBaseballStatsModel(
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    CreateBaseballHittingStatsModel HittingStats,
    CreateBaseballPitchingStatsModel PitchingStats);

public record UpdateBaseballStatsModel(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    UpdateBaseballHittingStatsModel HittingStats,
    UpdateBaseballPitchingStatsModel PitchingStats);


public record BaseballHittingStatsModel(int AtBats,
    int Hits,
    int TotalBases,
    int Runs,
    int Doubles,
    int Triples,
    int HomeRuns,
    int RunsBattedIn,
    int StolenBases,
    int Strikeouts,
    int Walks,
    int HitByPitch,
    int SacrificeFly,
    decimal Average,
    decimal Slugging,
    decimal OnBasePercentage,
    decimal OnBasePlusSlugging);

public record BaseballPitchingStatsModel(int Wins,
    int Losses,
    int Runs,
    bool Start,
    int Saves,
    decimal Innings,
    int HitsAllowed,
    int WalksAllowed,
    int PitchingStrikeouts,
    decimal WalksHitsPerInning,
    decimal EarnedRunAverage);

public record CreateBaseballHittingStatsModel(int AtBats,
    int Hits,
    int TotalBases,
    int Runs,
    int Doubles,
    int Triples,
    int HomeRuns,
    int RunsBattedIn,
    int StolenBases,
    int Strikeouts,
    int Walks,
    int HitByPitch,
    int SacrificeFly);

public record CreateBaseballPitchingStatsModel(int Wins,
    int Losses,
    int Runs,
    bool Start,
    int Saves,
    decimal Innings,
    int HitsAllowed,
    int WalksAllowed,
    int PitchingStrikeouts);

public record UpdateBaseballHittingStatsModel(int AtBats,
    int Hits,
    int TotalBases,
    int Runs,
    int Doubles,
    int Triples,
    int HomeRuns,
    int RunsBattedIn,
    int StolenBases,
    int Strikeouts,
    int Walks,
    int HitByPitch,
    int SacrificeFly);

public record UpdateBaseballPitchingStatsModel(int Wins,
    int Losses,
    int Runs,
    bool Start,
    int Saves,
    decimal Innings,
    int HitsAllowed,
    int WalksAllowed,
    int PitchingStrikeouts);



//Request Records
public record CreateBaseballStatsRequest(CreateBaseballStatsModel BaseballStats);
public record UpdateBaseballStatsRequest(UpdateBaseballStatsModel BaseballStats);


// Response Records
public record GetBaseballStatsResponse(PaginatedResult<BaseballStatsModel> BaseballStats);
public record GetBaseballStatByIdResponse(BaseballStatsModel BaseballStats);
public record GetBaseballStatsByLeagueResponse(IEnumerable<BaseballStatsModel> BaseballStats);
public record GetBaseballStatsByTeamResponse(IEnumerable<BaseballStatsModel> BaseballStats);
public record GetBaseballStatsByPlayerResponse(IEnumerable<BaseballStatsModel> BaseballStats);
public record GetLeagueBaseballStatsBySeasonResponse(IEnumerable<BaseballStatsModel> BaseballStats);
public record GetPlayerBaseballStatByGameResponse(BaseballStatsModel BaseballStats);
public record GetPlayerBaseballStatsBySeasonResponse(IEnumerable<BaseballStatsModel> BaseballStats);
public record GetTeamBaseballStatsByGameResponse(IEnumerable<BaseballStatsModel> BaseballStats);
public record GetTeamBaseballStatsBySeasonResponse(IEnumerable<BaseballStatsModel> BaseballStats);
public record CreateBaseballStatsResponse(Guid Id);
public record UpdateBaseballStatsResponse(bool IsSuccess);
public record DeleteBaseballStatsResponse(bool IsSuccess);

