namespace League.Builder.Web.Server.Services.Cache;

public interface ITeamLocalCacheService
{
    Task<GetTeamsResponse> GetTeamsCache();
    Task<GetTeamByIdResponse> GetTeamByIdCache(string id);
    Task<GetTeamsByLeagueResponse> GetTeamsByLeagueCache(string leagueId);
    Task<GetTeamsByNameResponse> GetTeamsByNameCache();
    Task SetTeamsCache(GetTeamsResponse teamsResponse);
    Task SetTeamByIdCache(string id, GetTeamByIdResponse teamByIdResponse);
    Task SetTeamsByLeagueCache(string leagueId, GetTeamsByLeagueResponse teamsByLeagueResponse);
    Task SetTeamsByNameCache( GetTeamsByNameResponse teamsByNameResponse);
    Task DeleteTeamsCache();
    Task DeleteTeamByIdCache(string id);
    Task DeleteTeamsByNameCache();
    Task DeleteTeamsByLeagueCache(string leagueId);
}
