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
    public int AtBats { get; set; } = 0;
    public int Hits { get; set; } = 0;
    public int TotalBases { get; set; } = 0;
    public int Runs { get; set; } = 0;
    public int Doubles { get; set; } = 0;
    public int Triples { get; set; } = 0;
    public int HomeRuns { get; set; } = 0;
    public int RunsBattedIn { get; set; } = 0;
    public int StolenBases { get; set; } = 0;
    public int Strikeouts { get; set; } = 0;
    public int Walks { get; set; } = 0;
    public int HitByPitch { get; set; } = 0;
    public int SacrificeFly { get; set; } = 0;
    public int Wins { get; set; } = 0;
    public int Losses { get; set; } = 0;
    public int PitchingRuns { get; set; } = 0;
    public bool Start { get; set; }
    public int Saves { get; set; } = 0;
    public decimal Innings { get; set; }
    public int HitsAllowed { get; set; } = 0;
    public int WalksAllowed { get; set; } = 0;
    public int PitchingStrikeouts { get; set; } = 0;
    public int OutsRecorded { get; set; } = 0;
    public decimal InningsPitched
    {
        get
        {
            int fullInnings = OutsRecorded / 3;
            int remainderOuts = OutsRecorded % 3;
            return fullInnings + (remainderOuts * 0.1m);
        }
    }

    public decimal CombinedBattingAverage(BaseballHittingTotalsModel season)
    {
        int totalAB = season.AtBats + AtBats;
        int totalHits = season.Hits + Hits;
        return totalAB == 0 ? 0 : Math.Round((decimal)totalHits / totalAB, 3);
    }

    public decimal CombinedOnBasePercentage(BaseballHittingTotalsModel season)
    {
        int totalPA =
            (season.AtBats + AtBats) +
            (season.Walks + Walks) +
            (season.HBPs + HitByPitch) +
            (season.SFs + SacrificeFly);

        if (totalPA == 0)
            return 0;

        int totalOnBase =
            (season.Hits + Hits) +
            (season.Walks + Walks) +
            (season.HBPs + HitByPitch);

        return Math.Round((decimal)totalOnBase / totalPA, 3);
    }

    public int BattingOrderPosition { get; set; }
    public string BattingOrderDisplay { get; set; } = "";
}
