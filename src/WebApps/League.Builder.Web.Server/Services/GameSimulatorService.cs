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
        if(state.WinningPitcher == Guid.Empty)
            WinningPitcher(state);

        if (state.LosingPitcher == Guid.Empty)
            LosingPitcher(state);

        if (isHomeTeam)
        {
            state.HomePitcherId = pitcherId;
            state.CurrentPitcherId = pitcherId;
            if(!state.HomePitchersUsed.ContainsKey(pitcherId))
                state.HomePitchersUsed[pitcherId] = state.HomePitchersUsed.Count;
            state.HomeBullpen.Remove(pitcherId);

            DetermineSaver(state, state.CurrentPitcherId, true);
        }
        else
        {
            state.AwayPitcherId = pitcherId;
            state.CurrentPitcherId = pitcherId;
            if (!state.AwayPitchersUsed.ContainsKey(pitcherId))
                state.AwayPitchersUsed[pitcherId] = state.AwayPitchersUsed.Count;
            state.AwayBullpen.Remove(pitcherId);

            DetermineSaver(state, state.CurrentPitcherId, false);
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

    private void DetermineSaver(GameSimulationState state, Guid currentPitcherId, bool homeTeam)
    {
        int difference;
        if (state.HomeScore == state.AwayScore) return;

        bool homeWinning = state.HomeScore > state.AwayScore;

        if(homeWinning)
            difference = state.HomeScore - state.AwayScore;
        else
            difference = state.AwayScore - state.HomeScore;

        if (difference <= 3 && state.WinningPitcher != Guid.Empty && homeWinning == homeTeam)
            state.SavingPitcher = currentPitcherId;

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

        if(state.TopOfInning)
            state.TotalAwayHits++;
        else
            state.TotalHomeHits++;

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

        if (state.TopOfInning)
            state.TotalAwayHits++;
        else
            state.TotalHomeHits++;

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

        if (state.TopOfInning)
            state.TotalAwayHits++;
        else
            state.TotalHomeHits++;

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

        if (state.TopOfInning)
            state.TotalAwayHits++;
        else
            state.TotalHomeHits++;

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
        // 1. Check who was leading BEFORE the play
        // Positive = Home leading, Negative = Away leading, 0 = Tied
        int scoreDifferentialBefore = state.HomeScore - state.AwayScore;

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

        // 3. Check who is leading AFTER the play
        int scoreDifferentialAfter = state.HomeScore - state.AwayScore;

        // 4. Determine if a critical change happened
        bool wasTied = (scoreDifferentialBefore == 0);
        bool isNowTied = (scoreDifferentialAfter == 0);

        // A lead flip happened if the advantage swung from Home to Away or vice-versa
        // (e.g., from +1 to -1, or from -2 to +1)
        bool leadFlipped = (scoreDifferentialBefore > 0 && scoreDifferentialAfter < 0) ||
                            (scoreDifferentialBefore < 0 && scoreDifferentialAfter > 0);

        bool leadBroken = wasTied && !isNowTied; // Tied → Home or Away lead
        bool gameBecameTied = !wasTied && isNowTied; // Home or Away lead → Tied

        if(leadBroken || gameBecameTied || leadFlipped)
        {
            WinningPitcher(state);
            LosingPitcher(state);
        }
    }

    public void WinningPitcher(GameSimulationState state)
    {
        // A game must be official (at least 5 innings) for a win to matter
        // Home team can win in 4.5 innings if leading in the bottom of the 5th
        bool isOfficial = (state.Inning > 5) || (state.Inning == 5 && !state.TopOfInning);

        if (!isOfficial) return;

        if(state.HomeScore > state.AwayScore)
        {
            state.WinningPitcher = state.HomePitcherId;
        }
        else if(state.AwayScore > state.HomeScore)
        {
            state.WinningPitcher = state.AwayPitcherId;
        }
        else
        {
            state.WinningPitcher = Guid.Empty; // Tie game, no winning pitcher
        }
    }

    public void LosingPitcher(GameSimulationState state)
    {
        if (state.HomeScore > state.AwayScore)
        {
            state.LosingPitcher = state.AwayPitcherId;
        }
        else if (state.AwayScore > state.HomeScore)
        {
            state.LosingPitcher = state.HomePitcherId;
        }
        else
        {
            state.LosingPitcher = Guid.Empty; // Tie game, no losing pitcher
        }

        if (state.SavingPitcher == state.LosingPitcher)
            state.SavingPitcher = null; // Can't have a save if the "saver" is also the losing pitcher
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
}
