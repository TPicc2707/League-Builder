namespace Game.Domain.ValueObjects;

public class GameDetail
{
    public int AwayTeamScore { get; } = default!;
    public int HomeTeamScore { get; } = default!;
    public DateTime StartTime { get; } = default!;
    public DateTime? EndTime { get; } = default!;
    public List<int>? AwayInningRuns { get; private set; } // Baseball only, can be null for other sports
    public List<int>? HomeInningRuns { get; private set; } // Baseball only, can be null for other sports
    public int? AwayTotalHits { get; private set; } // Baseball only, can be 0 for other sports
    public int? HomeTotalHits { get; private set; } // Baseball only, can be 0 for other sports

    protected GameDetail()
    {
            
    }

    private GameDetail(int awayTeamScore, int homeTeamScore, DateTime startTime, DateTime? endTime, List<int>? awayInningRuns, List<int>? homeInningRuns, int? awayTotalHits, int? homeTotalHits)
    {
        AwayTeamScore = awayTeamScore;
        HomeTeamScore = homeTeamScore;
        StartTime = startTime;
        EndTime = endTime;
        AwayInningRuns = awayInningRuns;
        HomeInningRuns = homeInningRuns;
        AwayTotalHits = awayTotalHits;
        HomeTotalHits = homeTotalHits;
    }

    public static GameDetail Of(int awayTeamScore, int homeTeamScore, DateTime startTime, DateTime? endTime, List<int>? awayInningRuns, List<int>? homeInningRuns, int? awayTotalHits, int? homeTotalHits)
    {
        return new GameDetail(awayTeamScore, homeTeamScore, startTime, endTime, awayInningRuns, homeInningRuns, awayTotalHits, homeTotalHits);
    }
}
