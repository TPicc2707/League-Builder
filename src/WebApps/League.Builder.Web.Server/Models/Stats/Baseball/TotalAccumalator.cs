namespace League.Builder.Web.Server.Models.Stats.Baseball;

public class HittingTotalAccumalator
{
    public int AtBats;
    public int Hits;
    public int Runs;
    public int TotalBases;
    public int Doubles;
    public int Triples;
    public int HomeRuns;
    public int RBIs;
    public int SBs;
    public int Walks;
    public int HBPs;
    public int SFs;
    public int Strikeouts;

    public void ApplyDeltas(BaseballGameStatsModel updated, BaseballStatsModel original)
    {
        AtBats += updated.AtBats - original.HittingStats.AtBats;
        Hits += updated.Hits - original.HittingStats.Hits;
        TotalBases += updated.TotalBases - original.HittingStats.TotalBases;
        Runs += updated.Runs - original.HittingStats.Runs;
        Doubles += updated.Doubles - original.HittingStats.Doubles;
        Triples += updated.Triples - original.HittingStats.Triples;
        HomeRuns += updated.HomeRuns - original.HittingStats.HomeRuns;
        RBIs += updated.RunsBattedIn - original.HittingStats.RunsBattedIn;
        SBs += updated.StolenBases - original.HittingStats.StolenBases;
        Walks += updated.Walks - original.HittingStats.Walks;
        HBPs += updated.HitByPitch - original.HittingStats.HitByPitch;
        SFs += updated.SacrificeFly - original.HittingStats.SacrificeFly;
        Strikeouts += updated.Strikeouts - original.HittingStats.Strikeouts;
    }

}

public class PitchingTotalAccumalator
{
    public int Wins;
    public int Losses;
    public int Runs;
    public int Saves;
    public decimal Innings;
    public int HitsAllowed;
    public int WalksAllowed;
    public int Strikeouts;

    public void ApplyDeltas(BaseballGameStatsModel updated, BaseballStatsModel original)
    {
        Wins += updated.Wins - original.PitchingStats.Wins;
        Losses += updated.Losses - original.PitchingStats.Losses;
        Runs += updated.PitchingRuns - original.PitchingStats.Runs;
        Saves += updated.Saves - original.PitchingStats.Saves;
        Innings = DataLoader.AddInnings(Innings, updated.Innings - original.PitchingStats.Innings);
        HitsAllowed += updated.HitsAllowed - original.PitchingStats.HitsAllowed;
        WalksAllowed += updated.WalksAllowed - original.PitchingStats.WalksAllowed;
        Strikeouts += updated.PitchingStrikeouts - original.PitchingStats.PitchingStrikeouts;

    }
}
