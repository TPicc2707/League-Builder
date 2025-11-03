namespace League.Builder.Web.Server.Services.Cache;

public interface IGameLocalCacheService
{
    Task<GetGameByIdResponse> GetGameByIdCache(string id);
    Task<GetGamesByLeagueResponse> GetGamesByLeagueCache(string leagueId);
    Task<GetGamesByTeamResponse> GetGamesByTeamCache(string teamId);
    Task SetGameByIdCache(string id, GetGameByIdResponse gameByIdResponse);
    Task SetGamesByLeagueCache(string leagueId, GetGamesByLeagueResponse gamesByLeagueResponse);
    Task SetGamesByTeamCache(string teamId, GetGamesByTeamResponse gamesByTeamResponse);
    Task DeleteGameByIdCache(string id);
    Task DeleteGamesByLeagueCache(string leagueId);
    Task DeleteGamesByTeamCache(string teamId);

}
