namespace League.Builder.Web.Server.Services.Cache;

public interface ILeagueLocalCacheService
{
    Task<GetLeaguesResponse> GetLeaguesCache();
    Task<GetLeagueByIdResponse> GetLeagueByIdCache(string id);
    Task<GetLeaguesBySportResponse> GetLeaguesBySportCache(string sport);
    Task<GetLeaguesByNameResponse> GetLeaguesByNameCache();
    Task SetLeaguesCache(GetLeaguesResponse leaguesResponse);
    Task SetLeagueByIdCache(string id, GetLeagueByIdResponse leagueByIdResponse);
    Task SetLeaguesBySportCache(string sport, GetLeaguesBySportResponse leaguesBySportResponse);
    Task SetLeaguesByNameCache(GetLeaguesByNameResponse leaguesByNameResponse);
    Task DeleteLeaguesCache();
    Task DeleteLeagueByIdCache(string id);
    Task DeleteLeagueBySportCache(string sport);
    Task DeleteLeagueByNameCache();
}
