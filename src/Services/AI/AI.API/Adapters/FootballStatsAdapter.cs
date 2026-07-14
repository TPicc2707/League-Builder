using AI.API.Models;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.Qdrant;

namespace AI.API.Adapters;

public class FootballStatsAdapter
{
    private readonly IEmbeddingGenerator<string, Embedding<float>> _embedding;
    private readonly QdrantCollection<Guid, FootballStats> _collection;

    public FootballStatsAdapter(IEmbeddingGenerator<string, Embedding<float>> embedding,
        QdrantCollection<Guid, FootballStats> collection)
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
        var searchOptions = new VectorSearchOptions<FootballStats>();
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

                "Passing\n" +
                $"Completions: {s.PassingCompletions}\n" +
                $"Attempts: {s.PassingAttempts}\n" +
                $"Yards: {s.PassingYards}\n" +
                $"Longest Play: {s.LongestPassingPlay}\n" +
                $"Touchdowns: {s.PassingTouchdowns}\n" +
                $"Interceptions: {s.PassingInterceptions}\n" +
                $"Sacks: {s.Sacks}\n" +

                "Rushing\n" +
                $"Attempts: {s.RushingAttempts}\n" +
                $"Yards: {s.RushingYards}\n" +
                $"Yards: {s.PassingYards}\n" +
                $"Longest Run: {s.LongestRushingPlay}\n" +
                $"Touchdowns: {s.RushingTouchdowns}\n" +
                $"Fumbles: {s.RushingFumbles}\n" +
                $"Fumbles Lost: {s.RushingFumblesLost}\n" +

                "Receiving\n" +
                $"Receptions: {s.Receptions}\n" +
                $"Targets: {s.Targets}\n" +
                $"Yards: {s.ReceivingYards}\n" +
                $"Touchdowns: {s.ReceivingTouchdowns}\n" +
                $"Fumbles: {s.ReceivingFumbles}\n" +
                $"Fumbles Lost: {s.ReceivingFumblesLost}\n" +
                $"Yards After Catch: {s.YardsAfterCatch}\n" +

                "Defense\n" +
                $"Tackles: {s.Tackles}\n" +
                $"Sacks: {s.DefensiveSacks}\n" +
                $"Tackles For Loss: {s.TacklesForLoss}\n" +
                $"Passes Defended: {s.PassesDefended}\n" +
                $"Interceptions: {s.DefensiveInterceptions}\n" +
                $"Interception Yards: {s.DefensiveInterceptionYards}\n" +
                $"Longest INT Play: {s.LongestDefensiveInterceptionPlay}\n" +
                $"Touchdowns: {s.DefensiveTouchdowns}\n" +
                $"Forced Fumbles: {s.ForcedFumbles}\n" +
                $"Recovered Fumbles: {s.RecoveredFumbles}\n" +

                "Kicking\n" +
                $"Field Goals: {s.FieldGoalsMade}/{s.FieldGoalsAttempted}\n" +
                $"Extra Points: {s.ExtraPointsMade}/{s.ExtraPointsAttempted}\n" +
                $"Longest Kick: {s.LongestKick}\n" +
                $"Points: {s.Points}\n" +

                "Punting\n" +
                $"Punts: {s.Punts}\n" +
                $"Yards: {s.PuntingYards}\n" +
                $"Longest Punt: {s.LongestPunt}\n"
                ;

            results.Add(new TextSearchProvider.TextSearchResult
            {
                SourceName = $"Stats: {s.FullName} ({s.SeasonYear})",
                SourceLink = $"stats://{s.Id}",
                Text = text
            });
        }

        return results;
    }

    public async Task IngestFootballStatAsync(FootballStats stats)
    {
        var embeddingText = $@"
            Football Stats
            League: {stats.LeagueName}
            Team: {stats.TeamName}
            Player: {stats.FullName}
            Season: {stats.SeasonYear}
            Game ID: {stats.GameId}

            Game Score
            Home Team: {stats.HomeTeamName} ({stats.HomeTeamScore})
            Away Team: {stats.AwayTeamName} ({stats.AwayTeamScore})

            Passing
            Completions: {stats.PassingCompletions}
            Attempts: {stats.PassingAttempts}
            Yards: {stats.PassingYards}
            Longest Play: {stats.LongestPassingPlay}
            Touchdowns: {stats.PassingTouchdowns}
            Interceptions: {stats.PassingInterceptions}
            Sacks: {stats.Sacks}

            Rushing
            Attempts: {stats.RushingAttempts}
            Yards: {stats.RushingYards}
            Longest Play: {stats.LongestRushingPlay}
            Touchdowns: {stats.RushingTouchdowns}
            Fumbles: {stats.RushingFumbles}
            Fumbles Lost: {stats.RushingFumblesLost}

            Receiving
            Receptions: {stats.Receptions}
            Targets: {stats.Targets}
            Yards: {stats.ReceivingYards}
            Touchdowns: {stats.ReceivingTouchdowns}
            Fumbles: {stats.ReceivingFumbles}
            Fumbles Lost: {stats.ReceivingFumblesLost}
            Yards After Catch: {stats.YardsAfterCatch}

            Defense
            Tackles: {stats.Tackles}
            Sacks: {stats.DefensiveSacks}
            Tackles For Loss: {stats.TacklesForLoss}
            Passes Defended: {stats.PassesDefended}
            Interceptions: {stats.DefensiveInterceptions}
            Interception Yards: {stats.DefensiveInterceptionYards}
            Longest INT Play: {stats.LongestDefensiveInterceptionPlay}
            Touchdowns: {stats.DefensiveTouchdowns}
            Forced Fumbles: {stats.ForcedFumbles}
            Recovered Fumbles: {stats.RecoveredFumbles}

            Kicking
            Field Goals: {stats.FieldGoalsMade}/{stats.FieldGoalsAttempted}
            Extra Points: {stats.ExtraPointsMade}/{stats.ExtraPointsAttempted}
            Longest Kick: {stats.LongestKick}
            Points: {stats.Points}

            Punting
            Punts: {stats.Punts}
            Yards: {stats.PuntingYards}
            Longest Punt: {stats.LongestPunt}
            ";

        var embedding = await _embedding.GenerateAsync(embeddingText);
        stats.Vector = embedding.Vector;

        await _collection.UpsertAsync(stats);
    }

    public async Task DeleteFootballStatAsync(Guid id) => await _collection.DeleteAsync(id);

    public async Task<FootballStats> MapFootballStatVector(FootballStatsDto stat, LeagueCache cache)
    {
        var league = cache.LeagueData.Leagues.FirstOrDefault(league => league.Id == stat.LeagueId);
        var season = cache.LeagueData.Seasons.FirstOrDefault(season => season.Id == stat.SeasonId);
        var game = cache.LeagueData.Games.FirstOrDefault(game => game.Id == stat.GameId);
        var team = cache.LeagueData.Teams.FirstOrDefault(team => team.Id == stat.TeamId);
        var player = cache.LeagueData.Players.FirstOrDefault(player => player.Id == stat.PlayerId);

        var vector = new FootballStats
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
            PassingCompletions = stat.OffensiveStats.PassingCompletions,
            PassingAttempts = stat.OffensiveStats.PassingAttempts,
            PassingYards = stat.OffensiveStats.PassingYards,
            LongestPassingPlay = stat.OffensiveStats.LongestPassingPlay,
            PassingTouchdowns = stat.OffensiveStats.PassingTouchdowns,
            PassingInterceptions = stat.OffensiveStats.PassingInterceptions,
            Sacks = stat.OffensiveStats.Sacks,
            RushingAttempts = stat.OffensiveStats.RushingAttempts,
            RushingYards = stat.OffensiveStats.RushingYards,
            LongestRushingPlay = stat.OffensiveStats.LongestRushingPlay,
            RushingTouchdowns = stat.OffensiveStats.RushingTouchdowns,
            RushingFumbles = stat.OffensiveStats.RushingFumbles,
            RushingFumblesLost = stat.OffensiveStats.RushingFumblesLost,
            Receptions = stat.OffensiveStats.Receptions,
            Targets = stat.OffensiveStats.Targets,
            ReceivingYards = stat.OffensiveStats.ReceivingYards,
            ReceivingTouchdowns = stat.OffensiveStats.ReceivingTouchdowns,
            ReceivingFumbles = stat.OffensiveStats.ReceivingFumbles,
            ReceivingFumblesLost = stat.OffensiveStats.ReceivingFumblesLost,
            YardsAfterCatch = stat.OffensiveStats.YardsAfterCatch,
            Tackles = stat.DefensiveStats.Tackles,
            DefensiveSacks = stat.DefensiveStats.Sacks,
            TacklesForLoss = stat.DefensiveStats.TacklesForLoss,
            PassesDefended = stat.DefensiveStats.PassesDefended,
            DefensiveInterceptions = stat.DefensiveStats.DefensiveInterceptions,
            DefensiveInterceptionYards = stat.DefensiveStats.DefensiveInterceptionYards,
            LongestDefensiveInterceptionPlay = stat.DefensiveStats.LongestDefensiveInterceptionPlay,
            DefensiveTouchdowns = stat.DefensiveStats.DefensiveTouchdowns,
            ForcedFumbles = stat.DefensiveStats.ForcedFumbles,
            RecoveredFumbles = stat.DefensiveStats.RecoveredFumbles,
            FieldGoalsMade = stat.KickingStats.FieldGoalsMade,
            FieldGoalsAttempted = stat.KickingStats.FieldGoalsAttempted,
            ExtraPointsMade = stat.KickingStats.ExtraPointsMade,
            ExtraPointsAttempted = stat.KickingStats.ExtraPointsAttempted,
            LongestKick = stat.KickingStats.LongestKick,
            Points = stat.KickingStats.Points,
            Punts = stat.KickingStats.Punts,
            PuntingYards = stat.KickingStats.PuntingYards,
            LongestPunt = stat.KickingStats.LongestPunt
        };

        return vector;
    }
}
