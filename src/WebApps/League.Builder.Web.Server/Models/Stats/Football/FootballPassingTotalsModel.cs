namespace League.Builder.Web.Server.Models.Stats.Football;

public class FootballPassingTotalsModel
{
    public int PassingCompletions { get; set; } 
    public int PassingAttempts { get; set; }
    public int PassingYards { get; set; }
    public int PassingTouchdowns { get; set; }
    public int PassingInterceptions { get; set; }
    public int Sacks { get; set; }
    public int LongestPassingPlay { get; set; }

    // Derived for Player Stats
    public decimal PassingYardsPerGame { get; set;  }
    public decimal PassingYardsPerPlay { get; set;  }
    public decimal PassingCompletionPercentage { get; set; }
}
