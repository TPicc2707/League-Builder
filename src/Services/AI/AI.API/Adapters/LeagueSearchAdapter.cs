using AI.API.Models;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.Qdrant;

namespace AI.API.Adapters;

public class LeagueSearchAdapter
{
    private readonly IEmbeddingGenerator<string, Embedding<float>> _embedding;
    private readonly QdrantCollection<Guid, League> _collection;

    public LeagueSearchAdapter(IEmbeddingGenerator<string, Embedding<float>> embedding,
        QdrantCollection<Guid, League> collection)
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
        var searchOptions = new VectorSearchOptions<League>();
        var searchResults = _collection.SearchAsync(queryVector, 20, searchOptions, cancellationToken);

        var results = new List<TextSearchProvider.TextSearchResult>();

        await foreach (var result in searchResults)
        {
            results.Add(new TextSearchProvider.TextSearchResult
            {
                SourceName = $"League: {result.Record.Name}",
                SourceLink = $"league://{result.Record.Id}",
                Text =
                    $"Name: {result.Record.Name}\n" +
                    $"Sport: {result.Record.Sport}\n" +
                    $"Description: {result.Record.Description}\n" +
                    $"Owner: {result.Record.OwnerFirstName} {result.Record.OwnerLastName}"
            });
        }

        return results;
    }

    public async Task IngestLeagueAsync(League league)
    {
        var embedding = await _embedding.GenerateAsync($"{league.Name} {league.Description}");
        league.Vector = embedding.Vector;
        await _collection.UpsertAsync(league);
    }

    public async Task DeleteLeagueAsync(Guid id) => await _collection.DeleteAsync(id);

    public async Task<League> MapLeagueVector(LeagueDto league)
    {
        var vector = new League
        {
            Id = league.Id,
            Name = league.Name,
            Sport = league.Sport,
            Description = league.Description,
            OwnerFirstName = league.OwnerFirstName,
            OwnerLastName = league.OwnerLastName,
            EmailAddress = league.EmailAddress,
            TotalGamesPerSeason = league.TotalGamesPerSeason,
            TotalPlayoffTeams = league.TotalPlayoffTeams,
            MinimumTotalTeamPlayers = league.MinimumTotalTeamPlayers,
            MaximumTotalTeamPlayers = league.MaximumTotalTeamPlayers
        };

        return vector;
    }
}
