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
    public List<string>? KeyEvents { get; private set; } // AI will look at Key events to help create a recap
    public string GameRecap { get; private set; }  // AI will build a game recap after the completion of the game

    protected GameDetail()
    {
            
    }

    private GameDetail(int awayTeamScore, int homeTeamScore, DateTime startTime, DateTime? endTime, List<int>? awayInningRuns, List<int>? homeInningRuns, int? awayTotalHits, int? homeTotalHits, List<string>? keyEvents, string gameRecap)
    {
        AwayTeamScore = awayTeamScore;
        HomeTeamScore = homeTeamScore;
        StartTime = startTime;
        EndTime = endTime;
        AwayInningRuns = awayInningRuns;
        HomeInningRuns = homeInningRuns;
        AwayTotalHits = awayTotalHits;
        HomeTotalHits = homeTotalHits;
        KeyEvents = keyEvents;
        GameRecap = gameRecap;
    }

    public static GameDetail Of(int awayTeamScore, int homeTeamScore, DateTime startTime, DateTime? endTime, List<int>? awayInningRuns, List<int>? homeInningRuns, int? awayTotalHits, int? homeTotalHits, List<string>? keyEvents,string gameRecap)
    {
        return new GameDetail(awayTeamScore, homeTeamScore, startTime, endTime, awayInningRuns, homeInningRuns, awayTotalHits, homeTotalHits, keyEvents, gameRecap);
    }
}
