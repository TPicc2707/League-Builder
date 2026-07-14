namespace AI.API.Models;

public class PaginatedResult<TEntity>
    (int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
    where TEntity : class
{
    public int PageIndex { get; } = pageIndex;
    public int PageSize { get; } = pageSize;
    public long Count { get; } = count;
    public IEnumerable<TEntity> Data { get; } = data;
}

// Encapsulate the AI Query Results
public class LeagueDataResponse
{
    public IEnumerable<LeagueDto>? Leagues { get; set; }
    public IEnumerable<TeamDto>? Teams { get; set; }
    public IEnumerable<PlayerDto>? Players { get; set; }
    public IEnumerable<SeasonDto>? Seasons { get; set; }
    public IEnumerable<StandingsDto>? Standings { get; set; }
    public IEnumerable<GameDto>? Games { get; set; }
    public IEnumerable<BaseballStatsDto>? BaseballStats { get; set; }
    public IEnumerable<BasketballStatsDto>? BasketballStats { get; set; }
    public IEnumerable<FootballStatsDto>? FootballStats { get; set; }
}

// Structure the data
public record LeagueDto(
    Guid Id,
    string Name,
    string Sport,
    string Description,
    string ImageFile,
    string OwnerFirstName,
    string OwnerLastName,
    string EmailAddress,
    int TotalGamesPerSeason,
    int TotalPlayoffTeams,
    int MinimumTotalTeamPlayers,
    int MaximumTotalTeamPlayers,
    DateTime Created_DateTime,
    string Created_User,
    DateTime Modified_DateTime,
    string Modified_User);

public record TeamDto(
    Guid Id,
    Guid LeagueId,
    string TeamName,
    AddressDto TeamAddress,
    string Description,
    string ImageFile,
    string TeamColor,
    TeamStatus TeamStatus,
    ManagerDto TeamManager
);

public record AddressDto(string FirstName, string LastName, string EmailAddress, string AddressLine, string City, string Country, string State, string ZipCode);
public record ManagerDto(string FirstName, string LastName, string EmailAddress);
public record PlayerDto(
    Guid Id,
    Guid TeamId,
    string FirstName,
    string LastName,
    AddressDto PlayerAddress,
    PlayerDetailDto PlayerDetail,
    string Description,
    string ImageFile,
    PlayerStatus PlayerStatus
);
public record PlayerDetailDto(string EmailAddress, string PhoneNumber, DateTime BirthDate, int Height, int Weight, string Position, int Number);
public record SeasonDto(Guid Id, int Year, string Description, DateTime Created_DateTime, string Created_User, DateTime Modified_DateTime, string Modified_User);
public record StandingsDto(
    Guid Id,
    Guid LeagueId,
    Guid SeasonId,
    StandingsDetailDto StandingsDetail,
    StandingsStatus StandingsStatus,
    TeamDto Team
    );

public record StandingsDetailDto(
    int GamesPlayed,
    int Wins,
    int Losses,
    int Ties,
    bool PlayoffTeam,
    bool Champion
    );

public record GameDto(
    Guid Id,
    Guid LeagueId,
    Guid? WinningTeamId,
    Guid SeasonId,
    GameDetailDto GameDetail,
    GameStatus GameStatus,
    TeamDto AwayTeam,
    TeamDto HomeTeam);

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

public record BaseballStatsDto(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    BaseballHittingStatsDto HittingStats,
    BaseballPitchingStatsDto PitchingStats
    );

public record BaseballHittingStatsDto(
    int AtBats,
    int Hits,
    int TotalBases,
    int Runs,
    int Doubles,
    int Triples,
    int HomeRuns,
    int RunsBattedIn,
    int StolenBases,
    int CaughtStealing,
    int Strikeouts,
    int Walks,
    int HitByPitch,
    int SacrificeFly
    );

public record BaseballPitchingStatsDto(
    int Wins,
    int Losses,
    int Runs,
    bool Start,
    int Saves,
    decimal Innings,
    int HitsAllowed,
    int WalksAllowed,
    int PitchingStrikeouts
    );

public record BasketballStatsDto(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    BasketballPlayerStatsDto Stats
    );

public record BasketballPlayerStatsDto(
    bool Start,
    int Minutes,
    int Points,
    int FieldGoalsMade,
    int FieldGoalsAttempted,
    int ThreePointersMade,
    int ThreePointersAttempted,
    int FreeThrowsMade,
    int FreeThrowsAttempted,
    int Rebounds,
    int Assists,
    int Steals,
    int Blocks,
    int Turnovers,
    int Fouls);

public record FootballStatsDto(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    FootballOffensiveStatsDto OffensiveStats,
    FootballDefensiveStatsDto DefensiveStats,
    FootballKickingStatsDto KickingStats
    );

public record FootballOffensiveStatsDto(
    int PassingCompletions,
    int PassingAttempts,
    int PassingYards,
    int LongestPassingPlay,
    int PassingTouchdowns,
    int PassingInterceptions,
    int Sacks,
    int RushingAttempts,
    int RushingYards,
    int LongestRushingPlay,
    int RushingTouchdowns,
    int RushingFumbles,
    int RushingFumblesLost,
    int Receptions,
    int Targets,
    int ReceivingYards,
    int ReceivingTouchdowns,
    int ReceivingFumbles,
    int ReceivingFumblesLost,
    int YardsAfterCatch
    );

public record FootballDefensiveStatsDto(
    int Tackles,
    int Sacks,
    int TacklesForLoss,
    int PassesDefended,
    int DefensiveInterceptions,
    int DefensiveInterceptionYards,
    int LongestDefensiveInterceptionPlay,
    int DefensiveTouchdowns,
    int ForcedFumbles,
    int RecoveredFumbles);

public record FootballKickingStatsDto(
    int FieldGoalsMade,
    int FieldGoalsAttempted,
    int ExtraPointsMade,
    int ExtraPointsAttempted,
    int LongestKick,
    int Points,
    int Punts,
    int PuntingYards,
    int LongestPunt
    );


// Responses
public record GetLeaguesResponse(IEnumerable<LeagueDto> Leagues);
public record GetLeagueByIdResponse(LeagueDto League);
public record GetTeamsResponse(PaginatedResult<TeamDto> Teams);
public record GetTeamByIdResponse(TeamDto Team);
public record GetPlayersResponse(PaginatedResult<PlayerDto> Players);
public record GetPlayerByIdResponse(PlayerDto Player);
public record GetSeasonsResponse(IEnumerable<SeasonDto> Seasons);
public record GetSeasonByIdResponse(SeasonDto Season);
public record GetStandingsResponse(PaginatedResult<StandingsDto> Standings);
public record GetStandingsByIdResponse(StandingsDto Standings);
public record GetGamesResponse(PaginatedResult<GameDto> Games);
public record GetGameByIdResponse(GameDto Game);
public record GetBaseballStatsResponse(PaginatedResult<BaseballStatsDto> BaseballStats);
public record GetBaseballStatByIdResponse(BaseballStatsDto BaseballStat);
public record GetBasketballStatsResponse(PaginatedResult<BasketballStatsDto> BasketballStats);
public record GetBasketballStatByIdResponse(BasketballStatsDto BasketballStat);
public record GetFootballStatsResponse(PaginatedResult<FootballStatsDto> FootballStats);
public record GetFootballStatByIdResponse(FootballStatsDto FootballStat);

public enum TeamStatus
{
    Shutdown = 1,
    OffSeason = 2,
    InSeason = 3,
    Available = 4
}

public enum PlayerStatus
{
    FreeAgent = 1,
    OffSeason = 2,
    InSeason = 3,
    Retired = 4
}

public enum StandingsStatus
{
    NotStarted = 1,
    InProgress = 2,
    Finished = 3
}

public enum GameStatus
{
    NotStarted = 1,
    InProgress = 2,
    Completed = 3,
    Postponed = 4,
    Delayed = 5
}