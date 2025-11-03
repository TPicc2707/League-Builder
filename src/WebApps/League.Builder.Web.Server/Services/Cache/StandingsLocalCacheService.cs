using Blazored.LocalStorage;

namespace League.Builder.Web.Server.Services.Cache;

public class StandingsLocalCacheService : IStandingsLocalCacheService
{
    private readonly ILocalStorageService _localStorage;

    public StandingsLocalCacheService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
    }

    public async Task<GetStandingsByLeagueResponse> GetStandingsByLeagueCache(string leagueId)
    {
        return await _localStorage.GetItemAsync<GetStandingsByLeagueResponse>($"StandingsByLeague: {leagueId}");
    }

    public async Task<GetStandingsByTeamResponse> GetStandingsByTeamCache(string teamId)
    {
        return await _localStorage.GetItemAsync<GetStandingsByTeamResponse>($"StandingsByTeam: {teamId}");
    }

    public async Task SetStandingsByLeagueCache(string leagueId, GetStandingsByLeagueResponse standingsByLeagueResponse)
    {
        await _localStorage.SetItemAsync($"StandingsByLeague: {leagueId}", standingsByLeagueResponse);
    }

    public async Task SetStandingsByTeamCache(string teamId, GetStandingsByTeamResponse standingsByTeamResponse)
    {
        await _localStorage.SetItemAsync($"StandingsByTeam: {teamId}", standingsByTeamResponse);
    }

    public async Task DeleteStandingsByLeagueCache(string leagueId)
    {
        await _localStorage.RemoveItemAsync($"StandingsByLeague: {leagueId}");
    }

    public async Task DeleteStandingsByTeamCache(string teamId)
    {
        await _localStorage.RemoveItemAsync($"StandingsByTeam: {teamId}");
    }
}
