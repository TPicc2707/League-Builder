namespace League.Builder.Web.Server.Models.Player;

public class PlayerStatRecord
{
    public PlayerStatRecord(string team, BaseballStatsModel stats)
    {
        OpposingTeam = team;
        BaseballStatsModel = stats;
    }

    public PlayerStatRecord(string team, BasketballStatsModel stats)
    {
        OpposingTeam = team;
        BasketballStatsModel = stats;
    }

    public string OpposingTeam { get; set; }
    public BaseballStatsModel BaseballStatsModel { get; set; }
    public BasketballStatsModel BasketballStatsModel { get; set; }

}
