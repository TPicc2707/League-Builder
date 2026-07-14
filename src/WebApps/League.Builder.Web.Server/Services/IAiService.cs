namespace League.Builder.Web.Server.Services;

public interface IAiService
{
    [Post("/ai-service/ai/query")]
    Task<AiQueryResponse> QueryAsync(AiQueryRequest request);
    [Post("/ai-service/ai/leagues")]
    Task AddLeagueAsync(AiAddLeagueRequest league);
    [Post("/ai-service/ai/deleteleagues")]
    Task DeleteLeagueAsync(AiDeleteLeagueRequest league);
    [Post("/ai-service/ai/teams")]
    Task AddTeamAsync(AiAddTeamRequest team);
    [Post("/ai-service/ai/deleteteams")]
    Task DeleteTeamAsync(AiDeleteTeamRequest team);
    [Post("/ai-service/ai/players")]
    Task AddPlayerAsync(AiAddPlayerRequest player);
    [Post("/ai-service/ai/deleteplayers")]
    Task DeletePlayerAsync(AiDeletePlayerRequest player);
    [Post("/ai-service/ai/seasons")]
    Task AddSeasonAsync(AiAddSeasonRequest season);
    [Post("/ai-service/ai/deleteseasons")]
    Task DeleteSeasonAsync(AiDeleteSeasonRequest season);
    [Post("/ai-service/ai/standings")]
    Task AddStandingsAsync(AiAddStandingsRequest standings);
    [Post("/ai-service/ai/deletestandings")]
    Task DeleteStandingsAsync(AiDeleteStandingsRequest standings);
    [Post("/ai-service/ai/games")]
    Task AddGameAsync(AiAddGameRequest game);
    [Post("/ai-service/ai/deletegames")]
    Task DeleteGameAsync(AiDeleteGameRequest games);
    [Post("/ai-service/ai/baseballstats")]
    Task AddBaseballStatAsync(AiAddBaseballStatsRequest game);
    [Post("/ai-service/ai/deletebaseballstats")]
    Task DeleteBaseballStatAsync(AiDeleteBaseballStatsRequest games);
    [Post("/ai-service/ai/basketballstats")]
    Task AddBasketballStatAsync(AiAddBasketballStatsRequest game);
    [Post("/ai-service/ai/deletebasketballstats")]
    Task DeleteBasketballStatAsync(AiDeleteBasketballStatsRequest games);
    [Post("/ai-service/ai/footballstats")]
    Task AddFootballStatAsync(AiAddFootballStatsRequest game);
    [Post("/ai-service/ai/deletefootballstats")]
    Task DeleteFootballStatAsync(AiDeleteFootballStatsRequest games);
}
