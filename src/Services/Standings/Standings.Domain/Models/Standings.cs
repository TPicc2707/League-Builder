namespace Standings.Domain.Models;

public class Standings : Entity<StandingsId>
{
    public LeagueId LeagueId { get; private set; } = default!;
    public TeamId TeamId { get; private set; } = default!;
    public SeasonId SeasonId { get; private set; } = default!;
    public StandingsDetail StandingsDetail { get; private set;} = default!;
    public StandingsStatus StandingsStatus { get; private set; } = default!;

    
    public static Standings Create(StandingsId id, LeagueId leagueId, TeamId teamId, SeasonId seasonId, StandingsDetail standingsDetail)
    {
        var standings = new Standings()
        {
            Id = id,
            LeagueId = leagueId,
            TeamId = teamId,
            SeasonId = seasonId,
            StandingsDetail = standingsDetail,
            StandingsStatus = StandingsStatus.NotStarted
        };

        return standings;
    }

    public void Update(LeagueId leagueId, TeamId teamId, SeasonId seasonId, StandingsDetail standingsDetail, StandingsStatus standingsStatus)
    {
        LeagueId = leagueId;
        TeamId = teamId;
        SeasonId = seasonId;
        StandingsDetail = standingsDetail;
        StandingsStatus = standingsStatus;
    }
}
