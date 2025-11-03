using Blazored.LocalStorage;

namespace League.Builder.Web.Server.Services.Cache;

public class PlayerLocalCacheService : IPlayerLocalCacheService
{
    private readonly ILocalStorageService _localStorage;

    public PlayerLocalCacheService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
    }

    public async Task<GetPlayersResponse> GetPlayersCache()
    {
        return await _localStorage.GetItemAsync<GetPlayersResponse>("Players");
    }

    public async Task<GetPlayerByIdResponse> GetPlayerByIdCache(string id)
    {
        return await _localStorage.GetItemAsync<GetPlayerByIdResponse>($"Player: {id}");
    }

    public async Task<GetPlayersByTeamResponse> GetPlayersByTeamCache(string teamId)
    {
        return await _localStorage.GetItemAsync<GetPlayersByTeamResponse>($"PlayersByTeam: {teamId}");
    }

    public async Task<GetPlayersByFirstNameResponse> GetPlayersByFirstNameCache()
    {
        return await _localStorage.GetItemAsync<GetPlayersByFirstNameResponse>("PlayersByFirstName");
    }

    public async Task<GetPlayersByLastNameResponse> GetPlayersByLastNameCache()
    {
        return await _localStorage.GetItemAsync<GetPlayersByLastNameResponse>("PlayersByLastName");
    }

    public async Task<GetPlayersByPositionResponse> GetPlayersByPositionCache()
    {
        return await _localStorage.GetItemAsync<GetPlayersByPositionResponse>("PlayersByPosition");
    }

    public async Task<GetPlayersByBirthDateResponse> GetPlayersByBirthDateCache()
    {
        return await _localStorage.GetItemAsync<GetPlayersByBirthDateResponse>("PlayersByBirthDate");
    }

    public async Task<GetPlayersBeforeBirthDateResponse> GetPlayersBeforeBirthDateCache()
    {
        return await _localStorage.GetItemAsync<GetPlayersBeforeBirthDateResponse>("PlayersBeforeBirthDate");
    }

    public async Task<GetPlayersAfterBirthDateResponse> GetPlayersAfterBirthDateCache()
    {
        return await _localStorage.GetItemAsync<GetPlayersAfterBirthDateResponse>("PlayersAfterBirthDate");
    }

    public async Task SetPlayersCache(GetPlayersResponse playersResponse)
    {
        await _localStorage.SetItemAsync("Players", playersResponse);
    }

    public async Task SetPlayerByIdCache(GetPlayerByIdResponse playerByIdResponse, string id)
    {
        await _localStorage.SetItemAsync($"Player: {id}", playerByIdResponse);
    }

    public async Task SetPlayersByFirstNameCache(GetPlayersByFirstNameResponse playersByFirstNameResponse)
    {
        await _localStorage.SetItemAsync("PlayersByFirstName", playersByFirstNameResponse);
    }

    public async Task SetPlayersByLastNameCache(GetPlayersByLastNameResponse playersByLastNameResponse)
    {
        await _localStorage.SetItemAsync("PlayersByLastName", playersByLastNameResponse);
    }

    public async Task SetPlayersByPositionCache(GetPlayersByPositionResponse playersByPositionResponse)
    {
        await _localStorage.SetItemAsync("PlayersByPosition", playersByPositionResponse);
    }

    public async Task SetPlayersByBirthDateCache(GetPlayersByBirthDateResponse playersByBirthDateResponse)
    {
        await _localStorage.SetItemAsync("PlayersByBirthDate", playersByBirthDateResponse);
    }

    public async Task SetPlayersBeforeBirthDateCache(GetPlayersBeforeBirthDateResponse playersBeforeBirthDateResponse)
    {
        await _localStorage.SetItemAsync("PlayersBeforeBirthDate", playersBeforeBirthDateResponse);
    }

    public async Task SetPlayersAfterBirthDateCache(GetPlayersAfterBirthDateResponse playersAfterBirthDateResponse)
    {
        await _localStorage.SetItemAsync("PlayersAfterBirthDate", playersAfterBirthDateResponse);
    }

    public async Task SetPlayersByTeamCache(string teamId, GetPlayersByTeamResponse playersByTeamResponse)
    {
        await _localStorage.SetItemAsync($"PlayersByTeam: {teamId}", playersByTeamResponse);
    }

    public async Task DeletePlayersCache()
    {
        await _localStorage.RemoveItemAsync("Players");
    }

    public async Task DeletePlayersByTeamCache(string id)
    {
        await _localStorage.RemoveItemAsync($"PlayersByTeam: {id}");
    }

    public async Task DeletePlayersByFirstNameCache()
    {
        await _localStorage.RemoveItemAsync("PlayersByFirstName");
    }

    public async Task DeletePlayersByLastNameCache()
    {
        await _localStorage.RemoveItemAsync("PlayersByLastName");
    }

    public async Task DeletePlayersByPositionCache()
    {
        await _localStorage.RemoveItemAsync("PlayersByPosition");
    }

    public async Task DeletePlayersByBirthDateCache()
    {
        await _localStorage.RemoveItemAsync("PlayersByBirthDate");
    }
    
    public async Task DeletePlayersBeforeBirthDateCache()
    {
        await _localStorage.RemoveItemAsync("PlayersBeforeBirthDate");
    }

    public async Task DeletePlayersAfterBirthDateCache()
    {
        await _localStorage.RemoveItemAsync("PlayersAfterBirthDate");
    }
}
