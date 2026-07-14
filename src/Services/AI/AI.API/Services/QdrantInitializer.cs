using AI.API.Models;
using Microsoft.SemanticKernel.Connectors.Qdrant;

namespace AI.API.Services;

public class QdrantInitializer : IHostedService
{
    private readonly QdrantCollection<Guid, League> _league;
    private readonly QdrantCollection<Guid, Team> _team;
    private readonly QdrantCollection<Guid, Player> _player;
    private readonly QdrantCollection<Guid, Season> _season;
    private readonly QdrantCollection<Guid, Standings> _standings;
    private readonly QdrantCollection<Guid, Game> _games;
    private readonly QdrantCollection<Guid, BaseballStats> _baseballStats;
    private readonly QdrantCollection<Guid, BasketballStats> _basketballStats;
    private readonly QdrantCollection<Guid, FootballStats> _footballStats;

    public QdrantInitializer(
        QdrantCollection<Guid, League> league,
        QdrantCollection<Guid, Team> team,
        QdrantCollection<Guid, Player> player,
        QdrantCollection<Guid, Season> season,
        QdrantCollection<Guid, Standings> standings,
        QdrantCollection<Guid, Game> games,
        QdrantCollection<Guid, BaseballStats> baseballStats,
        QdrantCollection<Guid, BasketballStats> basketballStats,
        QdrantCollection<Guid, FootballStats> footballStats
        )
    {
        _league = league;
        _team = team;
        _player = player;
        _season = season;
        _standings = standings;
        _games = games;
        _baseballStats = baseballStats;
        _basketballStats = basketballStats;
        _footballStats = footballStats;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _league.EnsureCollectionExistsAsync(cancellationToken);
        await _team.EnsureCollectionExistsAsync(cancellationToken);
        await _player.EnsureCollectionExistsAsync(cancellationToken);
        await _season.EnsureCollectionExistsAsync(cancellationToken);
        await _standings.EnsureCollectionExistsAsync(cancellationToken);
        await _games.EnsureCollectionExistsAsync(cancellationToken);
        await _baseballStats.EnsureCollectionExistsAsync(cancellationToken);
        await _basketballStats.EnsureCollectionExistsAsync(cancellationToken);
        await _footballStats.EnsureCollectionExistsAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
