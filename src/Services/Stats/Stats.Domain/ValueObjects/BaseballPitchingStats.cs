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
    }

    public static BaseballPitchingStats Of(int wins, int losses, int runs, bool start, int saves, decimal innings, int hitsAllowed, int walksAllowed, int pitchingStrikeouts)
    {
        return new BaseballPitchingStats(wins, losses, runs, start, saves, innings, hitsAllowed, walksAllowed, pitchingStrikeouts);
    }
}
