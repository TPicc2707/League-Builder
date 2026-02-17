namespace League.Builder.Web.Server.Models.Stats.Baseball;

public class BaseballStatLeaderModel
{
    public Guid PlayerId { get; set; }
    public string PlayerName { get; set; }
    public string Position { get; set; }
    public string Team { get; set; }
    public string Image { get; set; }
    public int GamesPlayed { get; set; }
    public int AtBats { get; set; }
    public int Hits { get; set; }
    public int Runs { get; set; }
    public decimal Average { get; set; }
    public int RunsBattedIn { get; set; }
    public int Doubles { get; set; }
    public int Triples { get; set; }
    public int HomeRuns { get; set; }
    public int TotalBases { get; set; }
    public decimal Slugging { get; set; }
    public int StolenBases { get; set; }
    public int Strikeouts { get; set; }
    public int Walks { get; set; }
    public int HitByPitch { get; set; }
    public int SacrificeFly { get; set; }
    public decimal OnBasePercentage { get; set; }
    public decimal OnBasePlusSlugging { get; set; }
    public int PitchingStarts { get; set; }
    public int PitchingWins { get; set; }
    public int PitchingLosses { get; set; }
    public decimal InningsPitched { get; set; }
    public int HitsAllowed { get; set; }
    public int RunsAllowed { get; set; }
    public int WalksAllowed { get; set; }
    public int PitchingStrikeouts { get; set; }
    public int Saves { get; set; }
    public decimal EarnedRunAverage { get; set; }
    public decimal WalksHitsPerInning { get; set; }
}
