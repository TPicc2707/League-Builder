namespace League.Builder.Web.Server.Models.Stats.Football;

public class FootballKickingTotalsModel
{
    public int FieldGoalsMade { get; set; }
    public int FieldGoalsAttempted { get; set; }
    public int ExtraPointsMade { get; set; }
    public int ExtraPointsAttempted { get; set; }
    public int Points { get; set; }
    public int Punts { get; set; }
    public int PuntingYards { get; set; }

    // Derived For Player stats
    public int LongestPunt { get; set; }
    public decimal FieldGoalPercentage { get; set; }
    public decimal ExtraPointPercentage { get; set; }
}
