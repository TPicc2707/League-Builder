using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace League.Builder.Web.Server.Services.Cache;

public class SeasonLocalCacheService : ISeasonLocalCacheService
{
    private readonly IDistributedCache? _cache;

    public SeasonLocalCacheService(IDistributedCache cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<GetSeasonsResponse> GetSeasonsCache()
    {
        string? seasonsCache = await _cache.GetStringAsync("Seasons");

        if (seasonsCache is not null)
            return JsonSerializer.Deserialize<GetSeasonsResponse>(seasonsCache);

        return null;
    }

    public async Task<GetSeasonByIdResponse> GetSeasonByIdCache(string id)
    {
        string? seasonsCache = await _cache.GetStringAsync($"Season: {id}");

        if (seasonsCache is not null)
            return JsonSerializer.Deserialize<GetSeasonByIdResponse>(seasonsCache);

        return null;
    }

    public async Task<GetSeasonByYearResponse> GetSeasonByYearCache(int year)
    {
        string? seasonsCache = await _cache.GetStringAsync($"SeasonByYear: {year}");

        if (seasonsCache is not null)
            return JsonSerializer.Deserialize<GetSeasonByYearResponse>(seasonsCache);

        return null;
    }

    public async Task SetSeasonsCache(GetSeasonsResponse seasonsResponse)
    {
        string serializedSeasons = JsonSerializer.Serialize(seasonsResponse);
        await _cache.SetStringAsync("Seasons", serializedSeasons, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetSeasonByIdCache(string id, GetSeasonByIdResponse seasonByIdResponse)
    {
        string serializedSeasons = JsonSerializer.Serialize(seasonByIdResponse);
        await _cache.SetStringAsync($"Season: {id}", serializedSeasons, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetSeasonByYearCache(int year, GetSeasonByYearResponse seasonByYearResponse)
    {
        string serializedSeasons = JsonSerializer.Serialize(seasonByYearResponse);
        await _cache.SetStringAsync($"SeasonByYear: {year}", serializedSeasons, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task DeleteSeasonsCache()
    {
        await _cache.RemoveAsync("Seasons");
    }

    public async Task DeleteSeasonByIdCache(string id)
    {
        await _cache.RemoveAsync($"Season: {id}");
    }

    public async Task DeleteSeasonByYearCache(int year)
    {
        await _cache.RemoveAsync($"SeasonByYear: {year}");
    }
}
