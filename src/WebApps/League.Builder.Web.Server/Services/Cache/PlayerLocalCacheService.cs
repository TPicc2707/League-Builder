using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace League.Builder.Web.Server.Services.Cache;

public class PlayerLocalCacheService : IPlayerLocalCacheService
{
    private readonly IDistributedCache? _cache;

    public PlayerLocalCacheService(IDistributedCache cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<GetPlayersResponse> GetPlayersCache()
    {
        string? playersCache = await _cache.GetStringAsync("Players");

        if (playersCache is not null)
            return JsonSerializer.Deserialize<GetPlayersResponse>(playersCache);

        return null;
    }

    public async Task<GetPlayerByIdResponse> GetPlayerByIdCache(string id)
    {
        string? playerCache = await _cache.GetStringAsync($"Player: {id}");

        if (playerCache is not null)
            return JsonSerializer.Deserialize<GetPlayerByIdResponse>(playerCache);

        return null;
    }

    public async Task<GetPlayersByTeamResponse> GetPlayersByTeamCache(string teamId)
    {
        string? playersCache = await _cache.GetStringAsync($"PlayersByTeam: {teamId}");

        if (playersCache is not null)
            return JsonSerializer.Deserialize<GetPlayersByTeamResponse>(playersCache);

        return null;
    }

    public async Task<GetPlayersByFirstNameResponse> GetPlayersByFirstNameCache()
    {
        string? playersCache = await _cache.GetStringAsync($"PlayersByFirstName");

        if (playersCache is not null)
            return JsonSerializer.Deserialize<GetPlayersByFirstNameResponse>(playersCache);

        return null;
    }

    public async Task<GetPlayersByLastNameResponse> GetPlayersByLastNameCache()
    {
        string? playersCache = await _cache.GetStringAsync($"PlayersByLastName");

        if (playersCache is not null)
            return JsonSerializer.Deserialize<GetPlayersByLastNameResponse>(playersCache);

        return null;
    }

    public async Task<GetPlayersByPositionResponse> GetPlayersByPositionCache()
    {
        string? playersCache = await _cache.GetStringAsync($"PlayersByPosition");

        if (playersCache is not null)
            return JsonSerializer.Deserialize<GetPlayersByPositionResponse>(playersCache);

        return null;
    }

    public async Task<GetPlayersByBirthDateResponse> GetPlayersByBirthDateCache()
    {
        string? playersCache = await _cache.GetStringAsync($"PlayersByBirthDate");

        if (playersCache is not null)
            return JsonSerializer.Deserialize<GetPlayersByBirthDateResponse>(playersCache);

        return null;
    }

    public async Task<GetPlayersBeforeBirthDateResponse> GetPlayersBeforeBirthDateCache()
    {
        string? playersCache = await _cache.GetStringAsync($"PlayersBeforeBirthDate");

        if (playersCache is not null)
            return JsonSerializer.Deserialize<GetPlayersBeforeBirthDateResponse>(playersCache);

        return null;
    }

    public async Task<GetPlayersAfterBirthDateResponse> GetPlayersAfterBirthDateCache()
    {
        string? playersCache = await _cache.GetStringAsync($"PlayersAfterBirthDate");

        if (playersCache is not null)
            return JsonSerializer.Deserialize<GetPlayersAfterBirthDateResponse>(playersCache);

        return null;
    }

    public async Task SetPlayersCache(GetPlayersResponse playersResponse)
    {
        string serializedPlayers = JsonSerializer.Serialize(playersResponse);
        await _cache.SetStringAsync("Players", serializedPlayers, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetPlayerByIdCache(GetPlayerByIdResponse playerByIdResponse, string id)
    {
        string serializedPlayers = JsonSerializer.Serialize(playerByIdResponse);
        await _cache.SetStringAsync($"Player: {id}", serializedPlayers, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetPlayersByFirstNameCache(GetPlayersByFirstNameResponse playersByFirstNameResponse)
    {
        string serializedPlayers = JsonSerializer.Serialize(playersByFirstNameResponse);
        await _cache.SetStringAsync("PlayersByFirstName", serializedPlayers, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetPlayersByLastNameCache(GetPlayersByLastNameResponse playersByLastNameResponse)
    {
        string serializedPlayers = JsonSerializer.Serialize(playersByLastNameResponse);
        await _cache.SetStringAsync("PlayersByLastName", serializedPlayers, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetPlayersByPositionCache(GetPlayersByPositionResponse playersByPositionResponse)
    {
        string serializedPlayers = JsonSerializer.Serialize(playersByPositionResponse);
        await _cache.SetStringAsync("PlayersByPosition", serializedPlayers, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetPlayersByBirthDateCache(GetPlayersByBirthDateResponse playersByBirthDateResponse)
    {
        string serializedPlayers = JsonSerializer.Serialize(playersByBirthDateResponse);
        await _cache.SetStringAsync("PlayersByBirthDate", serializedPlayers, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetPlayersBeforeBirthDateCache(GetPlayersBeforeBirthDateResponse playersBeforeBirthDateResponse)
    {
        string serializedPlayers = JsonSerializer.Serialize(playersBeforeBirthDateResponse);
        await _cache.SetStringAsync("PlayersBeforeBirthDate", serializedPlayers, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetPlayersAfterBirthDateCache(GetPlayersAfterBirthDateResponse playersAfterBirthDateResponse)
    {
        string serializedPlayers = JsonSerializer.Serialize(playersAfterBirthDateResponse);
        await _cache.SetStringAsync("PlayersAfterBirthDate", serializedPlayers, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetPlayersByTeamCache(string teamId, GetPlayersByTeamResponse playersByTeamResponse)
    {
        string serializedPlayers = JsonSerializer.Serialize(playersByTeamResponse);
        await _cache.SetStringAsync($"PlayersByTeam: {teamId}", serializedPlayers, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task DeletePlayersCache()
    {
        await _cache.RemoveAsync("Players");
    }

    public async Task DeletePlayerByIdCache(string id)
    {
        await _cache.RemoveAsync($"Player: {id}");
    }

    public async Task DeletePlayersByTeamCache(string teamId)
    {
        await _cache.RemoveAsync($"PlayersByTeam: {teamId}");
    }

    public async Task DeletePlayersByFirstNameCache()
    {
        await _cache.RemoveAsync("PlayersByFirstName");
    }

    public async Task DeletePlayersByLastNameCache()
    {
        await _cache.RemoveAsync("PlayersByLastName");
    }

    public async Task DeletePlayersByPositionCache()
    {
        await _cache.RemoveAsync("PlayersByPosition");
    }

    public async Task DeletePlayersByBirthDateCache()
    {
        await _cache.RemoveAsync("PlayersByBirthDate");
    }
    
    public async Task DeletePlayersBeforeBirthDateCache()
    {
        await _cache.RemoveAsync("PlayersBeforeBirthDate");
    }

    public async Task DeletePlayersAfterBirthDateCache()
    {
        await _cache.RemoveAsync("PlayersAfterBirthDate");
    }
}
