namespace League.Builder.Web.Server.Services;

public interface IStatsService
{
    //Baseball Calls
    [Get("/stats-service/baseballstats?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<GetBaseballStatsResponse> GetBaseballStats(int? pageIndex = 0, int? pageSize = 4);
    [Get("/stats-service/baseballstats/{id}")]
    Task<GetBaseballStatByIdResponse> GetBaseballStatById(Guid id);
    [Get("/stats-service/baseballstats/league/{leagueId}")]
    Task<GetBaseballStatsByLeagueResponse> GetBaseballStatsByLeague(Guid leagueId);
    [Get("/stats-service/baseballstats/team/{teamId}")]
    Task<GetBaseballStatsByTeamResponse> GetBaseballStatsByTeam(Guid teamId);
    [Get("/stats-service/baseballstats/player/{playerId}")]
    Task<GetBaseballStatsByPlayerResponse> GetBaseballStatsByPlayer(Guid playerId);
    [Get("/stats-service/baseballstats/league/season/{leagueId}/{seasonId}")]
    Task<GetLeagueBaseballStatsBySeasonResponse> GetLeagueBaseballStatsBySeason(Guid leagueId, Guid seasonId);
    [Get("/stats-service/baseballstats/player/game/{playerId}/{gameId}")]
    Task<GetPlayerBaseballStatByGameResponse> GetPlayerBaseballStatByGame(Guid playerId, Guid gameId);
    [Get("/stats-service/baseballstats/player/season/{playerId}/{seasonId}")]
    Task<GetPlayerBaseballStatsBySeasonResponse> GetPlayerBaseballStatsBySeason(Guid playerId, Guid seasonId);
    [Get("/stats-service/baseballstats/team/game/{teamId}/{gameId}")]
    Task<GetTeamBaseballStatsByGameResponse> GetTeamBaseballStatsByGame(Guid teamId, Guid gameId);
    [Get("/stats-service/baseballstats/team/season/{teamId}/{seasonId}")]
    Task<GetTeamBaseballStatsBySeasonResponse> GetTeamBaseballStatsBySeason(Guid teamId, Guid seasonId);
    [Post("/stats-service/baseballstats")]
    Task<CreateBaseballStatsResponse> CreateBaseballStats(CreateBaseballStatsRequest BaseballStats);
    [Put("/stats-service/baseballstats")]
    Task<UpdateBaseballStatsResponse> UpdateBaseballStats(UpdateBaseballStatsRequest BaseballStats);
    [Delete("/stats-service/baseballstats/{id}")]
    Task<DeleteBaseballStatsResponse> DeleteBaseballStats(Guid id);

    //Basketball Calls
    [Get("/stats-service/basketballstats?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<GetBasketballStatsResponse> GetBasketballStats(int? pageIndex = 0, int? pageSize = 4);
    [Get("/stats-service/basketballstats/{id}")]
    Task<GetBasketballStatByIdResponse> GetBasketballStatById(Guid id);
    [Get("/stats-service/basketballstats/league/{leagueId}")]
    Task<GetBasketballStatsByLeagueResponse> GetBasketballStatsByLeague(Guid leagueId);
    [Get("/stats-service/basketballstats/team/{teamId}")]
    Task<GetBasketballStatsByTeamResponse> GetBasketballStatsByTeam(Guid teamId);
    [Get("/stats-service/basketballstats/player/{playerId}")]
    Task<GetBasketballStatsByPlayerResponse> GetBasketballStatsByPlayer(Guid playerId);
    [Get("/stats-service/basketballstats/league/season/{leagueId}/{seasonId}")]
    Task<GetLeagueBasketballStatsBySeasonResponse> GetLeagueBasketballStatsBySeason(Guid leagueId, Guid seasonId);
    [Get("/stats-service/basketballstats/player/game/{playerId}/{gameId}")]
    Task<GetPlayerBasketballStatByGameResponse> GetPlayerBasketballStatByGame(Guid playerId, Guid gameId);
    [Get("/stats-service/basketballstats/player/season/{playerId}/{seasonId}")]
    Task<GetPlayerBasketballStatsBySeasonResponse> GetPlayerBasketballStatsBySeason(Guid playerId, Guid seasonId);
    [Get("/stats-service/basketballstats/team/game/{teamId}/{gameId}")]
    Task<GetTeamBasketballStatsByGameResponse> GetTeamBasketballStatsByGame(Guid teamId, Guid gameId);
    [Get("/stats-service/basketballstats/team/season/{teamId}/{seasonId}")]
    Task<GetTeamBasketballStatsBySeasonResponse> GetTeamBasketballStatsBySeason(Guid teamId, Guid seasonId);
    [Post("/stats-service/basketballstats")]
    Task<CreateBasketballStatsResponse> CreateBasketballStats(CreateBasketballStatsRequest BasketballStats);
    [Put("/stats-service/basketballstats")]
    Task<UpdateBasketballStatsResponse> UpdateBasketballStats(UpdateBasketballStatsRequest BasketballStats);
    [Delete("/stats-service/basketballstats/{id}")]
    Task<DeleteBasketballStatsResponse> DeleteBasketballStats(Guid id);

    //Football Calls
    [Get("/stats-service/footballstats?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<GetFootballStatsResponse> GetFootballStats(int? pageIndex = 0, int? pageSize = 4);
    [Get("/stats-service/footballstats/{id}")]
    Task<GetFootballStatByIdResponse> GetFootballStatById(Guid id);
    [Get("/stats-service/footballstats/league/{leagueId}")]
    Task<GetFootballStatsByLeagueResponse> GetFootballStatsByLeague(Guid leagueId);
    [Get("/stats-service/footballstats/team/{teamId}")]
    Task<GetFootballStatsByTeamResponse> GetFootballStatsByTeam(Guid teamId);
    [Get("/stats-service/footballstats/player/{playerId}")]
    Task<GetFootballStatsByPlayerResponse> GetFootballStatsByPlayer(Guid playerId);
    [Get("/stats-service/footballstats/league/season/{leagueId}/{seasonId}")]
    Task<GetLeagueFootballStatsBySeasonResponse> GetLeagueFootballStatsBySeason(Guid leagueId, Guid seasonId);
    [Get("/stats-service/footballstats/player/game/{playerId}/{gameId}")]
    Task<GetPlayerFootballStatByGameResponse> GetPlayerFootballStatByGame(Guid playerId, Guid gameId);
    [Get("/stats-service/footballstats/player/season/{playerId}/{seasonId}")]
    Task<GetPlayerFootballStatsBySeasonResponse> GetPlayerFootballStatsBySeason(Guid playerId, Guid seasonId);
    [Get("/stats-service/footballstats/team/game/{teamId}/{gameId}")]
    Task<GetTeamFootballStatsByGameResponse> GetTeamFootballStatsByGame(Guid teamId, Guid gameId);
    [Get("/stats-service/footballstats/team/season/{teamId}/{seasonId}")]
    Task<GetTeamFootballStatsBySeasonResponse> GetTeamFootballStatsBySeason(Guid teamId, Guid seasonId);
    [Post("/stats-service/footballstats")]
    Task<CreateFootballStatsResponse> CreateFootballStats(CreateFootballStatsRequest FootballStats);
    [Put("/stats-service/footballstats")]
    Task<UpdateFootballStatsResponse> UpdateFootballStats(UpdateFootballStatsRequest FootballStats);
    [Delete("/stats-service/footballstats/{id}")]
    Task<DeleteFootballStatsResponse> DeleteFootballStats(Guid id);


    //Health
    [Get("/stats-service/healthz")]
    Task<string> GetStatsHealth();

}
