namespace League.Builder.Web.Server.Services;

public interface IGameService
{
    [Get("/game-service/games?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<GetGamesResponse> GetGames(int? pageIndex = 0, int? pageSize = 4);
    [Get("/game-service/games/{id}")]
    Task<GetGameByIdResponse> GetGameById(Guid id);
    [Get("/game-service/games/league/{leagueId}")]
    Task<GetGamesByLeagueResponse> GetGamesByLeague(Guid leagueId);
    [Get("/game-service/games/team/{teamId}")]
    Task<GetGamesByTeamResponse> GetGamesByTeam(Guid teamId);
    [Get("/standings-service/healthz")]
    Task<string> GetGameHealth();
    [Post("/game-service/games")]
    Task<CreateGameResponse> CreateGame(CreateGameRequest game);
    [Put("/game-service/games")]
    Task<UpdateGameResponse> UpdateGame(UpdateGameRequest game);
    [Delete("/game-service/games/{id}")]
    Task<DeleteGameResponse> DeleteGame(Guid id);


}
