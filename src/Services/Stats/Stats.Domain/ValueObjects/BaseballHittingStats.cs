namespace Stats.Domain.ValueObjects;

public record BaseballHittingStats
{
    public int AtBats { get; } = default!;
    public int Hits { get; } = default!;
    public int TotalBases { get; } = default!;
    public int Runs { get; } = default!;
    public int Doubles { get; } = default!;
    public int Triples { get; } = default!;
    public int HomeRuns { get; } = default!;
    public int RunsBattedIn { get; } = default!;
    public int StolenBases { get; } = default!;
    public int Strikeouts { get; } = default!;
    public int Walks { get; } = default!;
    public int HitByPitch { get; } = default!;
    public int SacrificeFly { get; } = default;

    protected BaseballHittingStats()
    {

    }

    private BaseballHittingStats(int atBats, int hits, int totalBases, int runs, int doubles, int triples, int homeRuns, int runsBattedIn, int stolenBases, int strikeouts, int walks, int hitByPitch, int sacrificeFly)
    {
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
    }

    public static BaseballHittingStats Of(int atBats, int hits, int totalBases, int runs, int doubles, int triples, int homeRuns, int runsBattedIn, int stolenBases, int strikeouts, int walks, int hitByPitch, int sacrificeFly)
    {
        return new BaseballHittingStats(atBats, hits, totalBases, runs, doubles, triples, homeRuns, runsBattedIn, stolenBases, strikeouts, walks, hitByPitch, sacrificeFly);
    }

}
