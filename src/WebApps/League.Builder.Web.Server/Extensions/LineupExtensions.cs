namespace League.Builder.Web.Server.Extensions;

public static class LineupExtensions
{
    public static List<List<Guid>> ToBattingOrder(this BaseballGameLineup lineup)
    {
        return new List<List<Guid>>()
        {
            new() { lineup.First },
            new() { lineup.Second },
            new() { lineup.Third },
            new() { lineup.Fourth },
            new() { lineup.Fifth },
            new() { lineup.Sixth },
            new() { lineup.Seventh },
            new() { lineup.Eighth },
            new() { lineup.Ninth },
        };
    }
}

public static class StatsToProbabilities
{
    public static class LeagueAverageProbabilities
    {
        public const double PStrikeout = 0.22;
        public const double PWalk = 0.08;
        public const double PHitByPitch = 0.01;

        // boosted by 5%
        public const double PSingle = 0.1365;
        public const double PDouble = 0.0525;
        public const double PTriple = 0.0105;
        public const double PHomer = 0.0315;

        // recomputed so everything sums to 1
        public const double POut = 0.459;
    }

    public static bool HasNoStats(this BaseballHittingTotalsModel t)
    {
        return t.AtBats == 0 &&
               t.Walks == 0 &&
               t.HBPs == 0 &&
               t.SFs == 0 &&
               t.Hits == 0;
    }

    public static PlayerProbabilities ToProbabilities(this BaseballHittingTotalsModel t, Guid playerId)
    {

        if (t.HasNoStats() || t.AtBats < 50)
        {
            return new PlayerProbabilities
            {
                PlayerId = playerId,
                POut = LeagueAverageProbabilities.POut,
                PStrikeout = LeagueAverageProbabilities.PStrikeout,
                PWalk = LeagueAverageProbabilities.PWalk,
                PHitByPitch = LeagueAverageProbabilities.PHitByPitch,
                PSingle = LeagueAverageProbabilities.PSingle,
                PDouble = LeagueAverageProbabilities.PDouble,
                PTriple = LeagueAverageProbabilities.PTriple,
                PHomer = LeagueAverageProbabilities.PHomer
            };
        }

        var pa = t.AtBats + t.Walks + t.HBPs + t.SFs;
        if (pa == 0) pa = 1;

        double singles = t.Hits - t.Doubles - t.Triples - t.HomeRuns;

        double pWalk = (double)t.Walks / pa;
        double pHbp = (double)t.HBPs / pa;
        double pSingle = singles / pa;
        double pDouble = (double)t.Doubles / pa;
        double pTriple = (double)t.Triples / pa;
        double pHr = (double)t.HomeRuns / pa;
        double pStrikeout = (double)t.Strikeouts / pa;

        pSingle *= 1.05;
        pDouble *= 1.05;
        pTriple *= 1.05;
        pHr *= 1.05;
        
        double pOnBaseBoosted = pWalk + pHbp + pSingle + pDouble + pTriple + pHr;

        if(pOnBaseBoosted > 1.0)
        {
            double scale = 1.0 / pOnBaseBoosted;
            pSingle *= scale;
            pDouble *= scale;
            pTriple *= scale;
            pHr *= scale;
            pWalk *= scale;
            pHbp *= scale;

            pOnBaseBoosted = 1.0;
        }

        double pOut = 1.0 - pOnBaseBoosted;

        return new PlayerProbabilities
        {
            PlayerId = playerId,
            POut = pOut,
            PStrikeout = pStrikeout,
            PWalk = pWalk,
            PHitByPitch = pHbp,
            PSingle = pSingle,
            PDouble = pDouble,
            PTriple = pTriple,
            PHomer = pHr
        };
    }
}

public static class GameStatsUpdater
{
    public static BaseballHittingTotalsModel ToSeasonTotals(
    this IEnumerable<BaseballStatsModel> games)
    {
        var totals = new BaseballHittingTotalsModel();

        foreach (var g in games)
        {
            totals.AtBats += g.HittingStats.AtBats;
            totals.Runs += g.HittingStats.Runs;
            totals.Hits += g.HittingStats.Hits;
            totals.RBIs += g.HittingStats.RunsBattedIn;
            totals.Walks += g.HittingStats.Walks;
            totals.HBPs += g.HittingStats.HitByPitch;
            totals.Strikeouts += g.HittingStats.Strikeouts;
            totals.SBs += g.HittingStats.StolenBases;
            totals.TBs += g.HittingStats.TotalBases;
            totals.Doubles += g.HittingStats.Doubles;
            totals.Triples += g.HittingStats.Triples;
            totals.HomeRuns += g.HittingStats.HomeRuns;
            totals.SFs += g.HittingStats.SacrificeFly;
        }

        // Derived stats
        if (totals.AtBats > 0)
        {
            totals.BattingAverage = (decimal)totals.Hits / totals.AtBats;
            totals.Slugging = (decimal)totals.TBs / totals.AtBats;
        }

        var plateAppearances = totals.AtBats + totals.Walks + totals.HBPs + totals.SFs;
        if (plateAppearances > 0)
        {
            totals.OBP = (decimal)(totals.Hits + totals.Walks + totals.HBPs) / plateAppearances;
            totals.OPS = totals.OBP + totals.Slugging;
        }

        return totals;
    }
}
