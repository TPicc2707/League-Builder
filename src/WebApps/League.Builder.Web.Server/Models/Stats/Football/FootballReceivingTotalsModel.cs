namespace League.Builder.Web.Server.Models.Stats.Football;

public class FootballReceivingTotalsModel
{
    public int Receptions { get; set; }
    public int Targets { get; set; }
    public int ReceivingYards { get; set; }
    public int ReceivingTouchdowns { get; set; }
    public int ReceivingFumbles { get; set; }
    public int ReceivingFumblesLost { get; set; }
    public int YardsAfterCatch { get; set; }

    //Derived for Player Stats
    public decimal ReceivingYardsPerGame { get; set; }
    public decimal ReceivingYardsPerPlay { get; set; }
}
