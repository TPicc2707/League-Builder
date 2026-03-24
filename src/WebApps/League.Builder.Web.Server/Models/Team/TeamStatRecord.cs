namespace League.Builder.Web.Server.Models.Team;

public class TeamStatRecord
{
    public List<PlayerStatsRecord> Players { get; set; } = new List<PlayerStatsRecord>();
}


public class PlayerStatsRecord
{
    public PlayerStatsRecord(PlayerModel player, BaseballSeasonStats stats)
    {
        PlayerId = player.Id;
        FirstName = player.FirstName;
        LastName = player.LastName;
        Number = player.PlayerDetail.Number;
        Position = player.PlayerDetail.Position;
        Image = player.Image;
        BaseballStatsModel = stats;
    }

    public PlayerStatsRecord(PlayerModel player, BasketballSeasonStats stats)
    {
        PlayerId = player.Id;
        FirstName = player.FirstName;
        LastName = player.LastName;
        Number = player.PlayerDetail.Number;
        Position = player.PlayerDetail.Position;
        Image = player.Image;
        BasketballStatsModel = stats;
    }

    public PlayerStatsRecord(PlayerModel player, FootballSeasonStats stats, decimal passingYardsPerGame,
                             decimal rushingYardsPerGame, decimal receivingYardsPerGame)
    {
        PlayerId = player.Id;
        FirstName = player.FirstName;
        LastName = player.LastName;
        Number = player.PlayerDetail.Number;
        Position = player.PlayerDetail.Position;
        Image = player.Image;
        PassingYardsPerGame = passingYardsPerGame;
        RushingYardsPerGame = rushingYardsPerGame;
        ReceivingYardsPerGame = receivingYardsPerGame;
        FootballStatsModel = stats;
    }

    public Guid PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Number { get; set; }
    public string Position { get; set; }
    public string Image { get; set; }
    public decimal PassingYardsPerGame { get; set;  }
    public decimal RushingYardsPerGame { get; set;  }
    public decimal ReceivingYardsPerGame { get; set;  }
    public BaseballSeasonStats BaseballStatsModel { get; set; }
    public BasketballSeasonStats BasketballStatsModel { get; set; }
    public FootballSeasonStats FootballStatsModel { get; set; }

}

public class BaseballSeasonStats
{
    public BaseballSeasonStats(BaseballHittingStatsModel hittingStatsModel, BaseballPitchingStatsModel pitchingStatsModel, int totalStarts, int totalGamesPlayed)
    {
        HittingStatsModel = hittingStatsModel;
        PitchingStatsModel = pitchingStatsModel;
        TotalPitchingStarts = totalStarts;
        TotalGamesPlayed = totalGamesPlayed;

    }

    public BaseballHittingStatsModel HittingStatsModel { get; set; }
    public BaseballPitchingStatsModel PitchingStatsModel { get; set; }
    public int TotalPitchingStarts { get; set; } //pitching model has it as a bool.
    public int TotalGamesPlayed { get; set; }
}

public class BasketballSeasonStats
{
    public BasketballSeasonStats(BasketballPlayerStats stats, int totalGamesStarted, int totalGamesPlayed)
    {
        Stats = stats;
        TotalGamesStarted = totalGamesStarted;
        TotalGamesPlayed = totalGamesPlayed;
    }

    public BasketballPlayerStats Stats { get; set; }
    public int TotalGamesStarted { get; set; }
    public int TotalGamesPlayed { get; set; }

}

public class BasketballPlayerStats
{
    public decimal MinutesPerGame { get; set; }
    public decimal PointsPerGame { get; set; }
    public decimal ReboundsPerGame { get; set; }
    public decimal AssistsPerGame { get; set; }
    public decimal StealsPerGame { get; set; }
    public decimal TurnoversPerGame { get; set; }
    public decimal BlocksPerGame { get; set; }
    public decimal FoulsPerGame { get; set; }
    public decimal FieldGoalsMadePerGame { get; set; }
    public decimal FieldGoalsAttemptedPerGame { get; set; }
    public decimal FieldGoalPercentage { get; set; }
    public decimal ThreePointersMadePerGame { get; set; }
    public decimal ThreePointersAttemptedPerGame { get; set; }
    public decimal ThreePointPercentage { get; set; }
    public decimal FreeThrowsMadePerGame { get; set; }
    public decimal FreeThrowsAttemptedPerGame { get; set; }
    public decimal FreeThrowPercentage { get; set; }
}

public class FootballSeasonStats
{
    public FootballSeasonStats(FootballOffensiveStatsModel offensiveStatsModel, FootballDefensiveStatsModel defensiveStatsModel,
                            FootballKickingStatsModel kickingStatsModel, int totalGamesPlayed)
    {
        OffensiveStatsModel = offensiveStatsModel;
        DefensiveStatsModel = defensiveStatsModel;
        KickingStatsModel = kickingStatsModel;
        TotalGamesPlayed = totalGamesPlayed;
    }

    public FootballOffensiveStatsModel OffensiveStatsModel { get; set; }
    public FootballDefensiveStatsModel DefensiveStatsModel { get; set; }
    public FootballKickingStatsModel KickingStatsModel { get; set; }
    public int TotalGamesPlayed { get; set; }

}