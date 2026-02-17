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

    public static T Clone<T>(T source)
    {
        return System.Text.Json.JsonSerializer.Deserialize<T>(System.Text.Json.JsonSerializer.Serialize(source));
    }

    public static void Reset<T>(T target, T backup)
    {
        var restored = Clone(backup);
        foreach (var prop in typeof(T).GetProperties())
            prop.SetValue(target, prop.GetValue(restored));
    }

    public static decimal AddInnings(decimal current, decimal inningsToAdd)
    {
        int totalOuts =
            ConvertInningsToOuts(current) +
            ConvertInningsToOuts(inningsToAdd);

        return ConvertOutsToInnings(totalOuts);
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

    public static BasketballStatsModel CreateZeroBasketballStats()
    {
        return new BasketballStatsModel(
             Id: Guid.Empty,
            LeagueId: Guid.Empty,
            TeamId: Guid.Empty,
            PlayerId: Guid.Empty,
            SeasonId: Guid.Empty,
            GameId: Guid.Empty,
            CreateZeroBasketballPlayerStats());
    }

    private static BasketballPlayerStatsModel CreateZeroBasketballPlayerStats()
    {
        return new BasketballPlayerStatsModel(
            Start: false,
            Minutes: 0,
            Points: 0,
            FieldGoalsMade: 0,
            FieldGoalsAttempted: 0,
            FieldGoalPercentage: 0,
            ThreePointersMade: 0,
            ThreePointersAttempted: 0,
            ThreePointPercentage: 0,
            FreeThrowsMade: 0,
            FreeThrowsAttempted: 0,
            FreeThrowPercentage: 0,
            Rebounds: 0,
            Assists: 0,
            Steals: 0,
            Blocks: 0,
            Turnovers: 0,
            Fouls: 0);
    }

    public static FootballStatsModel CreateZeroFootballStats()
    {
        return new FootballStatsModel(
             Id: Guid.Empty,
            LeagueId: Guid.Empty,
            TeamId: Guid.Empty,
            PlayerId: Guid.Empty,
            SeasonId: Guid.Empty,
            GameId: Guid.Empty,
            CreateZeroFootballOffensiveStats(),
            CreateZeroFootballDefensiveStats(),
            CreateZeroFootballKickingStats());
    }

    private static FootballOffensiveStatsModel CreateZeroFootballOffensiveStats()
    {
        return new FootballOffensiveStatsModel(
            PassingCompletions: 0,
            PassingAttempts: 0,
            PassingCompletionPercentage: 0,
            PassingYards: 0,
            PassingYardsPerPlay: 0,
            LongestPassingPlay: 0,
            PassingTouchdowns: 0,
            PassingInterceptions: 0,
            Sacks: 0,
            PasserRating: 0,
            RushingAttempts: 0,
            RushingYards: 0,
            RushingYardsAverage: 0,
            LongestRushingPlay: 0,
            RushingTouchdowns: 0,
            RushingFumbles: 0,
            RushingFumblesLost: 0,
            Receptions: 0,
            Targets: 0,
            ReceivingYards: 0,
            ReceivingYardsPerPlay: 0,
            ReceivingTouchdowns: 0,
            ReceivingFumbles: 0,
            ReceivingFumblesLost: 0,
            YardsAfterCatch: 0);
    }

    private static FootballDefensiveStatsModel CreateZeroFootballDefensiveStats()
    {
        return new FootballDefensiveStatsModel(
            Tackles: 0,
            Sacks: 0,
            TacklesForLoss: 0,
            PassesDefended: 0,
            DefensiveInterceptions: 0,
            DefensiveInterceptionYards: 0,
            LongestDefensiveInterceptionPlay: 0,
            DefensiveTouchdowns: 0,
            ForcedFumbles: 0,
            RecoveredFumbles: 0);
    }

    private static FootballKickingStatsModel CreateZeroFootballKickingStats()
    {
        return new FootballKickingStatsModel(
            FieldGoalsMade: 0,
            FieldGoalsAttempted: 0,
            FieldGoalPercentage: 0,
            ExtraPointsMade: 0,
            ExtraPointsAttempted: 0,
            ExtraPointPercentage: 0,
            LongestKick: 0,
            Points: 0,
            Punts: 0,
            PuntingYards: 0,
            LongestPunt: 0);
    }
}
