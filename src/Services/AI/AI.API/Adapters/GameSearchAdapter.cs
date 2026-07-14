using AI.API.Models;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.Qdrant;

namespace AI.API.Adapters;

public class GameSearchAdapter
{
    private readonly IEmbeddingGenerator<string, Embedding<float>> _embedding;
    private readonly QdrantCollection<Guid, Game> _collection;

    public GameSearchAdapter(IEmbeddingGenerator<string, Embedding<float>> embedding,
        QdrantCollection<Guid, Game> collection)
    {
        _embedding = embedding;
        _collection = collection;
    }

    public async Task<IEnumerable<TextSearchProvider.TextSearchResult>> Search(
        string query,
        CancellationToken cancellationToken)
    {
        // Embed the user query
        var queryEmbedding = await _embedding.GenerateAsync(query, cancellationToken: cancellationToken);
        var queryVector = queryEmbedding.Vector;

        // Search Qdrant for similar leagues
        var searchOptions = new VectorSearchOptions<Game>();
        var searchResults = _collection.SearchAsync(queryVector, 50, searchOptions, cancellationToken);

        var results = new List<TextSearchProvider.TextSearchResult>();

        await foreach(var result in searchResults)
        {
            var g = result.Record;

            var text =
            $"League: {g.LeagueName} ({g.Sport})\n" +
            $"Season: {g.SeasonYear}\n" +
            $"Home Team: {g.HomeTeamName} — {g.HomeTeamScore} runs, {g.HomeTotalHits ?? 0} hits\n" +
            $"Away Team: {g.AwayTeamName} — {g.AwayTeamScore} runs, {g.AwayTotalHits ?? 0} hits\n" +
            $"Winning Team: {g.WinningTeamName}\n" +
            $"Game Status: {g.GameStatus}\n" +
            $"Start Time: {g.StartTime:yyyy-MM-dd HH:mm}\n" +
            $"End Time: {(g.EndTime.HasValue ? g.EndTime.Value.ToString("yyyy-MM-dd HH:mm") : "N/A")}\n" +
            $"Away Inning Runs: {(g.AwayInningRuns != null ? string.Join(", ", g.AwayInningRuns) : "N/A")}\n" +
            $"Home Inning Runs: {(g.HomeInningRuns != null ? string.Join(", ", g.HomeInningRuns) : "N/A")}\n";

            results.Add(new TextSearchProvider.TextSearchResult
            {
                SourceName = $"Game: {g.HomeTeamName} vs {g.AwayTeamName} ({g.SeasonYear})",
                SourceLink = $"game://{g.Id}",
                Text = text
            });
        }

        return results;
    }

    public async Task IngestGameAsync(Game game)
    {
        var embeddingText = $@"
            Game Summary
            League: {game.LeagueName}
            Sport: {game.Sport}
            Season: {game.SeasonYear}

            Home Team: {game.HomeTeamName} ({game.HomeTeamScore} runs, {game.HomeTotalHits ?? 0} hits)
            Away Team: {game.AwayTeamName} ({game.AwayTeamScore} runs, {game.AwayTotalHits ?? 0} hits)
            Winning Team: {game.WinningTeamName}

            Game Status: {game.GameStatus}

            Start Time: {game.StartTime:yyyy-MM-dd HH:mm}
            End Time: {(game.EndTime.HasValue ? game.EndTime.Value.ToString("yyyy-MM-dd HH:mm") : "N/A")}

            Away Inning Runs: {(game.AwayInningRuns != null ? string.Join(", ", game.AwayInningRuns) : "N/A")}
            Home Inning Runs: {(game.HomeInningRuns != null ? string.Join(", ", game.HomeInningRuns) : "N/A")}
            ";

        var embedding = await _embedding.GenerateAsync(embeddingText);
        game.Vector = embedding.Vector;

        await _collection.UpsertAsync(game);
    }

    public async Task DeleteGameAsync(Guid id) => await _collection.DeleteAsync(id);

    public async Task<Game> MapGameVector(GameDto game, LeagueCache cache)
    {
        var league = cache.LeagueData.Leagues.FirstOrDefault(league => league.Id == game.LeagueId);
        var season = cache.LeagueData.Seasons.FirstOrDefault(season => season.Id == game.SeasonId);

        var vector = new Game
        {
            Id = game.Id,
            LeagueId = game.LeagueId.ToString(),
            LeagueName = league?.Name ?? string.Empty,
            Sport = league?.Sport ?? string.Empty,
            SeasonId = game.SeasonId.ToString(),
            SeasonYear = season?.Year ?? 0,
            AwayTeamId = game.AwayTeam.Id.ToString(),
            AwayTeamName = game.AwayTeam.TeamName,
            HomeTeamId = game.HomeTeam.Id.ToString(),
            HomeTeamName = game.HomeTeam.TeamName,
            AwayTeamScore = game.GameDetail.AwayTeamScore,
            HomeTeamScore = game.GameDetail.HomeTeamScore,
            StartTime = game.GameDetail.StartTime,
            EndTime = game.GameDetail.EndTime,
            AwayInningRuns = game.GameDetail.AwayInningRuns,
            HomeInningRuns = game.GameDetail.HomeInningRuns,
            AwayTotalHits = game.GameDetail.AwayTotalHits,
            HomeTotalHits = game.GameDetail.HomeTotalHits
        };

        vector.GameStatus = game.GameStatus switch
        {
            GameStatus.NotStarted => "Not Started",
            GameStatus.InProgress => "In Progress",
            GameStatus.Completed => "Completed",
            GameStatus.Postponed => "Postponed",
            GameStatus.Delayed => "Delayed",
            _ => "Unknown"
        };

        if (game.WinningTeamId is not null)
        {
            vector.WinningTeamId = game.WinningTeamId.ToString();
            vector.WinningTeamName = game.WinningTeamId == game.AwayTeam.Id ? game.AwayTeam.TeamName : game.HomeTeam.TeamName;
        }

        return vector;
    }
}
