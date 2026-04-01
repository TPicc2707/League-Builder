namespace League.Builder.Web.Server.Services;

public class GameSimulatorService : IGameSimulatorService
{
    private AtBatEngine _engine = default!;

    public GameSimulationState StartGame(
        GameLineupModel home,
        GameLineupModel away,
        IDictionary<Guid, BaseballHittingTotalsModel> seasonTotals,
        IDictionary<Guid, BaseballGameStatsModel> gameStats)
    {
        _engine = new AtBatEngine(seasonTotals);

        var state = new GameSimulationState
        {
            GameId = home.GameId,
            GameStats = gameStats.ToDictionary(),
            HomeBatterId = home.BaseballLineup.First,
            AwayBatterId = away.BaseballLineup.First,
            HomeBattingOrder = home.BaseballLineup.ToBattingOrder(),
            AwayBattingOrder = away.BaseballLineup.ToBattingOrder(),
            Inning = 1,
            TopOfInning = true,
            Outs = 0,
            CurrentPitcherId = home.BaseballLineup.StartingPitcher, //pitcher to start the game
            AwayPitcherId = away.BaseballLineup.StartingPitcher,
            HomePitcherId = home.BaseballLineup.StartingPitcher,
        };

        state.HomePitchersUsed.Add(state.HomePitcherId, state.HomePitchersUsed.Count);
        state.AwayPitchersUsed.Add(state.AwayPitcherId, state.AwayPitchersUsed.Count);
        state.CurrentBatterId = state.GetNextBatter();
        // Ensure inning list is long enough
        while (state.AwayInningsRuns.Count < state.Inning)
            state.AwayInningsRuns.Add(0);

        while (state.HomeInningsRuns.Count < state.Inning)
            state.HomeInningsRuns.Add(0);

        return state;
    }

    public GameSimulationState SimulateNextAtBat(
        GameSimulationState state,
        IDictionary<Guid, BaseballGameStatsModel> gameStats)
    {
        if (_engine is null)
            throw new InvalidOperationException("StartGame must be called before SimulateNextAtBat.");

        var batterName = gameStats.FirstOrDefault(x => x.Value.PlayerId == state.CurrentBatterId).Value.PlayerName;
        var result = _engine.GetOutcome(state.CurrentBatterId);

        if (!gameStats.TryGetValue(state.CurrentBatterId, out var stats))
            throw new InvalidOperationException($"No BaseeballGameStatsModel found for player {state.CurrentBatterId}");

        state.LastPlayMessage = BuildPlayMessage(batterName, result);

        switch (result)
        {
            case AtBatResult.Out:
            case AtBatResult.Strikeout:
                ApplyOut(state, state.CurrentBatterId, gameStats, result);
                break;
            case AtBatResult.Single:
                ApplySingle(state, state.CurrentBatterId, gameStats);
                break;
            case AtBatResult.Double:
                ApplyDouble(state, state.CurrentBatterId, gameStats);
                break;
            case AtBatResult.Triple:
                ApplyTriple(state, state.CurrentBatterId, gameStats);
                break;
            case AtBatResult.HomeRun:
                ApplyHomeRun(state, state.CurrentBatterId, gameStats);
                break;
            case AtBatResult.Walk:
                ApplyWalk(state, state.CurrentBatterId, gameStats);
                break;
            case AtBatResult.HitByPitch:
                ApplyHitByPitch(state, state.CurrentBatterId, gameStats);
                break;
        }

        var batterId = state.GetNextBatter();
        state.CurrentBatterId = batterId;

        return state;
    }

    public void ChangePitcher(GameSimulationState state, Guid pitcherId, bool isHomeTeam)
    {
        if (isHomeTeam)
        {
            state.HomePitcherId = pitcherId;
            state.CurrentPitcherId = pitcherId;
            if(!state.HomePitchersUsed.ContainsKey(pitcherId))
                state.HomePitchersUsed[pitcherId] = state.HomePitchersUsed.Count;
            state.HomeBullpen.Remove(pitcherId);
        }
        else
        {
            state.AwayPitcherId = pitcherId;
            state.CurrentPitcherId = pitcherId;
            if (!state.AwayPitchersUsed.ContainsKey(pitcherId))
                state.AwayPitchersUsed[pitcherId] = state.AwayPitchersUsed.Count;
            state.AwayBullpen.Remove(pitcherId);
        }

        state.LastPlayMessage = "Pitching Change";
    }

    public void PinchHitter(GameSimulationState state,
        Guid hitterId,
        bool isAwayTeam)
    {
        var battingOrder = isAwayTeam ? state.AwayBattingOrder : state.HomeBattingOrder;

        var order = battingOrder.FindIndex(slot => slot.Contains(state.CurrentBatterId));

        // Add pinch hitter to the slot
        battingOrder[order].Add(hitterId);

        // New hitter becomes the active batter
        state.CurrentBatterId = hitterId;

        // Remove from bench
        if(isAwayTeam)
            state.AwayBenchPlayers.Remove(hitterId);
        else
            state.HomeBenchPlayers.Remove(hitterId);

        state.LastPlayMessage = "Pinch Hitter enters the game";
    }

    public Guid DetermineWinningPitcher(GameSimulationState state)
    {
        bool homeWon = state.HomeScore > state.AwayScore;

        var pitchers = homeWon ? state.HomePitchersUsed : state.AwayPitchersUsed;

        // starter = first pitcher used
        var starterId = pitchers.OrderBy(x => x.Value).First().Key;
        var starterStats = state.GameStats[starterId];

        int inningLeadTaken = FindInningWhenLeadBecamePermanent(state);
        Guid pitcherAtLead = GetPitcherAtInning(state, inningLeadTaken, homeWon);

        // Starter must pitch at least 5 innings and leave with lead to qualify for win
        if (starterStats.Innings >= 5 && pitcherAtLead == starterId)
            return starterId;

        return pitcherAtLead;
    }

    public Guid DetermineLosingPitcher(GameSimulationState state)
    {
        bool homeWon = state.HomeScore > state.AwayScore;

        // Losing team is opposite
        bool awayLost = homeWon;
        bool homeLost = !homeWon;

        int inningLeadTaken = FindInningWhenLeadBecamePermanent(state);

        // Get pitcher for the losing team at that inning
        var losingPitcher = GetPitcherAtInning(state, inningLeadTaken, homeWon: !homeWon);

        return losingPitcher;
    }

    private void ApplySingle(GameSimulationState state, Guid batterId, IDictionary<Guid, BaseballGameStatsModel> gameStats)
    {
        // Runner on third scores
        if (state.Runners.RunnerOnThird is Guid r3)
        {
            ScoreRun(state, r3, batterId, gameStats);
            state.Runners.RunnerOnThird = null;
        }

        // Runner on second moves to third
        if (state.Runners.RunnerOnSecond is Guid r2)
        {
            state.Runners.RunnerOnThird = r2;
            state.Runners.RunnerOnSecond = null;
        }

        // Runner on first moves to second
        if (state.Runners.RunnerOnFirst is Guid r1)
        {
            state.Runners.RunnerOnSecond = r1;
            state.Runners.RunnerOnFirst = null;
        }

        // Batter goes to first
        state.Runners.RunnerOnFirst = batterId;

        gameStats[batterId].Hits++;
        gameStats[batterId].AtBats++;
        gameStats[batterId].TotalBases += 1;

        var pitcher = gameStats[state.CurrentPitcherId];
        pitcher.HitsAllowed++; 
    }

    private void ApplyDouble(GameSimulationState state, Guid batterId, IDictionary<Guid, BaseballGameStatsModel> gameStats)
    {
        // Runner on third scores
        if (state.Runners.RunnerOnThird is Guid r3)
        {
            ScoreRun(state, r3, batterId, gameStats);
            state.Runners.RunnerOnThird = null;
        }

        // Runner on second scores
        if (state.Runners.RunnerOnSecond is Guid r2)
        {
            ScoreRun(state, r2, batterId, gameStats);
            state.Runners.RunnerOnSecond = null;
        }

        // Runner on first → third
        if (state.Runners.RunnerOnFirst is Guid r1)
        {
            state.Runners.RunnerOnThird = r1;
            state.Runners.RunnerOnFirst = null;
        }

        // Batter → second
        state.Runners.RunnerOnSecond = batterId;

        gameStats[batterId].Hits++;
        gameStats[batterId].AtBats++;
        gameStats[batterId].TotalBases += 2;
        gameStats[batterId].Doubles++;

        var pitcher = gameStats[state.CurrentPitcherId];
        pitcher.HitsAllowed++;
    }

    private void ApplyTriple(GameSimulationState state, Guid batterId, IDictionary<Guid, BaseballGameStatsModel> gameStats)
    {
        // All runners score
        if (state.Runners.RunnerOnThird is Guid r3)
            ScoreRun(state, r3, batterId, gameStats);

        if (state.Runners.RunnerOnSecond is Guid r2)
            ScoreRun(state, r2, batterId, gameStats);

        if (state.Runners.RunnerOnFirst is Guid r1)
            ScoreRun(state, r1, batterId, gameStats);

        state.Runners.ClearBases();

        // Batter → third
        state.Runners.RunnerOnThird = batterId;

        gameStats[batterId].Hits++;
        gameStats[batterId].AtBats++;
        gameStats[batterId].TotalBases += 3;
        gameStats[batterId].Triples++;

        var pitcher = gameStats[state.CurrentPitcherId];
        pitcher.HitsAllowed++;
    }

    private void ApplyHomeRun(GameSimulationState state, Guid batterId, IDictionary<Guid, BaseballGameStatsModel> gameStats)
    {
        // All runners score
        if (state.Runners.RunnerOnThird is Guid r3)
            ScoreRun(state, r3, batterId, gameStats);

        if (state.Runners.RunnerOnSecond is Guid r2)
            ScoreRun(state, r2, batterId, gameStats);

        if (state.Runners.RunnerOnFirst is Guid r1)
            ScoreRun(state, r1, batterId, gameStats);

        // Batter scores
        ScoreRun(state, batterId, batterId, gameStats);

        state.Runners.ClearBases();

        gameStats[batterId].Hits++;
        gameStats[batterId].HomeRuns++;
        gameStats[batterId].AtBats++;
        gameStats[batterId].TotalBases += 4;

        var pitcher = gameStats[state.CurrentPitcherId];
        pitcher.HitsAllowed++;
    }

    private void ApplyWalk(GameSimulationState state, Guid batterId, IDictionary<Guid, BaseballGameStatsModel> gameStats)
    {
        ApplyForcedAdvance(state, batterId, gameStats);

        gameStats[batterId].Walks++;

        var pitcher = gameStats[state.CurrentPitcherId];
        pitcher.WalksAllowed++;
    }

    private void ApplyHitByPitch(GameSimulationState state, Guid batterId, IDictionary<Guid, BaseballGameStatsModel> gameStats)
    {
        ApplyForcedAdvance(state, batterId, gameStats);

        gameStats[batterId].HitByPitch++;
    }

    private void ApplyForcedAdvance(GameSimulationState state, Guid batterId, IDictionary<Guid, BaseballGameStatsModel> gameStats)
    {
        var runners = state.Runners;

        var onFirst = runners.RunnerOnFirst;
        var onSecond = runners.RunnerOnSecond;
        var onThird = runners.RunnerOnThird;

        // Bases loaded → forced run
        if (onFirst.HasValue && onSecond.HasValue && onThird.HasValue)
        {
            ScoreRun(state, onThird.Value, batterId, gameStats);

            runners.RunnerOnThird = onSecond;
            runners.RunnerOnSecond = onFirst;
            runners.RunnerOnFirst = batterId;

            gameStats[batterId].Walks++;
            return;
        }

        // Force runner from 2nd → 3rd if needed
        if (onSecond.HasValue && !onThird.HasValue)
        {
            runners.RunnerOnThird = onSecond;
            runners.RunnerOnSecond = null;
        }

        // Force runner from 1st → 2nd if needed
        if (onFirst.HasValue && !runners.RunnerOnSecond.HasValue)
        {
            runners.RunnerOnSecond = onFirst;
            runners.RunnerOnFirst = null;
        }

        // Batter always takes first
        runners.RunnerOnFirst = batterId;
    }


    private void ApplyOut(GameSimulationState state, Guid batterId, IDictionary<Guid, BaseballGameStatsModel> gameStats, AtBatResult result)
    {
        state.Outs++;
        gameStats[batterId].AtBats++;
        
        var pitcher = gameStats[state.CurrentPitcherId];
        pitcher.OutsRecorded++;
        pitcher.Innings = pitcher.InningsPitched;

        if (result == AtBatResult.Strikeout)
        {
            gameStats[batterId].Strikeouts++;
            pitcher.PitchingStrikeouts++;
        }

        if (state.Outs >= 3)
            AdvanceHalfInning(state);

    }

    private void ScoreRun(GameSimulationState state, Guid runnerId, Guid batterId, IDictionary<Guid, BaseballGameStatsModel> gameStats)
    {
        if (state.TopOfInning)
        {
            state.AwayScore++;
            state.AwayInningsRuns[state.Inning - 1]++;
        }
        else
        {
            state.HomeScore++;
            state.HomeInningsRuns[state.Inning - 1]++;

        }

        gameStats[runnerId].Runs++;
        gameStats[batterId].RunsBattedIn++;

        var pitcher = gameStats[state.CurrentPitcherId];
        pitcher.PitchingRuns++;

        state.LastPlayMessage += $" Run Scored!";

        // WALK-OFF CHECK
        // Bottom of the 9th or later, home team just took the lead
        if(!state.TopOfInning && state.Inning >= 9)
        {
            if (state.HomeScore > state.AwayScore)
                state.GameOver = true;
        }
    }

    private string BuildPlayMessage(string batterName, AtBatResult result)
    {
        var action = result switch
        {
            AtBatResult.Out => "is out",
            AtBatResult.Strikeout => "struckout",
            AtBatResult.Walk => "walks",
            AtBatResult.Single => "hits a single",
            AtBatResult.Double => "hits a double",
            AtBatResult.Triple => "hits a triple",
            AtBatResult.HomeRun => "hits a home run!",
            _ => "does something"
        };

        return $"{batterName} {action}";
    }

    private void AdvanceHalfInning(GameSimulationState state)
    {
        state.Outs = 0;
        state.Runners.ClearBases();

        // 1. Home team leading after TOP of 9th → game over
        if (state.TopOfInning && state.Inning >= 9)
        {
            if(state.HomeScore > state.AwayScore)
            {
                state.GameOver = true;
                state.LastPlayMessage += $", GAME IS OVER!";
                return;
            }
        }

        // 2. After BOTTOM of 9th or later → if not tied, game over
        if (!state.TopOfInning && state.Inning >= 9)
        {
            if (state.HomeScore != state.AwayScore)
            {
                state.GameOver = true;
                state.LastPlayMessage += $", GAME IS OVER!";
                return;
            }
        }

        if (state.TopOfInning)
        {
            state.TopOfInning = false;
        }
        else
        {
            state.TopOfInning = true;
            state.Inning++;

            // Ensure inning list is long enough
            while (state.AwayInningsRuns.Count < state.Inning)
                state.AwayInningsRuns.Add(0);

            while (state.HomeInningsRuns.Count < state.Inning)
                state.HomeInningsRuns.Add(0);
        }

        state.LastPlayMessage += $", Inning over";
        state.CurrentPitcherId = state.TopOfInning
                                        ? state.HomePitcherId
                                        : state.AwayPitcherId;
        state.CurrentBatterId = state.TopOfInning
                                        ? state.HomeBatterId
                                        : state.AwayBatterId;
    }

    private int FindInningWhenLeadBecamePermanent(GameSimulationState state)
    {
        var awayCum = Cumulative(state.AwayInningsRuns);
        var homeCum = Cumulative(state.HomeInningsRuns);

        bool homeWon = state.HomeScore > state.AwayScore;

        for(int i = 0; i < Math.Min(awayCum.Count, homeCum.Count); i++) 
        { 
            bool homeAhead = homeCum[i] > awayCum[i];
            bool awayAhead = awayCum[i] > homeCum[i];

            if (homeWon && homeAhead)
                return i;

            if(!homeWon && awayAhead)
                return i;
        }

        return awayCum.Count - 1;
    }

    private List<int> Cumulative(List<int> runs)
    {
        var list = new List<int>();
        int total = 0;

        foreach(var r in runs)
        {
            total += r;
            list.Add(total);
        }

        return list;
    }


    private Guid GetPitcherAtInning(GameSimulationState state, int inning, bool homeWon)
    {
        var pitchersUsed = homeWon ? state.HomePitchersUsed : state.AwayPitchersUsed;

        foreach(var kvp in pitchersUsed.OrderBy(x => x.Value))
        {
            var pitcherId = kvp.Key;
            var stats = state.GameStats[pitcherId];

            if(stats.Innings > inning)
                return pitcherId;
        }


        // Fallback
        return pitchersUsed.OrderBy(x => x.Value).First().Key;
    }
}
