namespace League.Builder.Web.Server.Models.Stats.Basketball;

public class BasketballStatLeaderModel
{
    public Guid PlayerId { get; set; }
    public string PlayerName { get; set; }
    public string Team { get; set; }
    public string Image { get; set; }
    public int GamesPlayed { get; set; }
    public int Starts { get; set; }
    public int Minutes { get; set; }
    public int Points { get; set; }
    public decimal PointsPerGame { get; set; }
    public int FieldGoalsMade { get; set; }
    public decimal FieldGoalsMadePerGame { get; set; }
    public int FieldGoalsAttempted { get; set; }
    public decimal FieldGoalsAttemptedPerGame { get; set; }
    public decimal FieldGoalPercentage { get; set; }
    public int ThreePointersMade { get; set; }
    public decimal ThreePointersMadePerGame { get; set; }
    public int ThreePointersAttempted { get; set; }
    public decimal ThreePointersAttemptedPerGame { get; set; }
    public decimal ThreePointerPercentage { get; set; }
    public int FreeThrowsMade { get; set; }
    public decimal FreeThrowsMadePerGame { get; set; }
    public int FreeThrowsAttempted { get; set; }
    public decimal FreeThrowsAttemptedPerGame { get; set; }
    public decimal FreeThrowPercentage { get; set; }
    public int Rebounds { get; set; }
    public decimal ReboundsPerGame { get; set; }
    public int Assists { get; set; }
    public decimal AssistsPerGame { get; set; }
    public int Steals { get; set; }
    public decimal StealsPerGame { get; set; }
    public int Blocks { get; set; }
    public decimal BlocksPerGame { get; set; }
    public int Turnovers { get; set; }
    public decimal TurnoversPerGame { get; set; }
}
