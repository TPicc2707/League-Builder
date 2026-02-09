namespace League.Builder.Web.Server.Persistence;

public static class DataLoader
{
    public static async Task<T> GetOrLoad<T>(
    Func<Task<T>> cacheGetter,
    Func<Task<T>> serviceGetter,
    Func<T, Task> cacheSetter)
    {
        if (await cacheGetter() is T cached)
            return cached;

        var fresh = await serviceGetter();
        try
        {
            await cacheSetter(fresh);
        }
        catch (Exception)
        {
            // Cache failures should never block the app
        }

        return fresh;
    }

    public static decimal AddInnings(decimal current, decimal inningsToAdd)
    {
        int totalOuts =
            ConvertInningsToOuts(current) +
            ConvertInningsToOuts(inningsToAdd);

        return ConvertOutsToInnings(totalOuts);
    }
    public static BaseballStatsModel CreateZeroBaseballStats()
    {
        return new BaseballStatsModel(
            Id: Guid.Empty,
            LeagueId: Guid.Empty,
            TeamId: Guid.Empty,
            PlayerId: Guid.Empty,
            SeasonId: Guid.Empty,
            GameId: Guid.Empty,
            CreateZeroBaseballHittingStats(),
            CreateZeroBaseballPitchingStats()
            );
    }

    private static BaseballHittingStatsModel CreateZeroBaseballHittingStats()
    {
        return new BaseballHittingStatsModel(
        AtBats: 0,
        Hits: 0,
        TotalBases: 0,
        Runs: 0,
        Doubles: 0,
        Triples: 0,
        HomeRuns: 0,
        RunsBattedIn: 0,
        StolenBases: 0,
        Strikeouts: 0,
        Walks: 0,
        HitByPitch: 0,
        SacrificeFly: 0,
        Average: 0,
        Slugging: 0,
        OnBasePercentage: 0,
        OnBasePlusSlugging: 0);
    }

    private static BaseballPitchingStatsModel CreateZeroBaseballPitchingStats()
    {
        return new BaseballPitchingStatsModel(
        Wins: 0,
        Losses: 0,
        Runs: 0,
        Start: false,
        Saves: 0,
        Innings: 0,
        HitsAllowed: 0,
        WalksAllowed: 0,
        PitchingStrikeouts: 0,
        WalksHitsPerInning: 0,
        EarnedRunAverage: 0
        );
    }

    private static decimal ConvertOutsToInnings(int outs)
    {
        int innings = outs / 3;
        int remainder = outs % 3;
        return innings + (remainder * 0.1m);
    }

    private static int ConvertInningsToOuts(decimal innings)
    {
        int wholeInnings = (int)innings;
        int fractionalOuts = (int)((innings - wholeInnings) * 10);

        return wholeInnings * 3 + fractionalOuts;
    }
}
