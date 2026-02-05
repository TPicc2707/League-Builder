using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace League.Builder.Web.Server.Services.Cache;

public class GameLocalCacheService : IGameLocalCacheService
{
    private readonly IDistributedCache? _cache;

    public GameLocalCacheService(IDistributedCache cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<GetGameByIdResponse> GetGameByIdCache(string id)
    {
        string? gameIdCache = await _cache.GetStringAsync($"Game: {id}");

        if (gameIdCache is not null)
            return JsonSerializer.Deserialize<GetGameByIdResponse>(gameIdCache);

        return null;
    }

    public async Task<GetGamesByLeagueResponse> GetGamesByLeagueCache(string leagueId)
    {
        string? gameByLeagueIdCache = await _cache.GetStringAsync($"GamesByLeague: {leagueId}");

        if (gameByLeagueIdCache is not null)
            return JsonSerializer.Deserialize<GetGamesByLeagueResponse>(gameByLeagueIdCache);

        return null;

    }

    public async Task<GetGamesByTeamResponse> GetGamesByTeamCache(string teamId)
    {
        string? gameByTeamCache = await _cache.GetStringAsync($"GamesByTeam: {teamId}");

        if (gameByTeamCache is not null)
            return JsonSerializer.Deserialize<GetGamesByTeamResponse>(gameByTeamCache);

        return null;

    }

    public async Task SetGameByIdCache(string id, GetGameByIdResponse gameByIdResponse)
    {
        string serializedGame = JsonSerializer.Serialize(gameByIdResponse);
        await _cache.SetStringAsync($"Game: {id}", serializedGame, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetGamesByLeagueCache(string leagueId, GetGamesByLeagueResponse gamesByLeagueResponse)
    {
        string serializedGame = JsonSerializer.Serialize(gamesByLeagueResponse);
        await _cache.SetStringAsync($"GamesByLeague: {leagueId}", serializedGame, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
   }

    public async Task SetGamesByTeamCache(string teamId, GetGamesByTeamResponse gamesByTeamResponse)
    {
        string serializedGame = JsonSerializer.Serialize(gamesByTeamResponse);
        await _cache.SetStringAsync($"GamesByTeam: {teamId}", serializedGame, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task DeleteGameByIdCache(string id)
    {
        await _cache.RemoveAsync($"Game: {id}");
    }

    public async Task DeleteGamesByLeagueCache(string leagueId)
    {
        await _cache.RemoveAsync($"GamesByLeague: {leagueId}");
    }

    public async Task DeleteGamesByTeamCache(string teamId)
    {
        await _cache.RemoveAsync($"GamesByTeam: {teamId}");
    }
}
