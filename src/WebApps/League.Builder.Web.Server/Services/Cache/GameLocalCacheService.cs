using Blazored.LocalStorage;

namespace League.Builder.Web.Server.Services.Cache;

public class GameLocalCacheService : IGameLocalCacheService
{
    private readonly ILocalStorageService _localStorage;

    public GameLocalCacheService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
    }

    public async Task<GetGameByIdResponse> GetGameByIdCache(string id)
    {
        return await _localStorage.GetItemAsync<GetGameByIdResponse>($"Game: {id}");
    }

    public async Task<GetGamesByLeagueResponse> GetGamesByLeagueCache(string leagueId)
    {
        return await _localStorage.GetItemAsync<GetGamesByLeagueResponse>($"GamesByLeague: {leagueId}");
    }

    public async Task<GetGamesByTeamResponse> GetGamesByTeamCache(string teamId)
    {
        return await _localStorage.GetItemAsync<GetGamesByTeamResponse>($"GamesByTeam: {teamId}");
    }

    public async Task SetGameByIdCache(string id, GetGameByIdResponse gameByIdResponse)
    {
        await _localStorage.SetItemAsync($"Game: {id}", gameByIdResponse);
    }

    public async Task SetGamesByLeagueCache(string leagueId, GetGamesByLeagueResponse gamesByLeagueResponse)
    {
        await _localStorage.SetItemAsync($"GamesByLeague: {leagueId}", gamesByLeagueResponse);
    }

    public async Task SetGamesByTeamCache(string teamId, GetGamesByTeamResponse gamesByTeamResponse)
    {
        await _localStorage.SetItemAsync($"GamesByTeam: {teamId}", gamesByTeamResponse);
    }

    public async Task DeleteGameByIdCache(string id)
    {
        await _localStorage.RemoveItemAsync($"Game: {id}");
    }

    public async Task DeleteGamesByLeagueCache(string leagueId)
    {
        await _localStorage.RemoveItemAsync($"GamesByLeague: {leagueId}");
    }

    public async Task DeleteGamesByTeamCache(string teamId)
    {
        await _localStorage.RemoveItemAsync($"GamesByTeam: {teamId}");
    }
}
