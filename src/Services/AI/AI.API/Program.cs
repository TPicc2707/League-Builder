using AI.API.Adapters;
using AI.API.Models;
using AI.API.Services;
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Qdrant.Client;
using QdrantVectorStoreType = Microsoft.SemanticKernel.Connectors.Qdrant.QdrantVectorStore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddQdrantClient("qdrant");
builder.Services.AddControllers();

// 1. Define the variables we extracted from Microsoft Foundry
var endpoint = builder.Configuration["AzureOpenAI:Endpoint"] ?? throw new InvalidOperationException("AzureOpenAI:Endpoint is not set.");
var deploymentName = builder.Configuration["AzureOpenAI:DeploymentName"] ?? "gpt-5-mini";
var apiKey = builder.Configuration["AzureOpenAI:ApiKey"] ?? throw new InvalidOperationException("AzureOpenAI:ApiKey is not set.");

// 2. Instantiate the universal chat client with OpenTelemetry GenAI instrumentation
IChatClient chatClient = new AzureOpenAIClient(
    new Uri(endpoint),
    new AzureKeyCredential(apiKey))
    .GetChatClient(deploymentName)
    .AsIChatClient()
    .AsBuilder()
    .UseOpenTelemetry(configure: c => c.EnableSensitiveData = true)
    .Build();

builder.Services.AddSingleton(chatClient);
builder.Services.AddTransient<KeycloakAuthHandler>();
builder.Services.AddSingleton<KeycloakTokenService>();

// Register Microservices HttpClients
builder.Services.AddHttpClient("Keycloak", c =>
{
    c.BaseAddress = new Uri("http://localhost:8080"); // Aspire service name
});
builder.Services.AddHttpClient("LeagueApi", c => c.BaseAddress = new Uri("http://league-api/"))
    .AddHttpMessageHandler<KeycloakAuthHandler>();
builder.Services.AddHttpClient("TeamApi", c => c.BaseAddress = new Uri("http://team-api/"))
        .AddHttpMessageHandler<KeycloakAuthHandler>();
builder.Services.AddHttpClient("PlayerApi", c => c.BaseAddress = new Uri("http://player-api/"))
    .AddHttpMessageHandler<KeycloakAuthHandler>();
builder.Services.AddHttpClient("SeasonApi", c => c.BaseAddress = new Uri("http://season-api/"))
    .AddHttpMessageHandler<KeycloakAuthHandler>();
builder.Services.AddHttpClient("GameApi", c => c.BaseAddress = new Uri("http://game-api/"))
    .AddHttpMessageHandler<KeycloakAuthHandler>();
builder.Services.AddHttpClient("StandingsApi", c => c.BaseAddress = new Uri("http://standings-api/"))
    .AddHttpMessageHandler<KeycloakAuthHandler>();
builder.Services.AddHttpClient("StatsApi", c => c.BaseAddress = new Uri("http://stats-api/"))
    .AddHttpMessageHandler<KeycloakAuthHandler>();

//Register Tools
builder.Services.AddSingleton<LeagueCache>();
builder.Services.AddSingleton<LeagueDataTools>();
builder.Services.AddSingleton<LeagueSearchAdapter>();
builder.Services.AddSingleton<TeamSearchAdapter>();
builder.Services.AddSingleton<PlayerSearchAdapter>();
builder.Services.AddSingleton<SeasonSearchAdapter>();
builder.Services.AddSingleton<StandingsSearchAdapter>();
builder.Services.AddSingleton<GameSearchAdapter>();
builder.Services.AddSingleton<BaseballStatsAdapter>();
builder.Services.AddSingleton<BasketballStatsAdapter>();
builder.Services.AddSingleton<FootballStatsAdapter>();
builder.Services.AddSingleton<BrowserTools>();
builder.Services.AddSingleton(sp =>
{
    var client = sp.GetRequiredService<QdrantClient>();
    return new QdrantVectorStoreType(client, ownsClient: false);
});

builder.Services.AddSingleton(sp =>
{
    return new AzureOpenAIClient(new Uri(endpoint), new AzureKeyCredential(apiKey))
    .GetEmbeddingClient("text-embedding-3-small")
    .AsIEmbeddingGenerator();
});

builder.Services.AddSingleton(sp =>
{
    var store = sp.GetRequiredService<QdrantVectorStoreType>();
    return store.GetCollection<Guid, League>("league_adrs");

});
builder.Services.AddSingleton(sp =>
{
    var store = sp.GetRequiredService<QdrantVectorStoreType>();
    return store.GetCollection<Guid, Team>("team_adrs");

});
builder.Services.AddSingleton(sp =>
{
    var store = sp.GetRequiredService<QdrantVectorStoreType>();
    return store.GetCollection<Guid, Player>("player_adrs");

});
builder.Services.AddSingleton(sp =>
{
    var store = sp.GetRequiredService<QdrantVectorStoreType>();
    return store.GetCollection<Guid, Season>("season_adrs");

});
builder.Services.AddSingleton(sp =>
{
    var store = sp.GetRequiredService<QdrantVectorStoreType>();
    return store.GetCollection<Guid, Standings>("standings_adrs");

});
builder.Services.AddSingleton(sp =>
{
    var store = sp.GetRequiredService<QdrantVectorStoreType>();
    return store.GetCollection<Guid, Game>("game_adrs");

});
builder.Services.AddSingleton(sp =>
{
    var store = sp.GetRequiredService<QdrantVectorStoreType>();
    return store.GetCollection<Guid, BaseballStats>("baseball_stats_adrs");

});
builder.Services.AddSingleton(sp =>
{
    var store = sp.GetRequiredService<QdrantVectorStoreType>();
    return store.GetCollection<Guid, BasketballStats>("basketball_stats_adrs");

});
builder.Services.AddSingleton(sp =>
{
    var store = sp.GetRequiredService<QdrantVectorStoreType>();
    return store.GetCollection<Guid, FootballStats>("football_stats_adrs");

});
builder.Services.AddHostedService<QdrantInitializer>();
builder.Services.AddHostedService<AiApiInitializer>();

builder.Services.AddSingleton(sp =>
{
    TextSearchProviderOptions leagueTextSearchOptions = new()
    {
        SearchTime = TextSearchProviderOptions.TextSearchBehavior.BeforeAIInvoke,
        StateKey = "LeagueSearchStateKey"
    };

    TextSearchProviderOptions teamTextSearchOptions = new()
    {
        SearchTime = TextSearchProviderOptions.TextSearchBehavior.BeforeAIInvoke,
        StateKey = "TeamSearchStateKey"
    };

    TextSearchProviderOptions playerTextSearchOptions = new()
    {
        SearchTime = TextSearchProviderOptions.TextSearchBehavior.BeforeAIInvoke,
        StateKey = "PlayerSearchStateKey"
    };

    TextSearchProviderOptions seasonTextSearchOptions = new()
    {
        SearchTime = TextSearchProviderOptions.TextSearchBehavior.BeforeAIInvoke,
        StateKey = "SeasonSearchStateKey"
    };
    
    TextSearchProviderOptions standingsTextSearchOptions = new()
    {
        SearchTime = TextSearchProviderOptions.TextSearchBehavior.BeforeAIInvoke,
        StateKey = "StandingsSearchStateKey"
    };

    TextSearchProviderOptions gameTextSearchOptions = new()
    {
        SearchTime = TextSearchProviderOptions.TextSearchBehavior.BeforeAIInvoke,
        StateKey = "GameSearchStateKey"
    };

    TextSearchProviderOptions baseballStatsTextSearchOptions = new()
    {
        SearchTime = TextSearchProviderOptions.TextSearchBehavior.BeforeAIInvoke,
        StateKey = "BaseballStatsSearchStateKey"
    };

    TextSearchProviderOptions basketballStatsTextSearchOptions = new()
    {
        SearchTime = TextSearchProviderOptions.TextSearchBehavior.BeforeAIInvoke,
        StateKey = "BasketballStatsSearchStateKey"
    };

    TextSearchProviderOptions footballStatsTextSearchOptions = new()
    {
        SearchTime = TextSearchProviderOptions.TextSearchBehavior.BeforeAIInvoke,
        StateKey = "FootballStatsSearchStateKey"
    };

    var leagueSearch = sp.GetRequiredService<LeagueSearchAdapter>();
    var teamSearch = sp.GetRequiredService<TeamSearchAdapter>();
    var playerSearch = sp.GetRequiredService<PlayerSearchAdapter>();
    var seasonSearch = sp.GetRequiredService<SeasonSearchAdapter>();
    var standingsSearch = sp.GetRequiredService<StandingsSearchAdapter>();
    var gameSearch = sp.GetRequiredService<GameSearchAdapter>();
    var baseballStatsSearch = sp.GetRequiredService<BaseballStatsAdapter>();
    var basketballStatsSearch = sp.GetRequiredService<BasketballStatsAdapter>();
    var footballStatsSearch = sp.GetRequiredService<FootballStatsAdapter>();

    AIAgent leagueAgent = chatClient.AsAIAgent(new ChatClientAgentOptions()
    {
        Name = "LeagueAgent",
        ChatOptions = new()
        {
            Instructions = 
            """
                You are the League Builder AI Assistant. Your job is to answer questions using ONLY the context retrieved from the vector database (leagues, teams, players, stats). Follow these rules:

                1. **Ground every answer in retrieved context.**
                   - If league data is retrieved, reference it directly.
                   - If team or player data is retrieved, use it to support your answer.
                   - Never invent leagues, teams, players, or stats.

                2. **Prefer structured data over assumptions.**
                   - If metadata exists (LeagueId, TeamId, PlayerId), use it.
                   - If a field is missing, say so instead of guessing.

                3. **Combine multiple retrieved results intelligently.**
                   - If multiple teams or players are returned, summarize them clearly.
                   - If results conflict, state the conflict and choose the most relevant match.

                4. **Follow domain rules for leagues.**
                   - A league has a name, sport, description, owner, and season rules.
                   - A team belongs to exactly one league.
                   - A player belongs to exactly one team.
                   - Stats belong to a player, team, league, and season.

                5. **When asked for lists, return clean structured output.**
                   - Use bullet points or numbered lists.
                   - Keep responses readable and organized.

                6. **When asked for analysis, explain your reasoning using retrieved data.**
                   - Reference specific fields (TeamColor, Manager, TotalGamesPerSeason, etc.)
                   - Provide comparisons only when supported by retrieved context.

                7. **If no relevant context is retrieved, say:**
                   “No matching league/team/player data was found in the database.”

                8. **Never fabricate data.**
                   - Do not create fictional stats, players, or teams.
                   - Only use what the vector search returns.

                9. **Be concise, accurate, and helpful.**
                   - Avoid unnecessary filler.
                   - Focus on the user’s intent.

                10. **When the user asks about a league, team, or player:**
                    - Identify the entity from retrieved context.
                    - Provide a clear summary.
                    - Include important metadata (sport, manager, colors, etc.)
            """
        },
        AIContextProviders = [new TextSearchProvider(leagueSearch.Search,
                                                     leagueTextSearchOptions),
                              new TextSearchProvider(teamSearch.Search, teamTextSearchOptions),
                              new TextSearchProvider(playerSearch.Search, playerTextSearchOptions),
                              new TextSearchProvider(seasonSearch.Search, seasonTextSearchOptions),
                              new TextSearchProvider(standingsSearch.Search, standingsTextSearchOptions),
                              new TextSearchProvider(gameSearch.Search, gameTextSearchOptions),
                              new TextSearchProvider(baseballStatsSearch.Search, baseballStatsTextSearchOptions),
                              new TextSearchProvider(basketballStatsSearch.Search, basketballStatsTextSearchOptions),
                              new TextSearchProvider(footballStatsSearch.Search, footballStatsTextSearchOptions)]
    });

    return leagueAgent;
});
builder.Services.AddOpenAIResponses();
builder.Services.AddOpenAIConversations();

// Add services to the container.

var app = builder.Build();

//Register Agents

app.MapDefaultEndpoints();

app.MapControllers();
app.MapOpenAIResponses();
app.MapOpenAIConversations();

app.Run();

