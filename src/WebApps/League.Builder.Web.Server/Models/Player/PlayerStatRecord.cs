namespace League.Builder.Web.Server.Models.Player;

public class PlayerStatRecord
{
    public PlayerStatRecord(string team, BaseballStatsModel stats)
    {
        OpposingTeam = team;
        StatsModel = stats;
    }

    public string OpposingTeam { get; set; }
    public BaseballStatsModel StatsModel { get; set; }

}
