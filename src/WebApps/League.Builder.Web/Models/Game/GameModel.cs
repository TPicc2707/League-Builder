namespace League.Builder.Web.Models.Game;

public record GameModel(
    Guid Id,
    Guid LeagueId,
    Guid AwayTeamId,
    Guid HomeTeamId,
    Guid? WinningTeamId,
    Guid SeasonId,
    GameDetailModel GameDetail,
    GameStatus GameStatus);

public record CreateGameModel(
    Guid LeagueId,
    Guid AwayTeamId,
    Guid HomeTeamId,
    Guid? WinningTeamId,
    Guid SeasonId,
    GameDetailModel GameDetail);

public record UpdateGameModel(
    Guid Id,    
    Guid LeagueId,
    Guid AwayTeamId,
    Guid HomeTeamId,
    Guid? WinningTeamId,
    Guid SeasonId,
    GameDetailModel GameDetail);


public record GameDetailModel(int AwayTeamScore, int HomeTeamScore, DateTime StartTime, DateTime? EndTime);

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