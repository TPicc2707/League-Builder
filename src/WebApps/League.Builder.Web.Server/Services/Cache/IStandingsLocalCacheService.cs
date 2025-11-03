namespace League.Builder.Web.Server.Services.Cache;

public interface IStandingsLocalCacheService
{
    Task<GetStandingsByLeagueResponse> GetStandingsByLeagueCache(string leagueId);
    Task<GetStandingsByTeamResponse> GetStandingsByTeamCache(string teamId);
    Task SetStandingsByLeagueCache(string leagueId, GetStandingsByLeagueResponse standingsByLeagueResponse);
    Task SetStandingsByTeamCache(string teamId, GetStandingsByTeamResponse standingsByTeamResponse);
    Task DeleteStandingsByLeagueCache(string leagueId);
    Task DeleteStandingsByTeamCache(string teamId);
}
