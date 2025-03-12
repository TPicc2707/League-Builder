namespace Game.Domain.ValueObjects;

public class GameDetail
{
    public int AwayTeamScore { get; } = default!;
    public int HomeTeamScore { get; } = default!;
    public DateTime StartTime { get; } = default!;
    public DateTime? EndTime { get; } = default!;

    protected GameDetail()
    {
            
    }

    private GameDetail(int awayTeamScore, int homeTeamScore, DateTime startTime, DateTime? endTime)
    {
        AwayTeamScore = awayTeamScore;
        HomeTeamScore = homeTeamScore;
        StartTime = startTime;
        EndTime = endTime;
    }

    public static GameDetail Of(int awayTeamScore, int homeTeamScore, DateTime startTime, DateTime? endTime)
    {
        return new GameDetail(awayTeamScore, homeTeamScore, startTime, endTime);
    }
}
