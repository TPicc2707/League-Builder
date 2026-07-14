using AI.API.Models;
using Azure;

namespace AI.API.Services;

public class LeagueDataTools
{
    private readonly IHttpClientFactory _factory;
    private readonly LeagueCache _cache;
    private int pageIndex = 0;
    private int pageSize = 100000;

    public LeagueDataTools(IHttpClientFactory factory,
        LeagueCache cache)
    {
        _cache = cache;
        _factory = factory;
    }

    public LeagueDataResponse GetLeagueDataCache() => _cache.LeagueData;

    public async Task<LeagueDataResponse> GetLeagueData()
    {
        var leagueApi = _factory.CreateClient("LeagueApi");
        var teamApi = _factory.CreateClient("TeamApi");
        var playerApi = _factory.CreateClient("PlayerApi");
        var seasonApi = _factory.CreateClient("SeasonApi");
        var standingsApi = _factory.CreateClient("StandingsApi");
        var statsApi = _factory.CreateClient("StatsApi");
        var gamesApi = _factory.CreateClient("GameApi");

        var response = new LeagueDataResponse();

        // 1. Fetch Leagues safely
        response.Leagues = await GetLeagueApiData(leagueApi);

        // 2. Fetch Teams safely
        response.Teams = await GetTeamData(teamApi);

        // 3. Fetch Players safely
        response.Players = await GetPlayerData(playerApi);

        // 4. Fetch Seasons safely
        response.Seasons = await GetSeasonData(seasonApi);

        // 5. Fetch Standings safely
        response.Standings = await GetStandingsData(standingsApi);

        // 6. Fetch Games safely
        response.Games = await GetGamesData(gamesApi);

        // 7. Fetch Stats safely
        response.BaseballStats = await GetBaseballStatsData(statsApi);

        response.BasketballStats = await GetBasketballStatsData(statsApi);

        response.FootballStats = await GetFootballStatsData(statsApi);

        return response;
    }

    public async Task<IEnumerable<LeagueDto>> GetLeagueApiData(HttpClient client)
    {
        try
        {
            var leagues = await client.GetFromJsonAsync<GetLeaguesResponse>("leagues");
            return leagues?.Leagues;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] LeagueApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<LeagueDto> GetLeagueByIdData(HttpClient client, Guid id)
    {
        try
        {
            var league = await client.GetFromJsonAsync<GetLeagueByIdResponse>($"leagues/{id}");
            return league?.League;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] LeagueApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<IEnumerable<TeamDto>> GetTeamData(HttpClient client)
    {
        try
        {
            var teams = await client.GetFromJsonAsync<GetTeamsResponse>($"teams?pageIndex={pageIndex}&pageSize={pageSize}");
            return teams?.Teams.Data;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] TeamApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<TeamDto> GetTeamByIdData(HttpClient client, Guid id)
    {
        try
        {
            var team = await client.GetFromJsonAsync<GetTeamByIdResponse>($"teams/{id}");
            return team?.Team;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] TeamApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<IEnumerable<PlayerDto>> GetPlayerData(HttpClient client)
    {
        try
        {
            var players = await client.GetFromJsonAsync<GetPlayersResponse>($"players?pageIndex={pageIndex}&pageSize={pageSize}");
            return players?.Players.Data;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] PlayerApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<PlayerDto> GetPlayerByIdData(HttpClient client, Guid id)
    {
        try
        {
            var player = await client.GetFromJsonAsync<GetPlayerByIdResponse>($"players/{id}");
            return player?.Player;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] PlayerApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<IEnumerable<SeasonDto>> GetSeasonData(HttpClient client)
    {
        try
        {
            var seasons = await client.GetFromJsonAsync<GetSeasonsResponse>("seasons");
            return seasons?.Seasons;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] SeasonApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<SeasonDto> GetSeasonByIdData(HttpClient client, Guid id)
    {
        try
        {
            var season = await client.GetFromJsonAsync<GetSeasonByIdResponse>($"seasons/{id}");
            return season?.Season;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] SeasonApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<IEnumerable<StandingsDto>> GetStandingsData(HttpClient client)
    {
        try
        {
            var standings = await client.GetFromJsonAsync<GetStandingsResponse>($"standings?pageIndex={pageIndex}&pageSize={pageSize}");
            return standings?.Standings.Data;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] StandingsApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<StandingsDto> GetStandingsByIdData(HttpClient client, Guid id)
    {
        try
        {
            var standings = await client.GetFromJsonAsync<GetStandingsByIdResponse>($"standings/{id}");
            return standings?.Standings;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] SeasonApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<IEnumerable<GameDto>> GetGamesData(HttpClient client)
    {
        try
        {
            var games = await client.GetFromJsonAsync<GetGamesResponse>($"games?pageIndex={pageIndex}&pageSize={pageSize}");
            return games?.Games.Data;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] GameApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<GameDto> GetGameByIdData(HttpClient client, Guid id)
    {
        try
        {
            var game = await client.GetFromJsonAsync<GetGameByIdResponse>($"games/{id}");
            return game?.Game;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] GameApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<IEnumerable<BaseballStatsDto>> GetBaseballStatsData(HttpClient client)
    {
        try
        {
            var baseballStats = await client.GetFromJsonAsync<GetBaseballStatsResponse>($"baseballstats?pageIndex={pageIndex}&pageSize={pageSize}");
            return baseballStats?.BaseballStats.Data;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] StatsApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<BaseballStatsDto> GetBaseballStatByIdData(HttpClient client, Guid id)
    {
        try
        {
            var baseballStat = await client.GetFromJsonAsync<GetBaseballStatByIdResponse>($"baseballstats/{id}");
            return baseballStat?.BaseballStat;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] StatsApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<IEnumerable<BasketballStatsDto>> GetBasketballStatsData(HttpClient client)
    {
        try
        {
            var basketballStats = await client.GetFromJsonAsync<GetBasketballStatsResponse>($"basketballstats?pageIndex={pageIndex}&pageSize={pageSize}");
            return basketballStats?.BasketballStats.Data;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] StatsApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<BasketballStatsDto> GetBasketballStatByIdData(HttpClient client, Guid id)
    {
        try
        {
            var basketballStat = await client.GetFromJsonAsync<GetBasketballStatByIdResponse>($"basketballstats/{id}");
            return basketballStat?.BasketballStat;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] StatsApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<IEnumerable<FootballStatsDto>> GetFootballStatsData(HttpClient client)
    {
        try
        {
            var footballStats = await client.GetFromJsonAsync<GetFootballStatsResponse>($"footballstats?pageIndex={pageIndex}&pageSize={pageSize}");
            return footballStats?.FootballStats.Data;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] StatsApi failed: {ex.Message}"); }

        return null;
    }

    public async Task<FootballStatsDto> GetFootballStatByIdData(HttpClient client, Guid id)
    {
        try
        {
            var footballStat = await client.GetFromJsonAsync<GetFootballStatByIdResponse>($"footballstats/{id}");
            return footballStat?.FootballStat;
        }
        catch (Exception ex) { Console.WriteLine($"[Error] StatsApi failed: {ex.Message}"); }

        return null;
    }
}
