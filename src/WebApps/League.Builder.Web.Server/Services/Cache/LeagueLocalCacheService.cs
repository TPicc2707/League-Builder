using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace League.Builder.Web.Server.Services.Cache;

public class LeagueLocalCacheService : ILeagueLocalCacheService
{
    private readonly IDistributedCache? _cache;

    public LeagueLocalCacheService(IDistributedCache cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<GetLeaguesResponse> GetLeaguesCache()
    {
        string? leaguesCache = await _cache.GetStringAsync("Leagues");

        if (leaguesCache is not null)
            return JsonSerializer.Deserialize<GetLeaguesResponse>(leaguesCache);

        return null;
    }

    public async Task<GetLeagueByIdResponse> GetLeagueByIdCache(string id)
    {
        string? leagueCache = await _cache.GetStringAsync($"League: {id}");

        if (leagueCache is not null)
            return JsonSerializer.Deserialize<GetLeagueByIdResponse>(leagueCache);

        return null;
    }

    public async Task<GetLeaguesBySportResponse> GetLeaguesBySportCache(string sport)
    {
        string? leaguesCache = await _cache.GetStringAsync($"LeaguesBySport: {sport}");

        if (leaguesCache is not null)
            return JsonSerializer.Deserialize<GetLeaguesBySportResponse>(leaguesCache);

        return null;
    }

    public async Task<GetLeaguesByNameResponse> GetLeaguesByNameCache()
    {
        string? leaguesCache = await _cache.GetStringAsync($"LeaguesByName");

        if (leaguesCache is not null)
            return JsonSerializer.Deserialize<GetLeaguesByNameResponse>(leaguesCache);

        return null;
    }

    public async Task SetLeaguesCache(GetLeaguesResponse leaguesResponse)
    {
        string serializedLeague = JsonSerializer.Serialize(leaguesResponse);
        await _cache.SetStringAsync("Leagues", serializedLeague, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetLeagueByIdCache(string id, GetLeagueByIdResponse leagueByIdResponse)
    {
        string serializedLeague = JsonSerializer.Serialize(leagueByIdResponse);
        await _cache.SetStringAsync($"League: {id}", serializedLeague, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetLeaguesBySportCache(string sport, GetLeaguesBySportResponse leaguesBySportResponse)
    {
        string serializedLeague = JsonSerializer.Serialize(leaguesBySportResponse);
        await _cache.SetStringAsync($"LeaguesBySport: {sport}", serializedLeague, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetLeaguesByNameCache(GetLeaguesByNameResponse leaguesByNameResponse)
    {
        string serializedLeague = JsonSerializer.Serialize(leaguesByNameResponse);
        await _cache.SetStringAsync($"LeaguesByName", serializedLeague, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task DeleteLeaguesCache()
    {
        await _cache.RemoveAsync("Leagues");
    }

    public async Task DeleteLeagueByIdCache(string id)
    {
        await _cache.RemoveAsync($"League: {id}");
    }

    public async Task DeleteLeagueBySportCache(string sport)
    {
        await _cache.RemoveAsync($"LeaguesBySport: {sport}");
    }

    public async Task DeleteLeagueByNameCache()
    {
        await _cache.RemoveAsync("LeaguesByName");
    }
}
