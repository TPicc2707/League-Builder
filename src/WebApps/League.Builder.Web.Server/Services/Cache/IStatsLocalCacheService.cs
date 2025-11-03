namespace League.Builder.Web.Server.Services.Cache;

public interface IStatsLocalCacheService
{
    Task<GetLeagueBaseballStatsBySeasonResponse> GetLeagueBaseballStatsBySeasonCache(string leagueId, string seasonId);
    Task<GetLeagueBasketballStatsBySeasonResponse> GetLeagueBasketballStatsBySeasonCache(string leagueId, string seasonId);
    Task<GetLeagueFootballStatsBySeasonResponse> GetLeagueFootballStatsBySeasonCache(string leagueId, string seasonId);
    Task<GetBaseballStatsByPlayerResponse> GetBaseballStatsByPlayerCache(string playerId);
    Task<GetBaseballStatsByTeamResponse> GetBaseballStatsByTeamCache(string teamId);
    Task<GetBasketballStatsByPlayerResponse> GetBasketballStatsByPlayerCache(string playerId);
    Task<GetBasketballStatsByTeamResponse> GetBasketballStatsByTeamCache(string teamId);
    Task<GetFootballStatsByTeamResponse> GetFootballStatsByTeamCache(string teamId);
    Task<GetPlayerBaseballStatsBySeasonResponse> GetPlayerBaseballStatsBySeasonCache(string playerId, string seasonId);
    Task<GetPlayerBasketballStatsBySeasonResponse> GetPlayerBasketballStatsBySeasonCache(string playerId, string seasonId);
    Task<GetPlayerFootballStatsBySeasonResponse> GetPlayerFootballStatsBySeasonCache(string playerId, string seasonId);
    Task SetLeagueBaseballStatsBySeasonCache(string leagueId, string seasonId, GetLeagueBaseballStatsBySeasonResponse leagueBaseballStatsBySeasonResponse);
    Task SetLeagueBasketballStatsBySeasonCache(string leagueId, string seasonId, GetLeagueBasketballStatsBySeasonResponse leagueBasketballStatsBySeasonResponse);
    Task SetLeagueFootballStatsBySeasonCache(string leagueId, string seasonId, GetLeagueFootballStatsBySeasonResponse leagueFootballStatsBySeasonResponse);
    Task SetBaseballStatsByPlayerCache(string playerId, GetBaseballStatsByPlayerResponse baseballStatsByPlayerResponse);
    Task SetBaseballStatsByTeamCache(string teamId, GetBaseballStatsByTeamResponse baseballStatsByTeamResponse);
    Task SetBasketballStatsByPlayerCache(string playerId, GetBasketballStatsByPlayerResponse basketballStatsByPlayerResponse);
    Task SetBasketballStatsByTeamCache(string teamId, GetBasketballStatsByTeamResponse basketballStatsByTeamResponse);
    Task SetFootballStatsByTeamCache(string teamId, GetFootballStatsByTeamResponse footballStatsByTeamResponse);
    Task SetPlayerBaseballStatsBySeasonCache(string playerId, string seasonId, GetPlayerBaseballStatsBySeasonResponse playerBaseballStatsBySeasonResponse);
    Task SetPlayerBasketballStatsBySeasonCache(string playerId, string seasonId, GetPlayerBasketballStatsBySeasonResponse playerBasketballStatsBySeasonResponse);
    Task SetPlayerFootballStatsBySeasonCache(string playerId, string seasonId, GetPlayerFootballStatsBySeasonResponse playerFootballStatsBySeasonResponse);
    Task DeleteLeagueBaseballStatsBySeasonCache(string leagueId, string seasonId);
    Task DeleteBaseballStatsByPlayerCache(string playerId);
    Task DeleteBaseballStatsByTeamCache(string teamId);
    Task DeleteLeagueBasketballStatsBySeasonCache(string leagueId, string seasonId);
    Task DeleteBasketballStatsByPlayerCache(string playerId);
    Task DeleteBasketballStatsByTeamCache(string teamId);
    Task DeleteLeagueFootballStatsBySeasonCache(string leagueId, string seasonId);
    Task DeleteFootballStatsByPlayerCache(string playerId);
    Task DeleteFootballStatsByTeamCache(string teamId);
    Task DeletePlayerBaseballStatsBySeasonCache(string playerId, string seasonId);
    Task DeletePlayerBasketballStatsBySeasonCache(string playerId, string seasonId);
    Task DeletePlayerFootballStatsBySeasonCache(string playerId, string seasonId);
}
