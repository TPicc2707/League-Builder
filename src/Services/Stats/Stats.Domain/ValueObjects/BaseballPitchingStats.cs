namespace Stats.Domain.ValueObjects;

public record BaseballPitchingStats
{
    public int Wins { get; } = default!;
    public int Losses { get; } = default!;
    public int Runs { get; } = default!;
    public bool Start { get; } = default!;
    public int Saves { get; } = default!;
    public decimal Innings { get; } = default!;
    public int HitsAllowed { get; } = default!;
    public int WalksAllowed { get; } = default!;
    public int PitchingStrikeouts { get; } = default!;
    public decimal WalksHitsPerInning { get; } = default!;
    public decimal EarnedRunAverage { get; } = default!;

    protected BaseballPitchingStats()
    {

    }

    private BaseballPitchingStats(int wins, int losses, int runs, bool start, int saves, decimal innings, int hitsAllowed, int walksAllowed, int pitchingStrikeouts)
    {
        Wins = wins;
        Losses = losses;
        Runs = runs;
        Start = start;
        Saves = saves;
        Innings = innings;
        HitsAllowed = hitsAllowed;
        WalksAllowed = walksAllowed;
        PitchingStrikeouts = pitchingStrikeouts;
        if (walksAllowed + hitsAllowed == 0 || innings == 0)
            WalksHitsPerInning = 0.00M;
        else
            WalksHitsPerInning = (decimal)(walksAllowed + hitsAllowed) / innings;
        if (runs == 0 || innings == 0)
            EarnedRunAverage = 0.00M;
        else
            EarnedRunAverage = (decimal)(runs / innings) * 9;
    }

    public static BaseballPitchingStats Of(int wins, int losses, int runs, bool start, int saves, decimal innings, int hitsAllowed, int walksAllowed, int pitchingStrikeouts)
    {
        return new BaseballPitchingStats(wins, losses, runs, start, saves, innings, hitsAllowed, walksAllowed, pitchingStrikeouts);
    }
}
