namespace League.Builder.Web.Server.Services.Cache;

public interface IGameLocalCacheService
{
    Task<GetGameByIdResponse> GetGameByIdCache(string id);
    Task<GetGamesByLeagueResponse> GetGamesByLeagueCache(string leagueId);
    Task<GetGamesByTeamResponse> GetGamesByTeamCache(string teamId);
    Task<GetBaseballGameLineupByGameIdResponse> GetBaseballGameLineupByGameIdCache(string id, string teamId);
    Task<AnyBaseballGameLineupByGameIdResponse> AnyBaseballGameLineupByGameIdCache(string id, string teamId);
    Task SetGameByIdCache(string id, GetGameByIdResponse gameByIdResponse);
    Task SetGamesByLeagueCache(string leagueId, GetGamesByLeagueResponse gamesByLeagueResponse);
    Task SetGamesByTeamCache(string teamId, GetGamesByTeamResponse gamesByTeamResponse);
    Task SetAnyBaseballGameLineupByGameIdCache(string id, string teamId, AnyBaseballGameLineupByGameIdResponse anyGameByGameResponse);
    Task SetBaseballGameLineupByGameIdCache(string id, string teamId, GetBaseballGameLineupByGameIdResponse baseballGameLineupResponse);
    Task DeleteGameByIdCache(string id);
    Task DeleteGamesByLeagueCache(string leagueId);
    Task DeleteGamesByTeamCache(string teamId);
    Task DeleteAnyBaseballGameLineupByGameIdCache(string id, string teamId);
    Task DeleteBaseballGameLineupByGameIdCache(string id, string teamId);
}
