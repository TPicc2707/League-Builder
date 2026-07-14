using AI.API.Models;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.Qdrant;

namespace AI.API.Adapters;

public class StandingsSearchAdapter
{
    private readonly IEmbeddingGenerator<string, Embedding<float>> _embedding;
    private readonly QdrantCollection<Guid, Standings> _collection;

    public StandingsSearchAdapter(IEmbeddingGenerator<string, Embedding<float>> embedding,
        QdrantCollection<Guid, Standings> collection)
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
        var searchOptions = new VectorSearchOptions<Standings>();
        var searchResults = _collection.SearchAsync(queryVector, 50, searchOptions, cancellationToken);

        var results = new List<TextSearchProvider.TextSearchResult>();

        await foreach (var result in searchResults)
        {
            var s = result.Record;

            var text =
                $"Team: {s.TeamName}\n" +
                $"League: {s.LeagueName}\n" +
                $"Sport: {s.Sport}\n" +
                $"Season: {s.SeasonYear}\n" +
                $"Manager: {s.ManagerFirstName} {s.ManagerLastName}\n" +
                $"Location: {s.City}, {s.State}, {s.Country} {s.ZipCode}\n" +
                $"Games Played: {s.GamesPlayed}\n" +
                $"Wins: {s.Wins}\n" +
                $"Losses: {s.Losses}\n" +
                $"Ties: {s.Ties}\n" +
                $"Playoff Team: {s.PlayoffTeam}\n" +
                $"Champion: {s.Champion}\n";

            results.Add(new TextSearchProvider.TextSearchResult
            {
                SourceName = $"Standings: {s.TeamName} ({s.SeasonYear})",
                SourceLink = $"standings://{result.Record.Id}",
                Text = text
            });
        }

        return results;
    }

    public async Task IngestStandingsAsync(Standings standing)
    {
        var embeddingText = $@"
            Standings Record
            League: {standing.LeagueName}
            Sport: {standing.Sport}

            Season: {standing.SeasonYear}
            Team: {standing.TeamName}
            Manager: {standing.ManagerFirstName} {standing.ManagerLastName}

            Location: {standing.City}, {standing.State}, {standing.Country} {standing.ZipCode}

            Games Played: {standing.GamesPlayed}
            Wins: {standing.Wins}
            Losses: {standing.Losses}
            Ties: {standing.Ties}

            Playoff Team: {standing.PlayoffTeam}
            Champion: {standing.Champion}
            ";

        var embedding = await _embedding.GenerateAsync(embeddingText);
        standing.Vector = embedding.Vector;
        await _collection.UpsertAsync(standing);

    }

    public async Task DeleteStandingAsync(Guid id) => await _collection.DeleteAsync(id);

    public async Task<Standings> MapStandingsVector(StandingsDto standing, LeagueCache cache)
    {
        var league = cache.LeagueData.Leagues.FirstOrDefault(league => league.Id == standing.LeagueId);
        var team = cache.LeagueData.Teams.FirstOrDefault(team => team.Id == standing.Team.Id);
        var season = cache.LeagueData.Seasons.FirstOrDefault(season => season.Id == standing.SeasonId);

        var vector = new Standings
        {
            Id = standing.Id,
            LeagueId = standing.LeagueId.ToString(),
            LeagueName = league?.Name ?? string.Empty,
            Sport = league?.Sport ?? string.Empty,
            SeasonId = standing.SeasonId.ToString(),
            SeasonYear = season?.Year ?? 0,
            TeamId = standing.Team.Id.ToString(),
            TeamName = standing.Team.TeamName,
            ManagerFirstName = team?.TeamManager.FirstName ?? string.Empty,
            ManagerLastName = team?.TeamManager.LastName ?? string.Empty,
            State = team?.TeamAddress.State ?? string.Empty,
            City = team?.TeamAddress.City ?? string.Empty,
            Country = team?.TeamAddress.Country ?? string.Empty,
            ZipCode = team?.TeamAddress.ZipCode ?? string.Empty,
            GamesPlayed = standing.StandingsDetail.GamesPlayed,
            Wins = standing.StandingsDetail.Wins,
            Losses = standing.StandingsDetail.Losses,
            Ties = standing.StandingsDetail.Ties,
            PlayoffTeam = standing.StandingsDetail.PlayoffTeam,
            Champion = standing.StandingsDetail.Champion
        };

        return vector;
    }
}
