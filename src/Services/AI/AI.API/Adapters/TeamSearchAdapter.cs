using AI.API.Models;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.Qdrant;

namespace AI.API.Adapters;

public class TeamSearchAdapter
{
    private readonly IEmbeddingGenerator<string, Embedding<float>> _embedding;
    private readonly QdrantCollection<Guid, Team> _collection;

    public TeamSearchAdapter(IEmbeddingGenerator<string, Embedding<float>> embedding,
        QdrantCollection<Guid, Team> collection)
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
        var searchOptions = new VectorSearchOptions<Team>();
        var searchResults = _collection.SearchAsync(queryVector, 20, searchOptions, cancellationToken);

        var results = new List<TextSearchProvider.TextSearchResult>();

        await foreach (var result in searchResults)
        {
            var team = result.Record;

            // Build a structured, readable response
            var text =
                $"**Team Information**\n" +
                $"• **Team:** {team.TeamName}\n" +
                $"• **League:** {team.LeagueName}\n" +
                $"• **Manager:** {team.ManagerFirstName} {team.ManagerLastName}\n" +
                $"• **Color:** {team.TeamColor}\n" +
                $"• **Location:** {team.City}, {team.State}, {team.Country} {team.ZipCode}\n\n" +
                $"**Description**\n" +
                $"{team.Description}\n";

            results.Add(new TextSearchProvider.TextSearchResult
            {
                SourceName = $"Team: {result.Record.TeamName}",
                SourceLink = $"team://{result.Record.Id}",
                Text = text
            });
        }

        return results;
    }

    public async Task IngestTeamAsync(Team team)
    {
        var embeddingText = $@"
            Team: {team.TeamName}
            League: {team.LeagueName}
            Description: {team.Description}
            Manager: {team.ManagerFirstName} {team.ManagerLastName}
            Address: {team.City}, {team.State}, {team.Country}, {team.ZipCode}
            ";
        var embedding = await _embedding.GenerateAsync(embeddingText);
        team.Vector = embedding.Vector;
        await _collection.UpsertAsync(team);
    }

    public async Task DeleteTeamAsync(Guid id) => await _collection.DeleteAsync(id);

    public async Task<Team> MapTeamVector(TeamDto team, LeagueCache cache)
    {
        var vector = new Team
        {
            Id = team.Id,
            LeagueId = team.LeagueId.ToString(),
            LeagueName = cache.LeagueData.Leagues.FirstOrDefault(l => l.Id == team.LeagueId)?.Name ?? string.Empty,
            TeamName = team.TeamName,
            Description = team.Description,
            TeamColor = team.TeamColor,
            ManagerFirstName = team.TeamManager.FirstName,
            ManagerLastName = team.TeamManager.LastName,
            ManagerEmailAddress = team.TeamManager.EmailAddress,
            City = team.TeamAddress.City,
            State = team.TeamAddress.State,
            Country = team.TeamAddress.Country,
            ZipCode = team.TeamAddress.ZipCode
        };

        return vector;
    }
}
