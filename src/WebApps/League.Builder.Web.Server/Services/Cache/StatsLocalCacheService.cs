using Blazored.LocalStorage;

namespace League.Builder.Web.Server.Services.Cache;

public class StatsLocalCacheService : IStatsLocalCacheService
{
    private readonly ILocalStorageService _localStorage;

    public StatsLocalCacheService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
    }

    public async Task<GetLeagueBaseballStatsBySeasonResponse> GetLeagueBaseballStatsBySeasonCache(string leagueId, string seasonId)
    {
        return await _localStorage.GetItemAsync<GetLeagueBaseballStatsBySeasonResponse>($"LeagueBaseballStatsBySeason: League: {leagueId}, Season: {seasonId}");
    }

    public async Task<GetLeagueBasketballStatsBySeasonResponse> GetLeagueBasketballStatsBySeasonCache(string leagueId, string seasonId)
    {
        return await _localStorage.GetItemAsync<GetLeagueBasketballStatsBySeasonResponse>($"LeagueBasketballStatsBySeason: League: {leagueId}, Season: {seasonId}");
    }

    public async Task<GetLeagueFootballStatsBySeasonResponse> GetLeagueFootballStatsBySeasonCache(string leagueId, string seasonId)
    {
        return await _localStorage.GetItemAsync<GetLeagueFootballStatsBySeasonResponse>($"LeagueFootballStatsBySeason: League: {leagueId}, Season: {seasonId}");
    }

    public async Task<GetBaseballStatsByPlayerResponse> GetBaseballStatsByPlayerCache(string playerId)
    {
        return await _localStorage.GetItemAsync<GetBaseballStatsByPlayerResponse>($"BaseballStatsByPlayer: {playerId}");
    }

    public async Task<GetBaseballStatsByTeamResponse> GetBaseballStatsByTeamCache(string teamId)
    {
        return await _localStorage.GetItemAsync<GetBaseballStatsByTeamResponse>($"BaseballStatsByTeam: {teamId}");
    }

    public async Task<GetBasketballStatsByPlayerResponse> GetBasketballStatsByPlayerCache(string playerId)
    {
        return await _localStorage.GetItemAsync<GetBasketballStatsByPlayerResponse>($"BasketballStatsByPlayer: {playerId}");
    }

    public async Task<GetBasketballStatsByTeamResponse> GetBasketballStatsByTeamCache(string teamId)
    {
        return await _localStorage.GetItemAsync<GetBasketballStatsByTeamResponse>($"BasketballStatsByTeam: {teamId}");
    }

    public async Task<GetFootballStatsByTeamResponse> GetFootballStatsByTeamCache(string teamId)
    {
        return await _localStorage.GetItemAsync<GetFootballStatsByTeamResponse>($"FootballStatsByTeam: {teamId}");
    }

    public async Task<GetPlayerBaseballStatsBySeasonResponse> GetPlayerBaseballStatsBySeasonCache(string playerId, string seasonId)
    {
        return await _localStorage.GetItemAsync<GetPlayerBaseballStatsBySeasonResponse>($"PlayerBaseballStatsBySeason: Player: {playerId} , Season: {seasonId}");
    }

    public async Task<GetPlayerBasketballStatsBySeasonResponse> GetPlayerBasketballStatsBySeasonCache(string playerId, string seasonId)
    {
        return await _localStorage.GetItemAsync<GetPlayerBasketballStatsBySeasonResponse>($"PlayerBasketballStatsBySeason: Player: {playerId} , Season: {seasonId}");
    }

    public async Task<GetPlayerFootballStatsBySeasonResponse> GetPlayerFootballStatsBySeasonCache(string playerId, string seasonId)
    {
        return await _localStorage.GetItemAsync<GetPlayerFootballStatsBySeasonResponse>($"PlayerFootballStatsBySeason: Player: {playerId} , Season: {seasonId}");
    }

    public async Task SetLeagueBaseballStatsBySeasonCache(string leagueId, string seasonId, GetLeagueBaseballStatsBySeasonResponse leagueBaseballStatsBySeasonResponse)
    {
        await _localStorage.SetItemAsync($"LeagueBaseballStatsBySeason: League: {leagueId}, Season: {seasonId}", leagueBaseballStatsBySeasonResponse);
    }

    public async Task SetLeagueBasketballStatsBySeasonCache(string leagueId, string seasonId, GetLeagueBasketballStatsBySeasonResponse leagueBasketballStatsBySeasonResponse)
    {
        await _localStorage.SetItemAsync($"LeagueBasketballStatsBySeason: League: {leagueId}, Season: {seasonId}", leagueBasketballStatsBySeasonResponse);
    }

    public async Task SetLeagueFootballStatsBySeasonCache(string leagueId, string seasonId, GetLeagueFootballStatsBySeasonResponse leagueFootballStatsBySeasonResponse)
    {
        await _localStorage.SetItemAsync($"LeagueFootballStatsBySeason: League: {leagueId}, Season: {seasonId}", leagueFootballStatsBySeasonResponse);
    }

    public async Task SetBaseballStatsByPlayerCache(string playerId, GetBaseballStatsByPlayerResponse baseballStatsByPlayerResponse)
    {
        await _localStorage.SetItemAsync($"BaseballStatsByPlayer: {playerId}", baseballStatsByPlayerResponse);
    }

    public async Task SetBaseballStatsByTeamCache(string teamId, GetBaseballStatsByTeamResponse baseballStatsByTeamResponse)
    {
        await _localStorage.SetItemAsync($"BaseballStatsByTeam: {teamId}", baseballStatsByTeamResponse);
    }

    public async Task SetBasketballStatsByPlayerCache(string playerId, GetBasketballStatsByPlayerResponse basketballStatsByPlayerResponse)
    {
        await _localStorage.SetItemAsync($"BasketballStatsByPlayer: {playerId}", basketballStatsByPlayerResponse);
    }

    public async Task SetBasketballStatsByTeamCache(string teamId, GetBasketballStatsByTeamResponse basketballStatsByTeamResponse)
    {
        await _localStorage.SetItemAsync($"BasketballStatsByTeam: {teamId}", basketballStatsByTeamResponse);
    }

    public async Task SetFootballStatsByTeamCache(string teamId, GetFootballStatsByTeamResponse footballStatsByTeamResponse)
    {
        await _localStorage.SetItemAsync($"FootballStatsByTeam: {teamId}", footballStatsByTeamResponse);
    }

    public async Task SetPlayerBaseballStatsBySeasonCache(string playerId, string seasonId, GetPlayerBaseballStatsBySeasonResponse playerBaseballStatsBySeasonResponse)
    {
        await _localStorage.SetItemAsync($"PlayerBaseballStatsBySeason: Player: {playerId} , Season: {seasonId}", playerBaseballStatsBySeasonResponse);
    }

    public async Task SetPlayerBasketballStatsBySeasonCache(string playerId, string seasonId, GetPlayerBasketballStatsBySeasonResponse playerBasketballStatsBySeasonResponse)
    {
        await _localStorage.SetItemAsync($"PlayerBasketballStatsBySeason: Player: {playerId} , Season: {seasonId}", playerBasketballStatsBySeasonResponse);
    }

    public async Task SetPlayerFootballStatsBySeasonCache(string playerId, string seasonId, GetPlayerFootballStatsBySeasonResponse playerFootballStatsBySeasonResponse)
    {
        await _localStorage.SetItemAsync($"PlayerFootballStatsBySeason: Player: {playerId} , Season: {seasonId}", playerFootballStatsBySeasonResponse);
    }

    public async Task DeleteLeagueBaseballStatsBySeasonCache(string leagueId, string seasonId)
    {
        await _localStorage.RemoveItemAsync($"LeagueBaseballStatsBySeason: League: {leagueId}, Season: {seasonId}");
    }

    public async Task DeleteBaseballStatsByPlayerCache(string playerId)
    {
        await _localStorage.RemoveItemAsync($"BaseballStatsByPlayer: {playerId}");
    }

    public async Task DeleteBaseballStatsByTeamCache(string teamId)
    {
        await _localStorage.RemoveItemAsync($"BaseballStatsByTeam: {teamId}");
    }

    public async Task DeleteLeagueBasketballStatsBySeasonCache(string leagueId, string seasonId)
    {
        await _localStorage.RemoveItemAsync($"LeagueBasketballStatsBySeason: League: {leagueId}, Season: {seasonId}");
    }

    public async Task DeleteBasketballStatsByPlayerCache(string playerId)
    {
        await _localStorage.RemoveItemAsync($"BasketballStatsByPlayer: {playerId}");
    }

    public async Task DeleteBasketballStatsByTeamCache(string teamId)
    {
        await _localStorage.RemoveItemAsync($"BasketballStatsByTeam: {teamId}");
    }

    public async Task DeleteLeagueFootballStatsBySeasonCache(string leagueId, string seasonId)
    {
        await _localStorage.RemoveItemAsync($"LeagueFootballStatsBySeason: League: {leagueId}, Season: {seasonId}");
    }

    public async Task DeleteFootballStatsByPlayerCache(string playerId)
    {
        await _localStorage.RemoveItemAsync($"FootballStatsByPlayer: {playerId}");
    }

    public async Task DeleteFootballStatsByTeamCache(string teamId)
    {
        await _localStorage.RemoveItemAsync($"FootballStatsByTeam: {teamId}");
    }

    public async Task DeletePlayerBaseballStatsBySeasonCache(string playerId, string seasonId)
    {
        await _localStorage.RemoveItemAsync($"PlayerBaseballStatsBySeason: Player: {playerId} , Season: {seasonId}");
    }

    public async Task DeletePlayerBasketballStatsBySeasonCache(string playerId, string seasonId)
    {
        await _localStorage.RemoveItemAsync($"PlayerBasketballStatsBySeason: Player: {playerId} , Season: {seasonId}");
    }

    public async Task DeletePlayerFootballStatsBySeasonCache(string playerId, string seasonId)
    {
        await _localStorage.RemoveItemAsync($"PlayerFootballStatsBySeason: Player: {playerId} , Season: {seasonId}");
    }
}
