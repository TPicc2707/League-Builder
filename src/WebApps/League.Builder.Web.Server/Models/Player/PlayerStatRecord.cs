namespace League.Builder.Web.Server.Models.Player;

public class PlayerStatRecord
{
    public PlayerStatRecord(string team, string teamImage, BaseballStatsModel stats)
    {
        OpposingTeam = team;
        OpposingTeamImage = teamImage;
        BaseballStatsModel = stats;
    }

    public PlayerStatRecord(string team, string teamImage, BasketballStatsModel stats)
    {
        OpposingTeam = team;
        OpposingTeamImage = teamImage;
        BasketballStatsModel = stats;
    }

    public PlayerStatRecord(string team, string teamImage, FootballStatsModel stats)
    {
        OpposingTeam = team;
        OpposingTeamImage = teamImage;
        FootballStatsModel = stats;
    }

    public string OpposingTeam { get; set; }
    public string OpposingTeamImage { get; set; }
    public BaseballStatsModel BaseballStatsModel { get; set; }
    public BasketballStatsModel BasketballStatsModel { get; set; }
    public FootballStatsModel FootballStatsModel { get; set; }

}
