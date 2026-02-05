namespace League.Builder.Web.Server.Models.Stats.Baseball;

public class BaseballGameStatsModel
{
    public BaseballGameStatsModel()
    {

    }

    public BaseballGameStatsModel(Guid leagueId, Guid teamId, Guid playerId, Guid seasonId, Guid gameId, string firstName, string lastName, string position)
    {
        LeagueId = leagueId;
        TeamId = teamId;
        PlayerId = playerId;
        SeasonId = seasonId;
        GameId = gameId;
        PlayerName = $"{firstName} {lastName}";
        Position = position;
    }

    public BaseballGameStatsModel(Guid leagueId, Guid teamId, Guid playerId, Guid seasonId, Guid gameId, string firstName, string lastName, string position,
                                   int atBats, int hits, int totalBases, int runs, int doubles, int triples, int homeRuns, int runsBattedIn,
                                    int stolenBases, int strikeouts, int walks, int hitByPitch, int sacrificeFly, int wins, int losses, int pitchingRuns, bool start, int saves, decimal innings,
                                    int hitsAllowed, int walksAllowed, int pitchingStrikeouts)
    {
        LeagueId = leagueId;
        TeamId = teamId;
        PlayerId = playerId;
        SeasonId = seasonId;
        GameId = gameId;
        PlayerName = $"{firstName} {lastName}";
        Position = position;
        AtBats = atBats;
        Hits = hits;
        TotalBases = totalBases;
        Runs = runs;
        Doubles = doubles;
        Triples = triples;
        HomeRuns = homeRuns;
        RunsBattedIn = runsBattedIn;
        StolenBases = stolenBases;
        Strikeouts = strikeouts;
        Walks = walks;
        HitByPitch = hitByPitch;
        SacrificeFly = sacrificeFly;
        Wins = wins;
        Losses = losses;
        PitchingRuns = pitchingRuns;
        Start = start;
        Saves = saves;
        Innings = innings;
        HitsAllowed = hitsAllowed;
        WalksAllowed = walksAllowed;
        PitchingStrikeouts = pitchingStrikeouts;
    }

    public Guid LeagueId { get; set; }
    public Guid TeamId { get; set; }
    public Guid PlayerId { get; set; }
    public Guid SeasonId { get; set; }
    public Guid GameId { get; set; }
    public string PlayerName { get; set; }
    public string Position { get; set; }
    public int AtBats { get; set; }
    public int Hits { get; set; }
    public int TotalBases { get; set; }
    public int Runs { get; set; }
    public int Doubles { get; set; }
    public int Triples { get; set; }
    public int HomeRuns { get; set; }
    public int RunsBattedIn { get; set; }
    public int StolenBases { get; set; }
    public int Strikeouts { get; set; }
    public int Walks { get; set; }
    public int HitByPitch { get; set; }
    public int SacrificeFly { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int PitchingRuns { get; set; }
    public bool Start { get; set; }
    public int Saves { get; set; }
    public decimal Innings { get; set; }
    public int HitsAllowed { get; set; }
    public int WalksAllowed { get; set; }
    public int PitchingStrikeouts { get; set; }

}
