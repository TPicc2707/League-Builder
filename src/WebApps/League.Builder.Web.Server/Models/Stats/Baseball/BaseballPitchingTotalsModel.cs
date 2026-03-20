namespace League.Builder.Web.Server.Models.Stats.Baseball;

public class BaseballPitchingTotalsModel
{
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int Runs { get; set; }
    public int Saves { get; set; }
    public decimal Innings { get; set; }
    public int HitsAllowed { get; set; }
    public int WalksAllowed { get; set; }
    public int Strikeouts { get; set; }
    public int Starts { get; set; }


    // Derived stats used for Player Totals
    public decimal ERA { get; set; }
    public decimal WHIP { get; set; }

}
