namespace Stats.Domain.Models;

public class FootballStats : Aggregate<FootballStatsId>
{
    public LeagueId LeagueId { get; private set; } = default!;
    public TeamId TeamId { get; private set; } = default!;
    public PlayerId PlayerId { get; private set; } = default!;
    public SeasonId SeasonId { get; private set; } = default!;
    public GameId GameId { get; private set; } = default!;
    public FootballOffensiveStats OffensiveStats { get; private set; } = default!;
    public FootballDefensiveStats DefensiveStats { get; private set; } = default!;
    public FootballKickingStats KickingStats { get; private set; } = default!;


    public static FootballStats Create(FootballStatsId id, LeagueId leagueId, TeamId teamId, PlayerId playerId, SeasonId seasonId,  GameId gameId, FootballOffensiveStats offensiveStats, FootballDefensiveStats defensiveStats, FootballKickingStats kickingStats)
    {
        var stats = new FootballStats()
        {
            Id = id,
            LeagueId = leagueId,
            TeamId = teamId,
            PlayerId = playerId,
            SeasonId = seasonId,
            GameId = gameId,
            OffensiveStats = offensiveStats,
            DefensiveStats = defensiveStats,
            KickingStats = kickingStats
        };

        return stats;
    }

    public void Update(LeagueId leagueId, TeamId teamId, PlayerId playerId, SeasonId seasonId, GameId gameId, FootballOffensiveStats offensiveStats, FootballDefensiveStats defensiveStats, FootballKickingStats kickingStats)
    {
        LeagueId = leagueId;
        TeamId = teamId;
        PlayerId = playerId;
        SeasonId = seasonId;
        GameId = gameId;
        OffensiveStats = offensiveStats;
        DefensiveStats = defensiveStats;
        KickingStats = kickingStats;
    }
}
