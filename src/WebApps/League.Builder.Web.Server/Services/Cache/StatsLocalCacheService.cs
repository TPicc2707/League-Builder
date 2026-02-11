using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace League.Builder.Web.Server.Services.Cache;

public class StatsLocalCacheService : IStatsLocalCacheService
{
    private readonly IDistributedCache? _cache;

    public StatsLocalCacheService(IDistributedCache cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<GetLeagueBaseballStatsBySeasonResponse> GetLeagueBaseballStatsBySeasonCache(string leagueId, string seasonId)
    {
        string? statsCache = await _cache.GetStringAsync($"LeagueBaseballStatsBySeason: League: {leagueId}, Season: {seasonId}");

        if (statsCache is not null)
            return JsonSerializer.Deserialize<GetLeagueBaseballStatsBySeasonResponse>(statsCache);

        return null;
    }

    public async Task<GetLeagueBasketballStatsBySeasonResponse> GetLeagueBasketballStatsBySeasonCache(string leagueId, string seasonId)
    {
        string? statsCache = await _cache.GetStringAsync($"LeagueBasketballStatsBySeason: League: {leagueId}, Season: {seasonId}");

        if (statsCache is not null)
            return JsonSerializer.Deserialize<GetLeagueBasketballStatsBySeasonResponse>(statsCache);

        return null;
    }

    public async Task<GetLeagueFootballStatsBySeasonResponse> GetLeagueFootballStatsBySeasonCache(string leagueId, string seasonId)
    {
        string? statsCache = await _cache.GetStringAsync($"LeagueFootballStatsBySeason: League: {leagueId}, Season: {seasonId}");

        if (statsCache is not null)
            return JsonSerializer.Deserialize<GetLeagueFootballStatsBySeasonResponse>(statsCache);

        return null;
    }

    public async Task<GetBaseballStatsByPlayerResponse> GetBaseballStatsByPlayerCache(string playerId)
    {
        string? statsCache = await _cache.GetStringAsync($"BaseballStatsByPlayer: {playerId}");

        if (statsCache is not null)
            return JsonSerializer.Deserialize<GetBaseballStatsByPlayerResponse>(statsCache);

        return null;
    }

    public async Task<GetBaseballStatsByTeamResponse> GetBaseballStatsByTeamCache(string teamId)
    {
        string? statsCache = await _cache.GetStringAsync($"BaseballStatsByTeam: {teamId}");

        if (statsCache is not null)
            return JsonSerializer.Deserialize<GetBaseballStatsByTeamResponse>(statsCache);

        return null;
    }

    public async Task<GetBasketballStatsByPlayerResponse> GetBasketballStatsByPlayerCache(string playerId)
    {
        string? statsCache = await _cache.GetStringAsync($"BasketballStatsByPlayer: {playerId}");

        if (statsCache is not null)
            return JsonSerializer.Deserialize<GetBasketballStatsByPlayerResponse>(statsCache);

        return null;
    }

    public async Task<GetBasketballStatsByTeamResponse> GetBasketballStatsByTeamCache(string teamId)
    {
        string? statsCache = await _cache.GetStringAsync($"BasketballStatsByTeam: {teamId}");

        if (statsCache is not null)
            return JsonSerializer.Deserialize<GetBasketballStatsByTeamResponse>(statsCache);

        return null;
    }

    public async Task<GetFootballStatsByPlayerResponse> GetFootballStatsByPlayerCache(string playerId)
    {
        string? statsCache = await _cache.GetStringAsync($"GetFootballStatsByPlayer: {playerId}");

        if (statsCache is not null)
            return JsonSerializer.Deserialize<GetFootballStatsByPlayerResponse>(statsCache);

        return null;
    }

    public async Task<GetFootballStatsByTeamResponse> GetFootballStatsByTeamCache(string teamId)
    {
        string? statsCache = await _cache.GetStringAsync($"FootballStatsByTeam: {teamId}");

        if (statsCache is not null)
            return JsonSerializer.Deserialize<GetFootballStatsByTeamResponse>(statsCache);

        return null;
    }

    public async Task<GetPlayerBaseballStatsBySeasonResponse> GetPlayerBaseballStatsBySeasonCache(string playerId, string seasonId)
    {
        string? statsCache = await _cache.GetStringAsync($"PlayerBaseballStatsBySeason: Player: {playerId} , Season: {seasonId}");

        if (statsCache is not null)
            return JsonSerializer.Deserialize<GetPlayerBaseballStatsBySeasonResponse>(statsCache);

        return null;
    }

    public async Task<GetPlayerBasketballStatsBySeasonResponse> GetPlayerBasketballStatsBySeasonCache(string playerId, string seasonId)
    {
        string? statsCache = await _cache.GetStringAsync($"PlayerBasketballStatsBySeason: Player: {playerId} , Season: {seasonId}");

        if (statsCache is not null)
            return JsonSerializer.Deserialize<GetPlayerBasketballStatsBySeasonResponse>(statsCache);

        return null;
    }

    public async Task<GetPlayerFootballStatsBySeasonResponse> GetPlayerFootballStatsBySeasonCache(string playerId, string seasonId)
    {
        string? statsCache = await _cache.GetStringAsync($"PlayerFootballStatsBySeason: Player: {playerId} , Season: {seasonId}");

        if (statsCache is not null)
            return JsonSerializer.Deserialize<GetPlayerFootballStatsBySeasonResponse>(statsCache);

        return null;
    }

    public async Task SetLeagueBaseballStatsBySeasonCache(string leagueId, string seasonId, GetLeagueBaseballStatsBySeasonResponse leagueBaseballStatsBySeasonResponse)
    {
        string serializedStats = JsonSerializer.Serialize(leagueBaseballStatsBySeasonResponse);
        await _cache.SetStringAsync($"LeagueBaseballStatsBySeason: League: {leagueId}, Season: {seasonId}", serializedStats, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetLeagueBasketballStatsBySeasonCache(string leagueId, string seasonId, GetLeagueBasketballStatsBySeasonResponse leagueBasketballStatsBySeasonResponse)
    {
        string serializedStats = JsonSerializer.Serialize(leagueBasketballStatsBySeasonResponse);
        await _cache.SetStringAsync($"LeagueBasketballStatsBySeason: League: {leagueId}, Season: {seasonId}", serializedStats, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetLeagueFootballStatsBySeasonCache(string leagueId, string seasonId, GetLeagueFootballStatsBySeasonResponse leagueFootballStatsBySeasonResponse)
    {
        string serializedStats = JsonSerializer.Serialize(leagueFootballStatsBySeasonResponse);
        await _cache.SetStringAsync($"LeagueFootballStatsBySeason: League: {leagueId}, Season: {seasonId}", serializedStats, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetBaseballStatsByPlayerCache(string playerId, GetBaseballStatsByPlayerResponse baseballStatsByPlayerResponse)
    {
        string serializedStats = JsonSerializer.Serialize(baseballStatsByPlayerResponse);
        await _cache.SetStringAsync($"BaseballStatsByPlayer: {playerId}", serializedStats, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetBaseballStatsByTeamCache(string teamId, GetBaseballStatsByTeamResponse baseballStatsByTeamResponse)
    {
        string serializedStats = JsonSerializer.Serialize(baseballStatsByTeamResponse);
        await _cache.SetStringAsync($"BaseballStatsByTeam: {teamId}", serializedStats, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetBasketballStatsByPlayerCache(string playerId, GetBasketballStatsByPlayerResponse basketballStatsByPlayerResponse)
    {
        string serializedStats = JsonSerializer.Serialize(basketballStatsByPlayerResponse);
        await _cache.SetStringAsync($"BasketballStatsByPlayer: {playerId}", serializedStats, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetBasketballStatsByTeamCache(string teamId, GetBasketballStatsByTeamResponse basketballStatsByTeamResponse)
    {
        string serializedStats = JsonSerializer.Serialize(basketballStatsByTeamResponse);
        await _cache.SetStringAsync($"BasketballStatsByTeam: {teamId}", serializedStats, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetFootballStatsByPlayerCache(string playerId, GetFootballStatsByPlayerResponse footballStatsByPlayerResponse)
    {
        string serializedStats = JsonSerializer.Serialize(footballStatsByPlayerResponse);
        await _cache.SetStringAsync($"GetFootballStatsByPlayer: {playerId}", serializedStats, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetFootballStatsByTeamCache(string teamId, GetFootballStatsByTeamResponse footballStatsByTeamResponse)
    {
        string serializedStats = JsonSerializer.Serialize(footballStatsByTeamResponse);
        await _cache.SetStringAsync($"FootballStatsByTeam: {teamId}", serializedStats, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetPlayerBaseballStatsBySeasonCache(string playerId, string seasonId, GetPlayerBaseballStatsBySeasonResponse playerBaseballStatsBySeasonResponse)
    {
        string serializedStats = JsonSerializer.Serialize(playerBaseballStatsBySeasonResponse);
        await _cache.SetStringAsync($"PlayerBaseballStatsBySeason: Player: {playerId} , Season: {seasonId}", serializedStats, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetPlayerBasketballStatsBySeasonCache(string playerId, string seasonId, GetPlayerBasketballStatsBySeasonResponse playerBasketballStatsBySeasonResponse)
    {
        string serializedStats = JsonSerializer.Serialize(playerBasketballStatsBySeasonResponse);
        await _cache.SetStringAsync($"PlayerBasketballStatsBySeason: Player: {playerId} , Season: {seasonId}", serializedStats, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task SetPlayerFootballStatsBySeasonCache(string playerId, string seasonId, GetPlayerFootballStatsBySeasonResponse playerFootballStatsBySeasonResponse)
    {
        string serializedStats = JsonSerializer.Serialize(playerFootballStatsBySeasonResponse);
        await _cache.SetStringAsync($"PlayerFootballStatsBySeason: Player: {playerId} , Season: {seasonId}", serializedStats, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
    }

    public async Task DeleteLeagueBaseballStatsBySeasonCache(string leagueId, string seasonId)
    {
        await _cache.RemoveAsync($"LeagueBaseballStatsBySeason: League: {leagueId}, Season: {seasonId}");
    }

    public async Task DeleteBaseballStatsByPlayerCache(string playerId)
    {
        await _cache.RemoveAsync($"BaseballStatsByPlayer: {playerId}");
    }

    public async Task DeleteBaseballStatsByTeamCache(string teamId)
    {
        await _cache.RemoveAsync($"BaseballStatsByTeam: {teamId}");
    }

    public async Task DeleteLeagueBasketballStatsBySeasonCache(string leagueId, string seasonId)
    {
        await _cache.RemoveAsync($"LeagueBasketballStatsBySeason: League: {leagueId}, Season: {seasonId}");
    }

    public async Task DeleteBasketballStatsByPlayerCache(string playerId)
    {
        await _cache.RemoveAsync($"BasketballStatsByPlayer: {playerId}");
    }

    public async Task DeleteBasketballStatsByTeamCache(string teamId)
    {
        await _cache.RemoveAsync($"BasketballStatsByTeam: {teamId}");
    }

    public async Task DeleteLeagueFootballStatsBySeasonCache(string leagueId, string seasonId)
    {
        await _cache.RemoveAsync($"LeagueFootballStatsBySeason: League: {leagueId}, Season: {seasonId}");
    }

    public async Task DeleteFootballStatsByPlayerCache(string playerId)
    {
        await _cache.RemoveAsync($"FootballStatsByPlayer: {playerId}");
    }

    public async Task DeleteFootballStatsByTeamCache(string teamId)
    {
        await _cache.RemoveAsync($"FootballStatsByTeam: {teamId}");
    }

    public async Task DeletePlayerBaseballStatsBySeasonCache(string playerId, string seasonId)
    {
        await _cache.RemoveAsync($"PlayerBaseballStatsBySeason: Player: {playerId} , Season: {seasonId}");
    }

    public async Task DeletePlayerBasketballStatsBySeasonCache(string playerId, string seasonId)
    {
        await _cache.RemoveAsync($"PlayerBasketballStatsBySeason: Player: {playerId} , Season: {seasonId}");
    }

    public async Task DeletePlayerFootballStatsBySeasonCache(string playerId, string seasonId)
    {
        await _cache.RemoveAsync($"PlayerFootballStatsBySeason: Player: {playerId} , Season: {seasonId}");
    }
}
