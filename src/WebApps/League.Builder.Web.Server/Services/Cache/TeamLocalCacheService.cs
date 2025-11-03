using Blazored.LocalStorage;

namespace League.Builder.Web.Server.Services.Cache;

public class TeamLocalCacheService : ITeamLocalCacheService
{
    private readonly ILocalStorageService _localStorage;

    public TeamLocalCacheService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
    }

    public async Task<GetTeamsResponse> GetTeamsCache()
    {
        return await _localStorage.GetItemAsync<GetTeamsResponse>("Teams");
    }

    public async Task<GetTeamByIdResponse> GetTeamByIdCache(string id)
    {
        return await _localStorage.GetItemAsync<GetTeamByIdResponse>($"Team: {id}");
    }

    public async Task<GetTeamsByLeagueResponse> GetTeamsByLeagueCache(string leagueId)
    {
        return await _localStorage.GetItemAsync<GetTeamsByLeagueResponse>($"TeamsByLeague: {leagueId}");
    }

    public async Task<GetTeamsByNameResponse> GetTeamsByNameCache()
    {
        return await _localStorage.GetItemAsync<GetTeamsByNameResponse>($"TeamsByName");
    }

    public async Task SetTeamsCache(GetTeamsResponse teamsResponse)
    {
        await _localStorage.SetItemAsync("Teams", teamsResponse);
    }

    public async Task SetTeamByIdCache(string id, GetTeamByIdResponse teamByIdResponse)
    {
        await _localStorage.SetItemAsync($"Team: {id}", teamByIdResponse);
    }

    public async Task SetTeamsByLeagueCache(string leagueId, GetTeamsByLeagueResponse teamsByLeagueResponse)
    {
        await _localStorage.SetItemAsync($"TeamsByLeague: {leagueId}", teamsByLeagueResponse);
    }

    public async Task SetTeamsByNameCache( GetTeamsByNameResponse getTeamsByNameResponse)
    {
        await _localStorage.SetItemAsync($"TeamsByName", getTeamsByNameResponse);
    }

    public async Task DeleteTeamsCache()
    {
        await _localStorage.RemoveItemAsync("Teams");
    }
    public async Task DeleteTeamByIdCache(string id)
    {
        await _localStorage.RemoveItemAsync($"Team: {id}");
    }

    public async Task DeleteTeamsByNameCache()
    {
        await _localStorage.RemoveItemAsync($"TeamsByName");
    }

    public async Task DeleteTeamsByLeagueCache(string leagueId)
    {
        await _localStorage.RemoveItemAsync($"TeamsByLeague: {leagueId}");
    }

}
