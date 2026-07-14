using AI.API.Models;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.Qdrant;

namespace AI.API.Adapters;

public class BasketballStatsAdapter
{
    private readonly IEmbeddingGenerator<string, Embedding<float>> _embedding;
    private readonly QdrantCollection<Guid, BasketballStats> _collection;

    public BasketballStatsAdapter(IEmbeddingGenerator<string, Embedding<float>> embedding,
        QdrantCollection<Guid, BasketballStats> collection)
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

        // Semantic search
        var searchOptions = new VectorSearchOptions<BasketballStats>();
        var searchResults = _collection.SearchAsync(queryVector, 50, searchOptions, cancellationToken);

        var results = new List<TextSearchProvider.TextSearchResult>();

        await foreach (var result in searchResults)
        {
            var s = result.Record;

            var text =
                $"Player: {s.FullName}\n" +
                $"Team: {s.TeamName}\n" +
                $"League: {s.LeagueName}\n" +
                $"Season: {s.SeasonYear}\n" +
                $"Game ID: {s.GameId}\n" +

                $"Game Score:\n" +
                $"Home Team: {s.HomeTeamName} ({s.HomeTeamScore})\n" +
                $"Away Team: {s.AwayTeamName} ({s.AwayTeamScore})\n" +

                "Performance\n" +
                $"Start: {s.Start}\n" +
                $"Minutes: {s.Minutes}\n" +
                $"Points: {s.Points}\n" +
                $"Field Goals: {s.FieldGoalsMade}/{s.FieldGoalsAttempted}\n" +
                $"Three Pointers: {s.ThreePointersMade}/{s.ThreePointersAttempted}\n" +
                $"Free Throws: {s.FreeThrowsMade}/{s.FreeThrowsAttempted}\n" +
                $"Rebounds: {s.Rebounds}\n" +
                $"Assists: {s.Assists}\n" +
                $"Steals: {s.Steals}\n" +
                $"Blocks: {s.Blocks}\n" +
                $"Turnovers: {s.Turnovers}\n" +
                $"Fouls: {s.Fouls}\n";


            results.Add(new TextSearchProvider.TextSearchResult
            {
                SourceName = $"Stats: {s.FullName} ({s.SeasonYear})",
                SourceLink = $"stats://{s.Id}",
                Text = text
            });
        }

        return results;
    }

    public async Task IngestBasketballStatAsync(BasketballStats stats)
    {
        var embeddingText = $@"
            Baseball Stats
            League: {stats.LeagueName}
            Team: {stats.TeamName}
            Player: {stats.FullName}
            Season: {stats.SeasonYear}
            Game ID: {stats.GameId}

            Game Score
            Home Team: {stats.HomeTeamName} ({stats.HomeTeamScore})
            Away Team: {stats.AwayTeamName} ({stats.AwayTeamScore})

            Performance
            Start: {stats.Start}
            Minutes: {stats.Minutes}
            Points: {stats.Points}
            Field Goals: {stats.FieldGoalsMade}/{stats.FieldGoalsAttempted}
            Three Pointers: {stats.ThreePointersMade}/{stats.ThreePointersAttempted}
            Free Throws: {stats.FreeThrowsMade}/{stats.FreeThrowsAttempted}
            Rebounds: {stats.Rebounds}
            Assists: {stats.Assists}
            Steals: {stats.Steals}
            Blocks: {stats.Blocks}
            Turnovers: {stats.Turnovers}
            Fouls: {stats.Fouls}
            ";

        var embedding = await _embedding.GenerateAsync(embeddingText);
        stats.Vector = embedding.Vector;

        await _collection.UpsertAsync(stats);
    }

    public async Task DeleteBasketballStatAsync(Guid id) => await _collection.DeleteAsync(id);

    public async Task<BasketballStats> MapBasketballStatVector(BasketballStatsDto stat, LeagueCache cache)
    {
        var league = cache.LeagueData.Leagues.FirstOrDefault(league => league.Id == stat.LeagueId);
        var season = cache.LeagueData.Seasons.FirstOrDefault(season => season.Id == stat.SeasonId);
        var game = cache.LeagueData.Games.FirstOrDefault(game => game.Id == stat.GameId);
        var team = cache.LeagueData.Teams.FirstOrDefault(team => team.Id == stat.TeamId);
        var player = cache.LeagueData.Players.FirstOrDefault(player => player.Id == stat.PlayerId);

        var vector = new BasketballStats
        {
            Id = stat.Id,
            LeagueId = stat.LeagueId.ToString(),
            LeagueName = league?.Name ?? string.Empty,
            TeamId = stat.TeamId.ToString(),
            TeamName = team?.TeamName ?? string.Empty,
            PlayerId = stat.PlayerId.ToString(),
            FullName = $"{player?.FirstName} {player?.LastName}",
            SeasonId = stat.SeasonId.ToString(),
            SeasonYear = season?.Year ?? 0,
            GameId = stat.GameId.ToString(),
            AwayTeamId = game?.AwayTeam.Id.ToString(),
            AwayTeamName = game?.AwayTeam.TeamName ?? string.Empty,
            HomeTeamId = game?.HomeTeam.Id.ToString(),
            HomeTeamName = game?.HomeTeam.TeamName ?? string.Empty,
            AwayTeamScore = game?.GameDetail.AwayTeamScore ?? 0,
            HomeTeamScore = game?.GameDetail.HomeTeamScore ?? 0,
            Start = stat.Stats.Start,
            Minutes = stat.Stats.Minutes,
            Points = stat.Stats.Points,
            FieldGoalsMade = stat.Stats.FieldGoalsMade,
            FieldGoalsAttempted = stat.Stats.FieldGoalsAttempted,
            ThreePointersMade = stat.Stats.ThreePointersMade,
            ThreePointersAttempted = stat.Stats.ThreePointersAttempted,
            FreeThrowsMade = stat.Stats.FreeThrowsMade,
            FreeThrowsAttempted = stat.Stats.FreeThrowsAttempted,
            Rebounds = stat.Stats.Rebounds,
            Assists = stat.Stats.Assists,
            Steals = stat.Stats.Steals,
            Blocks = stat.Stats.Blocks,
            Turnovers = stat.Stats.Turnovers,
            Fouls = stat.Stats.Fouls
        };

        return vector;
    }
}
