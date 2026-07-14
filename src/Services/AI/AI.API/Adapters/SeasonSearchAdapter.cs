using AI.API.Models;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.Qdrant;

namespace AI.API.Adapters;

public class SeasonSearchAdapter
{
    private readonly IEmbeddingGenerator<string, Embedding<float>> _embedding;
    private readonly QdrantCollection<Guid, Season> _collection;

    public SeasonSearchAdapter(IEmbeddingGenerator<string, Embedding<float>> embedding,
        QdrantCollection<Guid, Season> collection)
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
        var searchOptions = new VectorSearchOptions<Season>();
        var searchResults = _collection.SearchAsync(queryVector, 50, searchOptions, cancellationToken);

        var results = new List<TextSearchProvider.TextSearchResult>();

        await foreach (var result in searchResults)
        {
            var p = result.Record;

            var text =
                $"Season Year: {p.Year}\n" +
                $"Description: {p.Description}\n";

            results.Add(new TextSearchProvider.TextSearchResult
            {
                SourceName = $"Season: {p.Year}",
                SourceLink = $"season://{p.Id}",
                Text = text
            });
        }

        return results;
    }

    public async Task IngestSeasonAsync(Season season)
    {
        var embeddingText = $@"
            Season Year: {season.Year}
            Description: {season.Description}
            ";
        var embedding = await _embedding.GenerateAsync(embeddingText);
        season.Vector = embedding.Vector;
        await _collection.UpsertAsync(season);
    }

    public async Task DeleteSeasonAsync(Guid id) => await _collection.DeleteAsync(id);

    public async Task<Season> MapSeasonVector(SeasonDto season)
    {
        var vector = new Season
        {
            Id = season.Id,
            Year = season.Year,
            Description = season.Description
        };

        return vector;
    }
}
