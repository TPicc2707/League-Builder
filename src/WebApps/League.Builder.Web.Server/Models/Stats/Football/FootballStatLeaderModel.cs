namespace League.Builder.Web.Server.Models.Stats.Football;

public class FootballStatLeaderModel
{
    public Guid PlayerId { get; set; }
    public string PlayerName { get; set; }
    public string Team { get; set; }
    public string Image { get; set; }
    public int GamesPlayed { get; set; }
    public int PassingCompletions { get; set; }
    public int PassingAttempts { get; set; }
    public decimal PassingCompletionPercentage { get; set; }
    public int PassingYards { get; set; }
    public decimal PassingYardsPerGame { get; set; }
    public decimal PassingYardsPerPlay { get; set; }
    public int LongestPassingPlay { get; set; }
    public int PassingTouchdowns { get; set; }
    public int PassingInterceptions { get; set; }
    public int Sacks { get; set; }
    public int RushingAttempts { get; set; }
    public int RushingYards { get; set; }
    public decimal RushingYardsPerGame { get; set; }
    public decimal RushingYardsAverage { get; set; }
    public int LongestRushingPlay { get; set; }
    public int RushingTouchdowns { get; set; }
    public int RushingFumbles { get; set; }
    public int RushingFumblesLost { get; set; }
    public int Receptions { get; set; }
    public int Targets { get; set; }
    public int ReceivingYards { get; set; }
    public decimal ReceivingYardsPerGame { get; set; }
    public decimal ReceivingYardsPerPlay { get; set; }
    public int ReceivingTouchdowns { get; set; }
    public int ReceivingFumbles { get; set; }
    public int ReceivingFumblesLost { get; set; }
    public int YardsAfterCatch { get; set; }
    public int Tackles { get; set; }
    public int DefensiveSacks { get; set; }
    public int TacklesForLoss { get; set; }
    public int PassesDefended { get; set; }
    public int DefensiveInterceptions { get; set; }
    public int DefensiveInterceptionYards { get; set; }
    public int LongestDefensiveInterceptionPlay { get; set; }
    public int DefensiveTouchdowns { get; set; }
    public int ForcedFumbles { get; set; }
    public int RecoveredFumbles { get; set; }
    public int FieldGoalsMade { get; set; }
    public int FieldGoalsAttempted { get; set; }
    public decimal FieldGoalPercentage { get; set; }
    public int ExtraPointsMade { get; set; }
    public int ExtraPointsAttempted { get; set; }
    public decimal ExtraPointPercentage { get; set; }
    public int LongestKick { get; set; }
    public int Points { get; set; }
    public int Punts { get; set; }
    public int PuntingYards { get; set; }
    public int LongestPunt { get; set; }
}
