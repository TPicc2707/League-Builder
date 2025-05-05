namespace League.Builder.Web.Server.Models.Game;

public record GameModel(
    Guid Id,
    Guid LeagueId,
    Guid? WinningTeamId,
    Guid SeasonId,
    GameDetailModel GameDetail,
    GameStatus GameStatus,
    AwayTeamDetailModel AwayTeam,
    HomeTeamDetailModel HomeTeam);

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