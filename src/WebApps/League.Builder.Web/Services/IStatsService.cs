namespace League.Builder.Web.Services;

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
    Task<CreateBaseballStatsResponse> CreateBaseballStats(CreateBaseballStatsRequest player);
    [Put("/stats-service/baseballstats")]
    Task<UpdateBaseballStatsResponse> UpdateBaseballStats(UpdateBaseballStatsRequest player);
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
    Task<CreateBasketballStatsResponse> CreateBasketballStats(CreateBasketballStatsRequest player);
    [Put("/stats-service/basketballstats")]
    Task<UpdateBasketballStatsResponse> UpdateBasketballStats(UpdateBasketballStatsRequest player);
    [Delete("/stats-service/basketballstats/{id}")]
    Task<DeleteBasketballStatsResponse> DeleteBasketballStats(Guid id);

    //Football Calls
    [Get("/stats-service/footballstats?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<GetFootballStatsResponse> GetFootballStats(int? pageIndex = 0, int? pageSize = 4);
    [Get("/stats-service/footballstats/{id}")]
    Task<GetFootballStatByIdResponse> GettFootballStatById(Guid id);
    [Get("/stats-service/footballstats/league/{leagueId}")]
    Task<GetFootballStatsByLeagueResponse> GettFootballStatsByLeague(Guid leagueId);
    [Get("/stats-service/footballstats/team/{teamId}")]
    Task<GetFootballStatsByTeamResponse> GettFootballStatsByTeam(Guid teamId);
    [Get("/stats-service/footballstats/player/{playerId}")]
    Task<GetFootballStatsByPlayerResponse> GettFootballStatsByPlayer(Guid playerId);
    [Get("/stats-service/footballstats/league/season/{leagueId}/{seasonId}")]
    Task<GetLeagueFootballStatsBySeasonResponse> GetLeaguetFootballStatsBySeason(Guid leagueId, Guid seasonId);
    [Get("/stats-service/footballstats/player/game/{playerId}/{gameId}")]
    Task<GetPlayerFootballStatByGameResponse> GetPlayertFootballStatByGame(Guid playerId, Guid gameId);
    [Get("/stats-service/footballstats/player/season/{playerId}/{seasonId}")]
    Task<GetPlayerFootballStatsBySeasonResponse> GetPlayertFootballStatsBySeason(Guid playerId, Guid seasonId);
    [Get("/stats-service/footballstats/team/game/{teamId}/{gameId}")]
    Task<GetTeamFootballStatsByGameResponse> GetTeamtFootballStatsByGame(Guid teamId, Guid gameId);
    [Get("/stats-service/footballstats/team/season/{teamId}/{seasonId}")]
    Task<GetTeamFootballStatsBySeasonResponse> GetTeamtFootballStatsBySeason(Guid teamId, Guid seasonId);
    [Post("/stats-service/footballstats")]
    Task<CreateFootballStatsResponse> CreatetFootballStats(CreateBasketballStatsRequest player);
    [Put("/stats-service/footballstats")]
    Task<UpdateFootballStatsResponse> UpdatetFootballStats(UpdateBasketballStatsRequest player);
    [Delete("/stats-service/footballstats/{id}")]
    Task<DeleteFootballStatsResponse> DeletetFootballStats(Guid id);

}
