using Blazored.LocalStorage;

namespace League.Builder.Web.Server.Services.Cache;

public class LeagueLocalCacheService : ILeagueLocalCacheService
{
    private readonly ILocalStorageService _localStorage;

    public LeagueLocalCacheService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
    }

    public async Task<GetLeaguesResponse> GetLeaguesCache()
    {
        return await _localStorage.GetItemAsync<GetLeaguesResponse>("Leagues");
    }

    public async Task<GetLeagueByIdResponse> GetLeagueByIdCache(string id)
    {
        return await _localStorage.GetItemAsync<GetLeagueByIdResponse>($"League: {id}");
    }

    public async Task<GetLeaguesBySportResponse> GetLeaguesBySportCache(string sport)
    {
        return await _localStorage.GetItemAsync<GetLeaguesBySportResponse>($"LeaguesBySport: {sport}");
    }

    public async Task<GetLeaguesByNameResponse> GetLeaguesByNameCache()
    {
        return await _localStorage.GetItemAsync<GetLeaguesByNameResponse>($"LeaguesByName");
    }

    public async Task SetLeaguesCache(GetLeaguesResponse leaguesResponse)
    {
        await _localStorage.SetItemAsync("Leagues", leaguesResponse);
    }

    public async Task SetLeagueByIdCache(string id, GetLeagueByIdResponse leagueByIdResponse)
    {
        await _localStorage.SetItemAsync($"League: {id}", leagueByIdResponse);
    }

    public async Task SetLeaguesBySportCache(string sport, GetLeaguesBySportResponse leaguesBySportResponse)
    {
        await _localStorage.SetItemAsync($"LeaguesBySport: {sport}", leaguesBySportResponse);
    }

    public async Task SetLeaguesByNameCache(GetLeaguesByNameResponse leaguesByNameResponse)
    {
        await _localStorage.SetItemAsync($"LeaguesByName", leaguesByNameResponse);
    }

    public async Task DeleteLeaguesCache()
    {
        await _localStorage.RemoveItemAsync("Leagues");
    }

    public async Task DeleteLeagueByIdCache(string id)
    {
        await _localStorage.RemoveItemAsync($"League: {id}");
    }

    public async Task DeleteLeagueBySportCache(string sport)
    {
        await _localStorage.RemoveItemAsync($"LeaguesBySport: {sport}");
    }

    public async Task DeleteLeagueByNameCache()
    {
        await _localStorage.RemoveItemAsync("LeaguesByName");
    }
}
