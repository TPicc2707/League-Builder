namespace League.Builder.Web.Server.Models.Stats.Baseball;

public class BaseballHittingTotalsModel
{
    public int AtBats { get; set; }
    public int Runs { get; set; }
    public int Hits { get; set; }
    public int RBIs { get; set; }
    public int Walks { get; set; }
    public int HBPs { get; set; }
    public int Strikeouts { get; set; }
    public int SBs { get; set; }
    public int TBs { get; set; }
    public int Doubles { get; set; }
    public int Triples { get; set; }
    public int HomeRuns { get; set; }
    public int SFs { get; set; }


    // Derived stats used for Player and Team Totals
    public decimal BattingAverage { get; set; }
    public decimal Slugging { get; set; }
    public decimal OBP { get; set; }
    public decimal OPS { get; set; }

}
