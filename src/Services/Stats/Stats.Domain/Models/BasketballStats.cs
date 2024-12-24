namespace Stats.Domain.Models;

public class BasketballStats : Entity<BasketballStatsId>
{
    public LeagueId LeagueId { get; private set; } = default!;
    public TeamId TeamId { get; private set; } = default!;
    public PlayerId PlayerId { get; private set; } = default!;
    public SeasonId SeasonId { get; private set; } = default!;
    public GameId GameId { get; private set; } = default!;
    public BasketballPlayerStats Stats { get; private set; } = default!;

    public static BasketballStats Create(BasketballStatsId id, LeagueId leagueId, TeamId teamId, PlayerId playerId, SeasonId seasonId, GameId gameId, BasketballPlayerStats stats)
    {
        var basketballStats = new BasketballStats()
        {
            Id = id,
            LeagueId = leagueId,
            TeamId = teamId,
            PlayerId = playerId,
            SeasonId = seasonId,
            GameId = gameId,
            Stats = stats,
        };

        return basketballStats;
    }

    public void Update(LeagueId leagueId, TeamId teamId, PlayerId playerId, SeasonId seasonId, GameId gameId, BasketballPlayerStats stats)
    {
        LeagueId = leagueId;
        TeamId = teamId;
        PlayerId = playerId;
        SeasonId = seasonId;
        GameId = gameId;
        Stats = stats;
    }
}
