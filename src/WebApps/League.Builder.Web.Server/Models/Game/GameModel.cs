namespace League.Builder.Web.Server.Models.Game;

public class GameModel
{
    public Guid Id { get; set; }
    public Guid LeagueId { get; set; }
    public Guid? WinningTeamId { get; set; }
    public Guid SeasonId { get; set; }
    public GameDetailModel GameDetail { get; set; } = default!;
    public GameStatus GameStatus { get; set; } = default!;
    public AwayTeamDetailModel AwayTeam { get; set; } = default!;
    public HomeTeamDetailModel HomeTeam { get; set; } = default!;

    public string AwayTeamImage { get; set; } = default!;

    public string HomeTeamImage { get; set; } = default!;
    public int TeamSeasonWins { get; set; }
    public int TeamSeasonLosses { get; set; }
}

public record CreateGameModel(
    Guid LeagueId,
    Guid? WinningTeamId,
    Guid SeasonId,
    GameDetailModel GameDetail,
    AwayTeamDetailModel AwayTeam,
    HomeTeamDetailModel HomeTeam);

public record UpdateGameModel(
    Guid Id,    
    Guid LeagueId,
    Guid? WinningTeamId,
    Guid SeasonId,
    GameDetailModel GameDetail,
    AwayTeamDetailModel AwayTeam,
    HomeTeamDetailModel HomeTeam,
    int GameStatus);


public record GameDetailModel(int AwayTeamScore, int HomeTeamScore, DateTime StartTime, DateTime? EndTime);

public record AwayTeamDetailModel(Guid Id, string TeamName);
public record HomeTeamDetailModel(Guid Id, string TeamName);


public enum GameStatus
{
    NotStarted = 1,
    InProgress = 2,
    Completed = 3,
    Postponed = 4,
    Delayed = 5
}

//Request Records
public record CreateGameRequest(CreateGameModel Game);
public record UpdateGameRequest(UpdateGameModel Game);

//Response Records
public record GetGamesResponse(PaginatedResult<GameModel> Games);
public record GetGameByIdResponse(GameModel Game);
public record GetGamesByLeagueResponse(IEnumerable<GameModel> Games);
public record GetGamesByTeamResponse(IEnumerable<GameModel> Games);
public record CreateGameResponse(Guid Id);
public record UpdateGameResponse(bool IsSuccess);
public record DeleteGameResponse(bool IsSuccess);