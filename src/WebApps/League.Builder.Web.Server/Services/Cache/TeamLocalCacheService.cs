using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace League.Builder.Web.Server.Services.Cache;

public class TeamLocalCacheService : ITeamLocalCacheService
{
    private readonly IDistributedCache? _cache;

    public TeamLocalCacheService(IDistributedCache cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<GetTeamsResponse> GetTeamsCache()
    {
        string? teamsCache = await _cache.GetStringAsync("Teams");

        if (teamsCache is not null)
            return JsonSerializer.Deserialize<GetTeamsResponse>(teamsCache);

        return null;
    }

    public async Task<GetTeamByIdResponse> GetTeamByIdCache(string id)
    {
        string? teamsCache = await _cache.GetStringAsync($"Team: {id}");

        if (teamsCache is not null)
            return JsonSerializer.Deserialize<GetTeamByIdResponse>(teamsCache);

        return null;
    }

    public async Task<GetTeamsByLeagueResponse> GetTeamsByLeagueCache(string leagueId)
    {
        string? teamsCache = await _cache.GetStringAsync($"TeamsByLeague: {leagueId}");

        if (teamsCache is not null)
            return JsonSerializer.Deserialize<GetTeamsByLeagueResponse>(teamsCache);

        return null;
    }

    public async Task<GetTeamsByNameResponse> GetTeamsByNameCache()
    {
        string? teamsCache = await _cache.GetStringAsync($"TeamsByName");

        if (teamsCache is not null)
            return JsonSerializer.Deserialize<GetTeamsByNameResponse>(teamsCache);

        return null;
    }

    public async Task SetTeamsCache(GetTeamsResponse teamsResponse)
    {
        string serializedTeams = JsonSerializer.Serialize(teamsResponse);
        await _cache.SetStringAsync("Teams", serializedTeams, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetTeamByIdCache(string id, GetTeamByIdResponse teamByIdResponse)
    {
        string serializedTeams = JsonSerializer.Serialize(teamByIdResponse);
        await _cache.SetStringAsync($"Team: {id}", serializedTeams, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetTeamsByLeagueCache(string leagueId, GetTeamsByLeagueResponse teamsByLeagueResponse)
    {
        string serializedTeams = JsonSerializer.Serialize(teamsByLeagueResponse);
        await _cache.SetStringAsync($"TeamsByLeague: {leagueId}", serializedTeams, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetTeamsByNameCache( GetTeamsByNameResponse getTeamsByNameResponse)
    {
        string serializedTeams = JsonSerializer.Serialize(getTeamsByNameResponse);
        await _cache.SetStringAsync($"TeamsByName", serializedTeams, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task DeleteTeamsCache()
    {
        await _cache.RemoveAsync("Teams");
    }
    public async Task DeleteTeamByIdCache(string id)
    {
        await _cache.RemoveAsync($"Team: {id}");
    }

    public async Task DeleteTeamsByNameCache()
    {
        await _cache.RemoveAsync($"TeamsByName");
    }

    public async Task DeleteTeamsByLeagueCache(string leagueId)
    {
        await _cache.RemoveAsync($"TeamsByLeague: {leagueId}");
    }

}
