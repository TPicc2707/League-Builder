namespace Standings.Domain.ValueObjects;

public class StandingsDetail
{
    public int GamesPlayed { get; } = default!;
    public int Wins { get; } = default!;
    public int Losses { get; } = default!;
    public int Ties { get; } = default!;
    public decimal WinPercentage {  get; } = default!;

    protected StandingsDetail()
    {
        
    }

    private StandingsDetail(int gamesPlayed, int wins, int losses, int ties)
    {
        GamesPlayed = gamesPlayed;
        Wins = wins;
        Losses = losses;
        Ties = ties;
        if (wins <= 0 || gamesPlayed <= 0)
            WinPercentage = .000M;
        else
            WinPercentage = (decimal)wins / gamesPlayed;
    }

    public static StandingsDetail Of(int gamesPlayed, int wins, int losses, int ties)
    {
        return new StandingsDetail(gamesPlayed, wins, losses, ties);
    }
}
