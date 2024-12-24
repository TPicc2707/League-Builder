namespace Stats.Domain.Models;

public class BaseballStats : Entity<BaseballStatsId>
{
    public LeagueId LeagueId { get; private set; } = default!;
    public TeamId TeamId { get; private set; } = default!;
    public PlayerId PlayerId { get; private set; } = default!;
    public SeasonId SeasonId { get; private set; } = default!;
    public GameId GameId { get; private set; } = default!;
    public BaseballHittingStats HittingStats { get; private set; } = default!;
    public BaseballPitchingStats PitchingStats { get; private set; } = default!;

    public static BaseballStats Create(BaseballStatsId id, LeagueId leagueId, TeamId teamId, PlayerId playerId, SeasonId seasonId, GameId gameId, BaseballHittingStats hittingStats, BaseballPitchingStats pitchingStats)
    {
        var stats = new BaseballStats()
        {
            Id = id,
            LeagueId = leagueId,
            TeamId = teamId,
            PlayerId = playerId,
            SeasonId = seasonId,
            GameId = gameId,
            HittingStats = hittingStats,
            PitchingStats = pitchingStats
        };

        return stats;
    }

    public void Update(LeagueId leagueId, TeamId teamId, PlayerId playerId, SeasonId seasonId, GameId gameId, BaseballHittingStats hittingStats, BaseballPitchingStats pitchingStats)
    {
        LeagueId = leagueId;
        TeamId = teamId;
        PlayerId = playerId;
        SeasonId = seasonId;
        GameId = gameId;
        HittingStats = hittingStats;
        PitchingStats = pitchingStats;
    }
}
