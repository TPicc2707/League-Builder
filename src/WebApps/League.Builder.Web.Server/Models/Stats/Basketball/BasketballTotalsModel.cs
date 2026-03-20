namespace League.Builder.Web.Server.Models.Stats.Basketball;

public class BasketballTotalsModel
{
    public int Starts { get; set; }
    public int Points { get; set; }
    public int FieldGoalsMade { get; set; }
    public int FieldGoalsAttempted { get; set; }
    public int ThreePointersMade { get; set; }
    public int ThreePointersAttempted { get; set; }
    public int FreeThrowsMade { get; set; }
    public int FreeThrowsAttempted { get; set; }
    public int Rebounds { get; set; }
    public int Assists { get; set; }
    public int Steals { get; set; }
    public int Blocks { get; set; }
    public int Turnovers { get; set; }
    public int Fouls { get; set; }
    public int Minutes { get; set; }

    // Derived stats for Player Stats
    public decimal MinutesAverage { get; set; }
    public decimal PointsAverage { get; set; }
    public decimal ReboundsAverage { get; set; }
    public decimal AssistsAverage { get; set; }
    public decimal StealsAverage { get; set; }
    public decimal BlocksAverage { get; set; }
    public decimal FoulsAverage { get; set;  }
    public decimal TurnoversAverage { get; set; }
    public decimal FieldGoalMadeAverage { get; set; }
    public decimal FieldGoalAttemptedAverage { get; set; }
    public decimal FieldGoalPercentage { get; set; }
    public decimal ThreePointerMadeAverage { get; set; }
    public decimal ThreePointerAttemptedAverage { get; set; }
    public decimal ThreePointerPercentage { get; set; }
    public decimal FreeThrowMadeAverage { get; set; }
    public decimal FreeThrowAttemptedAverage { get; set; }
    public decimal FreeThrowPercentage { get; set; }

}
