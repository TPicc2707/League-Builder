using AI.API.Models;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.Qdrant;

namespace AI.API.Adapters;

public class PlayerSearchAdapter
{
    private readonly IEmbeddingGenerator<string, Embedding<float>> _embedding;
    private readonly QdrantCollection<Guid, Player> _collection;

    public PlayerSearchAdapter(IEmbeddingGenerator<string, Embedding<float>> embedding,
        QdrantCollection<Guid, Player> collection)
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
        var searchOptions = new VectorSearchOptions<Player>();
        var searchResults = _collection.SearchAsync(queryVector, 50, searchOptions, cancellationToken);

        var results = new List<TextSearchProvider.TextSearchResult>();

        await foreach (var result in searchResults)
        {
            var p = result.Record;

            var text =
                $"Player: {p.FirstName} {p.LastName}\n" +
                $"Team: {p.TeamName}\n" +
                $"League: {p.LeagueName}\n" +
                $"Sport: {p.Sport}\n" +
                $"Position: {p.Position}\n" +
                $"Number: {p.Number}\n" +
                $"Birth Date: {p.BirthDate:yyyy-MM-dd}\n" +
                $"Height: {p.Height} inches\n" +
                $"Weight: {p.Weight} lbs\n" +
                $"Location: {p.City}, {p.State}, {p.Country} {p.ZipCode}\n" +
                $"Email: {p.EmailAddress}\n" +
                $"Phone: {p.PhoneNumber}\n" +
                $"Description: {p.Description}\n";

            results.Add(new TextSearchProvider.TextSearchResult
            {
                SourceName = $"Player: {p.FirstName} {p.LastName}",
                SourceLink = $"player://{p.Id}",
                Text = text
            });
        }

        return results;
    }

    public async Task IngestPlayerAsync(Player player)
    {
        var embeddingText = $@"
            Player: {player.FirstName} {player.LastName}
            Team: {player.TeamName}
            League: {player.LeagueName}
            Sport: {player.Sport}
            Position: {player.Position}
            Number: {player.Number}
            Birth Date: {player.BirthDate:yyyy-MM-dd}
            Height: {player.Height} inches
            Weight: {player.Weight} lbs
            Location: {player.City}, {player.State}, {player.Country} {player.ZipCode}
            Email: {player.EmailAddress}
            Phone: {player.PhoneNumber}
            Description: {player.Description}
            ";
        var embedding = await _embedding.GenerateAsync(embeddingText);
        player.Vector = embedding.Vector;
        await _collection.UpsertAsync(player);
    }

    public async Task DeletePlayerAsync(Guid id) => await _collection.DeleteAsync(id);

    public async Task<Player> MapPlayerVector(PlayerDto player, LeagueCache cache)
    {
        var league = cache.LeagueData.Leagues.FirstOrDefault(l => l.Id == cache.LeagueData.Teams.FirstOrDefault(t => t.Id == player.TeamId)?.LeagueId);
        var vector = new Player
        {
            Id = player.Id,
            TeamId = player.TeamId.ToString(),
            TeamName = cache.LeagueData.Teams.FirstOrDefault(t => t.Id == player.TeamId)?.TeamName ?? string.Empty,
            LeagueName = league?.Name ?? string.Empty,
            Sport = league?.Sport ?? string.Empty,
            FirstName = player.FirstName,
            LastName = player.LastName,
            State = player.PlayerAddress.State,
            City = player.PlayerAddress.City,
            Country = player.PlayerAddress.Country,
            ZipCode = player.PlayerAddress.ZipCode,
            EmailAddress = player.PlayerDetail.EmailAddress,
            PhoneNumber = player.PlayerDetail.PhoneNumber,
            BirthDate = player.PlayerDetail.BirthDate,
            Height = player.PlayerDetail.Height,
            Weight = player.PlayerDetail.Weight,
            Position = player.PlayerDetail.Position,
            Number = player.PlayerDetail.Number,
            Description = player.Description
        };

        return vector;
    }
}
