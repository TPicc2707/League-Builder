using AI.API.Adapters;
using AI.API.Models;
using AI.API.Services;
using Microsoft.Agents.AI;
using Microsoft.AspNetCore.Mvc;

namespace AI.API.Controllers;

[Route("ai")]
[ApiController]
public class AiController : ControllerBase
{
    private readonly IHttpClientFactory _factory;
    private readonly AIAgent _agent;
    private readonly LeagueSearchAdapter _leagueSearch;
    private readonly TeamSearchAdapter _teamSearch;
    private readonly PlayerSearchAdapter _playerSearch;
    private readonly SeasonSearchAdapter _seasonSearch;
    private readonly StandingsSearchAdapter _standingsSearch;
    private readonly GameSearchAdapter _gameSearch;
    private readonly BaseballStatsAdapter _baseballStatsSearch;
    private readonly BasketballStatsAdapter _basketballStatsSearch;
    private readonly FootballStatsAdapter _footballStatsSearch;
    private readonly LeagueCache _cache;
    private readonly LeagueDataTools _leagueTools;

    public AiController(IHttpClientFactory factory,
        AIAgent agent, 
        LeagueSearchAdapter leagueSearch,
        TeamSearchAdapter teamSearch,
        PlayerSearchAdapter playerSearch,
        SeasonSearchAdapter seasonSearch,
        StandingsSearchAdapter standingsSearch,
        GameSearchAdapter gameSearch,
        BaseballStatsAdapter baseballStatsSearch,
        BasketballStatsAdapter basketballStatsSearch,
        FootballStatsAdapter footballStatsSearch,
        LeagueCache cache,
        LeagueDataTools leagueTools)
    {
        _factory = factory;
        _agent = agent;
        _leagueSearch = leagueSearch; 
        _teamSearch = teamSearch;
        _playerSearch = playerSearch;
        _seasonSearch = seasonSearch;
        _standingsSearch = standingsSearch;
        _gameSearch = gameSearch;
        _baseballStatsSearch = baseballStatsSearch;
        _basketballStatsSearch = basketballStatsSearch;
        _footballStatsSearch = footballStatsSearch; 
        _cache = cache;
        _leagueTools = leagueTools;
    }

    [HttpPost("query")]
    public async Task<IActionResult> QueryLeagues([FromBody] AiQueryRequest request)
    {
        var response = await _agent.RunAsync(request.Question);
        return Ok(new { response = response.Text });
    }

    [HttpPost("leagues")]
    public async Task<IActionResult> AddLeague([FromBody] AiAddLeagueRequest request)
    {
        var leagueApi = _factory.CreateClient("LeagueApi");

        var leagues = _cache.LeagueData.Leagues.ToList();

        var league = await _leagueTools.GetLeagueByIdData(leagueApi, request.LeagueId);

        var leagueExist = leagues.Find(l => l.Id == league.Id);

        if (leagueExist is null)
            leagues.Add(league);
        else
        {
            leagues.Remove(leagueExist);
            leagues.Add(league);
        }

        _cache.LeagueData.Leagues = leagues;

        var vector = await _leagueSearch.MapLeagueVector(league);

        await _leagueSearch.IngestLeagueAsync(vector);

        return Ok();
    }

    [HttpPost("/deleteleagues")]
    public async Task<IActionResult> DeleteLeague([FromBody] AiDeleteLeagueRequest request)
    {
        await _leagueSearch.DeleteLeagueAsync(request.LeagueId);

        return Ok();
    }

    [HttpPost("teams")]
    public async Task<IActionResult> AddTeam([FromBody] AiAddTeamRequest request)
    {
        var teamApi = _factory.CreateClient("TeamApi");

        // Update Team List with new record
        var teams = _cache.LeagueData.Teams.ToList();


        var team = await _leagueTools.GetTeamByIdData(teamApi, request.TeamId);

        var teamExist = teams.Find(t => t.Id == team.Id);

        if(teamExist is null)
            teams.Add(team);
        else
        {
            teams.Remove(teamExist);
            teams.Add(team);
        }

        _cache.LeagueData.Teams = teams;

        var vector = await _teamSearch.MapTeamVector(team, _cache);

        await _teamSearch.IngestTeamAsync(vector);

        return Ok();
    }

    [HttpPost("/deleteteams")]
    public async Task<IActionResult> DeleteTeam([FromBody] AiDeleteTeamRequest request)
    {
        await _teamSearch.DeleteTeamAsync(request.TeamId);

        return Ok();
    }

    [HttpPost("players")]
    public async Task<IActionResult> AddPlayer([FromBody] AiAddPlayerRequest request)
    {
        var playerApi = _factory.CreateClient("PlayerApi");

        // Update Team List with new record
        var players = _cache.LeagueData.Players.ToList();


        var player = await _leagueTools.GetPlayerByIdData(playerApi, request.PlayerId);

        var playerExist = players.Find(t => t.Id == player.Id);

        if (playerExist is null)
            players.Add(player);
        else
        {
            players.Remove(playerExist);
            players.Add(player);
        }

        _cache.LeagueData.Players = players;

        var vector = await _playerSearch.MapPlayerVector(player, _cache);

        await _playerSearch.IngestPlayerAsync(vector);

        return Ok();
    }

    [HttpPost("/deleteplayers")]
    public async Task<IActionResult> DeletePlayer([FromBody] AiDeletePlayerRequest request)
    {
        await _playerSearch.DeletePlayerAsync(request.PlayerId);

        return Ok();
    }

    [HttpPost("seasons")]
    public async Task<IActionResult> AddSeason([FromBody] AiAddSeasonRequest request)
    {
        var seasonApi = _factory.CreateClient("SeasonApi");

        var seasons = _cache.LeagueData.Seasons.ToList();


        var season = await _leagueTools.GetSeasonByIdData(seasonApi, request.SeasonId);

        var seasonExist = seasons.Find(t => t.Id == season.Id);

        if (seasonExist is null)
            seasons.Add(season);
        else
        {
            seasons.Remove(seasonExist);
            seasons.Add(season);
        }

        _cache.LeagueData.Seasons = seasons;

        var vector = await _seasonSearch.MapSeasonVector(season);

        await _seasonSearch.IngestSeasonAsync(vector);

        return Ok();
    }

    [HttpPost("/deleteseasons")]
    public async Task<IActionResult> DeleteSeason([FromBody] AiDeleteSeasonRequest request)
    {
        await _seasonSearch.DeleteSeasonAsync(request.SeasonId);

        return Ok();
    }

    [HttpPost("standings")]
    public async Task<IActionResult> AddStandings([FromBody] AiAddStandingsRequest request)
    {
        var standingsApi = _factory.CreateClient("StandingsApi");

        var standings = _cache.LeagueData.Standings.ToList();


        var standing = await _leagueTools.GetStandingsByIdData(standingsApi, request.StandingsId);

        var standingExist = standings.Find(t => t.Id == standing.Id);

        if (standingExist is null)
            standings.Add(standing);
        else
        {
            standings.Remove(standingExist);
            standings.Add(standing);
        }

        _cache.LeagueData.Standings = standings;

        var vector = await _standingsSearch.MapStandingsVector(standing, _cache);

        await _standingsSearch.IngestStandingsAsync(vector);

        return Ok();
    }

    [HttpPost("/deletestandings")]
    public async Task<IActionResult> DeleteStandings([FromBody] AiDeleteStandingsRequest request)
    {
        await _standingsSearch.DeleteStandingAsync(request.StandingsId);

        return Ok();
    }

    [HttpPost("games")]
    public async Task<IActionResult> AddGame([FromBody] AiAddGameRequest request)
    {
        var gamesApi = _factory.CreateClient("GameApi");

        var games = _cache.LeagueData.Games.ToList();


        var game = await _leagueTools.GetGameByIdData(gamesApi, request.GameId);

        var gameExist = games.Find(t => t.Id == game.Id);

        if (gameExist is null)
            games.Add(game);
        else
        {
            games.Remove(gameExist);
            games.Add(game);
        }

        _cache.LeagueData.Games = games;

        var vector = await _gameSearch.MapGameVector(game, _cache);

        await _gameSearch.IngestGameAsync(vector);

        return Ok();
    }

    [HttpPost("/deletegames")]
    public async Task<IActionResult> DeleteGame([FromBody] AiDeleteGameRequest request)
    {
        await _gameSearch.DeleteGameAsync(request.GameId);

        return Ok();
    }

    [HttpPost("baseballstats")]
    public async Task<IActionResult> AddBaseballStat([FromBody] AiAddBaseballStatsRequest request)
    {
        var statsApi = _factory.CreateClient("StatsApi");

        var baseballStats = _cache.LeagueData.BaseballStats.ToList();


        var baseballStat = await _leagueTools.GetBaseballStatByIdData(statsApi, request.BaseballStatsId);

        var baseballStatExist = baseballStats.Find(t => t.Id == baseballStat.Id);

        if (baseballStatExist is null)
            baseballStats.Add(baseballStat);
        else
        {
            baseballStats.Remove(baseballStatExist);
            baseballStats.Add(baseballStat);
        }

        _cache.LeagueData.BaseballStats = baseballStats;

        var vector = await _baseballStatsSearch.MapBaseballStatVector(baseballStat, _cache);

        await _baseballStatsSearch.IngestBaseballStatAsync(vector);

        return Ok();
    }

    [HttpPost("/deletebaseballstats")]
    public async Task<IActionResult> DeleteBaseballStat([FromBody] AiDeleteBaseballStatsRequest request)
    {
        await _baseballStatsSearch.DeleteBaseballStatAsync(request.BaseballStatsId);

        return Ok();
    }

    [HttpPost("basketballstats")]
    public async Task<IActionResult> AddBasketballStat([FromBody] AiAddBasketballStatsRequest request)
    {
        var statsApi = _factory.CreateClient("StatsApi");

        var basketballStats = _cache.LeagueData.BasketballStats.ToList();


        var basketballStat = await _leagueTools.GetBasketballStatByIdData(statsApi, request.BasketballStatsId);

        var basketballStatExist = basketballStats.Find(t => t.Id == basketballStat.Id);

        if (basketballStatExist is null)
            basketballStats.Add(basketballStat);
        else
        {
            basketballStats.Remove(basketballStatExist);
            basketballStats.Add(basketballStat);
        }

        _cache.LeagueData.BasketballStats = basketballStats;

        var vector = await _basketballStatsSearch.MapBasketballStatVector(basketballStat, _cache);

        await _basketballStatsSearch.IngestBasketballStatAsync(vector);

        return Ok();
    }

    [HttpPost("/deletebasketballstats")]
    public async Task<IActionResult> DeleteBasketballStat([FromBody] AiDeleteBasketballStatsRequest request)
    {
        await _basketballStatsSearch.DeleteBasketballStatAsync(request.BasketballStatsId);

        return Ok();
    }

    [HttpPost("footballstats")]
    public async Task<IActionResult> AddFootballStat([FromBody] AiAddFootballStatsRequest request)
    {
        var statsApi = _factory.CreateClient("StatsApi");

        var footballStats = _cache.LeagueData.FootballStats.ToList();


        var footballStat = await _leagueTools.GetFootballStatByIdData(statsApi, request.FootballStatsId);

        var footballStatExist = footballStats.Find(t => t.Id == footballStat.Id);

        if (footballStatExist is null)
            footballStats.Add(footballStat);
        else
        {
            footballStats.Remove(footballStatExist);
            footballStats.Add(footballStat);
        }

        _cache.LeagueData.FootballStats = footballStats;

        var vector = await _footballStatsSearch.MapFootballStatVector(footballStat, _cache);

        await _footballStatsSearch.IngestFootballStatAsync(vector);

        return Ok();
    }

    [HttpPost("/deletefootballstats")]
    public async Task<IActionResult> DeleteFootballStat([FromBody] AiDeleteFootballStatsRequest request)
    {
        await _footballStatsSearch.DeleteFootballStatAsync(request.FootballStatsId);

        return Ok();
    }
}
