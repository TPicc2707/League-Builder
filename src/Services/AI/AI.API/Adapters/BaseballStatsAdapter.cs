using AI.API.Models;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.Qdrant;

namespace AI.API.Adapters;

public class BaseballStatsAdapter
{
    private readonly IEmbeddingGenerator<string, Embedding<float>> _embedding;
    private readonly QdrantCollection<Guid, BaseballStats> _collection;

    public BaseballStatsAdapter(IEmbeddingGenerator<string, Embedding<float>> embedding,
        QdrantCollection<Guid, BaseballStats> collection)
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
        var searchOptions = new VectorSearchOptions<BaseballStats>();
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

                "Batting Stats\n" +
                $"At Bats: {s.AtBats}\n" +
                $"Hits: {s.Hits}\n" +
                $"Runs: {s.Runs}\n" +
                $"Home Runs: {s.HomeRuns}\n" +
                $"RBIs: {s.RunsBattedIn}\n" +
                $"Doubles: {s.Doubles}\n" +
                $"Triples: {s.Triples}\n" +
                $"Stolen Bases: {s.StolenBases}\n" +
                $"Caught Stealing: {s.CaughtStealing}\n" +
                $"Strikeouts: {s.Strikeouts}\n" +
                $"Walks: {s.Walks}\n" +
                $"Hit By Pitch: {s.HitByPitch}\n" +
                $"Sacrifice Fly: {s.SacrificeFly}\n\n" +

                "Pitching Stats\n" +
                $"Wins: {s.Wins}\n" +
                $"Losses: {s.Losses}\n" +
                $"Runs Allowed: {s.PitchingRuns}\n" +
                $"Start: {s.Start}\n" +
                $"Saves: {s.Saves}\n" +
                $"Innings Pitched: {s.Innings}\n" +
                $"Hits Allowed: {s.HitsAllowed}\n" +
                $"Walks Allowed: {s.WalksAllowed}\n" +
                $"Strikeouts: {s.PitchingStrikeouts}\n";

            results.Add(new TextSearchProvider.TextSearchResult
            {
                SourceName = $"Stats: {s.FullName} ({s.SeasonYear})",
                SourceLink = $"stats://{s.Id}",
                Text = text
            });
        }

        return results;
    }

    public async Task IngestBaseballStatAsync(BaseballStats stats)
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

            Batting
            At Bats: {stats.AtBats}
            Hits: {stats.Hits}
            Total Bases: {stats.TotalBases}
            Runs: {stats.Runs}
            Doubles: {stats.Doubles}
            Triples: {stats.Triples}
            Home Runs: {stats.HomeRuns}
            RBIs: {stats.RunsBattedIn}
            Stolen Bases: {stats.StolenBases}
            Caught Stealing: {stats.CaughtStealing}
            Strikeouts: {stats.Strikeouts}
            Walks: {stats.Walks}
            Hit By Pitch: {stats.HitByPitch}
            Sacrifice Fly: {stats.SacrificeFly}

            Pitching
            Wins: {stats.Wins}
            Losses: {stats.Losses}
            Runs Allowed: {stats.PitchingRuns}
            Start: {stats.Start}
            Saves: {stats.Saves}
            Innings Pitched: {stats.Innings}
            Hits Allowed: {stats.HitsAllowed}
            Walks Allowed: {stats.WalksAllowed}
            Strikeouts: {stats.PitchingStrikeouts}
            ";

        var embedding = await _embedding.GenerateAsync(embeddingText);
        stats.Vector = embedding.Vector;

        await _collection.UpsertAsync(stats);
    }

    public async Task DeleteBaseballStatAsync(Guid id) => await _collection.DeleteAsync(id);

    public async Task<BaseballStats> MapBaseballStatVector(BaseballStatsDto stat, LeagueCache cache)
    {
        var league = cache.LeagueData.Leagues.FirstOrDefault(league => league.Id == stat.LeagueId);
        var season = cache.LeagueData.Seasons.FirstOrDefault(season => season.Id == stat.SeasonId);
        var game = cache.LeagueData.Games.FirstOrDefault(game => game.Id == stat.GameId);
        var team = cache.LeagueData.Teams.FirstOrDefault(team => team.Id == stat.TeamId);
        var player = cache.LeagueData.Players.FirstOrDefault(player => player.Id == stat.PlayerId);

        var vector = new BaseballStats
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
            AtBats = stat.HittingStats.AtBats,
            Hits = stat.HittingStats.Hits,
            TotalBases = stat.HittingStats.TotalBases,
            Runs = stat.HittingStats.Runs,
            Doubles = stat.HittingStats.Doubles,
            Triples = stat.HittingStats.Triples,
            HomeRuns = stat.HittingStats.HomeRuns,
            RunsBattedIn = stat.HittingStats.RunsBattedIn,
            StolenBases = stat.HittingStats.StolenBases,
            CaughtStealing = stat.HittingStats.CaughtStealing,
            Strikeouts = stat.HittingStats.Strikeouts,
            Walks = stat.HittingStats.Walks,
            HitByPitch = stat.HittingStats.HitByPitch,
            SacrificeFly = stat.HittingStats.SacrificeFly,
            Wins = stat.PitchingStats.Wins,
            Losses = stat.PitchingStats.Losses,
            PitchingRuns = stat.PitchingStats.Runs,
            Start = stat.PitchingStats.Start,
            Innings = (double)stat.PitchingStats.Innings,
            HitsAllowed = stat.PitchingStats.HitsAllowed,
            WalksAllowed = stat.PitchingStats.WalksAllowed,
            PitchingStrikeouts = stat.PitchingStats.PitchingStrikeouts
        };

        return vector;
    }
}
