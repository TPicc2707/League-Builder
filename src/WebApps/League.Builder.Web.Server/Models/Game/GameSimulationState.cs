namespace League.Builder.Web.Server.Models.Game;

public class GameSimulationState
{
    public Guid GameId { get; set; }
    public Dictionary<Guid, BaseballGameStatsModel> GameStats = new();
    public int Inning { get; set; } = 1;
    public bool TopOfInning { get; set; } = true;
    public int Outs { get; set; } = 0;

    public List<int> AwayInningsRuns { get; set; } = new();
    public List<int> HomeInningsRuns { get; set; } = new();

    public int HomeScore { get; set; } = 0;
    public int AwayScore { get; set; } = 0;

    public bool RunnerOnFirst { get; set; }
    public bool RunnerOnSecond { get; set; }
    public bool RunnerOnThird { get; set; }

    public List<List<Guid>> HomeBattingOrder = new();
    public List<List<Guid>> AwayBattingOrder = new();

    public List<Guid> HomeBullpen = new();
    public List<Guid> AwayBullpen = new();

    public List<Guid> HomeBenchPlayers = new();
    public List<Guid> AwayBenchPlayers = new();

    public Dictionary<Guid, int> HomePitchersUsed = new();
    public Dictionary<Guid, int> AwayPitchersUsed = new();

    public Guid WinningPitcher { get; set; }

    public int HomeBatterIndex { get; set; } = new();
    public int AwayBatterIndex { get; set; } = new();

    public List<string> PlayByPlay { get; set; } = new();
    public string LastPlayMessage { get; set; } = string.Empty;

    public BaseRunnerState Runners { get; set; } = new();

    public bool GameOver { get; set;  }

    public Guid GetNextBatter()
    {
        var order = TopOfInning ? AwayBattingOrder : HomeBattingOrder;
        int index = TopOfInning ? AwayBatterIndex : HomeBatterIndex;

        var batter = order[index].Last();

        index = (index + 1) % order.Count;

        if (TopOfInning)
            AwayBatterIndex = index;
        else
            HomeBatterIndex = index;

        return batter;
    }

    public Guid CurrentBatterId { get; set;  }
    public Guid HomeBatterId { get; set;  }
    public Guid AwayBatterId { get; set;  }

    public Guid AwayPitcherId { get; set; }
    public Guid HomePitcherId { get; set; }
    public Guid CurrentPitcherId { get; set;  }
}

public class BaseRunnerState
{
    public Guid? RunnerOnFirst { get; set; }
    public Guid? RunnerOnSecond { get; set; }
    public Guid? RunnerOnThird { get; set; }

    public bool FirstOccupied => RunnerOnFirst.HasValue;
    public bool SecondOccupied => RunnerOnSecond.HasValue;
    public bool ThirdOccupied => RunnerOnThird.HasValue;

    public void ClearBases()
    {
        RunnerOnFirst = null;
        RunnerOnSecond = null;
        RunnerOnThird = null;
    }
}

public class PlayerProbabilities
{
    public Guid PlayerId { get; set;  }

    public double POut { get; set;  }
    public double PStrikeout { get; set; }
    public double PWalk { get; set;  }
    public double PHitByPitch { get; set; }
    public double PSingle { get; set;  }
    public double PDouble { get; set;  }
    public double PTriple { get; set;  }
    public double PHomer { get; set;  }
}

public enum AtBatResult
{
    Out,
    Strikeout,
    Walk,
    HitByPitch,
    Single,
    Double,
    Triple,
    HomeRun
}

public class GameResult
{
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public List<string> PlayByPlay { get; set;  }
}
