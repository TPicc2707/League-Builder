using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace League.Builder.Web.Server.Services.Cache;

public class StandingsLocalCacheService : IStandingsLocalCacheService
{
    private readonly IDistributedCache? _cache;

    public StandingsLocalCacheService(IDistributedCache cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<GetStandingsByLeagueResponse> GetStandingsByLeagueCache(string leagueId)
    {
        string? standingsCache = await _cache.GetStringAsync($"StandingsByLeague: {leagueId}");

        if (standingsCache is not null)
            return JsonSerializer.Deserialize<GetStandingsByLeagueResponse>(standingsCache);

        return null;
    }

    public async Task<GetStandingsByTeamResponse> GetStandingsByTeamCache(string teamId)
    {
        string? standingsCache = await _cache.GetStringAsync($"StandingsByTeam: {teamId}");

        if (standingsCache is not null)
            return JsonSerializer.Deserialize<GetStandingsByTeamResponse>(standingsCache);

        return null;
    }

    public async Task SetStandingsByLeagueCache(string leagueId, GetStandingsByLeagueResponse standingsByLeagueResponse)
    {
        string serializedStandings = JsonSerializer.Serialize(standingsByLeagueResponse);
        await _cache.SetStringAsync($"StandingsByLeague: {leagueId}", serializedStandings, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetStandingsByTeamCache(string teamId, GetStandingsByTeamResponse standingsByTeamResponse)
    {
        string serializedStandings = JsonSerializer.Serialize(standingsByTeamResponse);
        await _cache.SetStringAsync($"StandingsByTeam: {teamId}", serializedStandings, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task DeleteStandingsByLeagueCache(string leagueId)
    {
        await _cache.RemoveAsync($"StandingsByLeague: {leagueId}");
    }

    public async Task DeleteStandingsByTeamCache(string teamId)
    {
        await _cache.RemoveAsync($"StandingsByTeam: {teamId}");
    }
}
