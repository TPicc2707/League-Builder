namespace League.Builder.Web.Server.Models.Stats.Basketball;

public class BasketballGameStatsModel
{
    public BasketballGameStatsModel()
    {

    }

    public BasketballGameStatsModel(Guid leagueId, Guid teamId, Guid playerId, Guid seasonId, Guid gameId, string firstName, string lastName)
    {
        LeagueId = leagueId;
        TeamId = teamId;
        PlayerId = playerId;
        SeasonId = seasonId;
        GameId = gameId;
        PlayerName = String.Concat(firstName + " " + lastName);
    }

    public BasketballGameStatsModel(Guid leagueId, Guid teamId, Guid playerId, Guid seasonId, Guid gameId, string firstName, string lastName,
                                   bool start, int minutes, int points, int fieldGoalsMade, int fieldGoalsAttempted, int threePointersMade,
                                   int threePointersAttempted, int freeThrowsMade, int freeThrowsAttempted, int rebounds, int assists, int steals,
                                   int blocks, int turnovers, int fouls)
    {
        LeagueId = leagueId;
        TeamId = teamId;
        PlayerId = playerId;
        SeasonId = seasonId;
        GameId = gameId;
        PlayerName = String.Concat(firstName + " " + lastName);
        Start = start;
        Minutes = minutes;
        Points = points;
        FieldGoalsMade = fieldGoalsMade;
        FieldGoalsAttempted = fieldGoalsAttempted;
        ThreePointersMade = threePointersMade;
        ThreePointersAttempted = threePointersAttempted;
        FreeThrowsMade = freeThrowsMade;
        FreeThrowsAttempted = freeThrowsAttempted;
        Rebounds = rebounds;
        Assists = assists;
        Steals = steals;
        Blocks = blocks;
        Turnovers = turnovers;
        Fouls = fouls;
    }

    public Guid LeagueId { get; set; }
    public Guid TeamId { get; set; }
    public Guid PlayerId { get; set; }
    public Guid SeasonId { get; set; }
    public Guid GameId { get; set; }
    public string PlayerName { get; set; }
    public bool Start { get; set; }
    public int Minutes { get; set; }
    public int Points { get; set; }
    public int FieldGoalsMade { get; set; }
    public int FieldGoalsAttempted { get; set; }
    public int ThreePointersMade { get; set; }
    public int ThreePointersAttempted { get; set; }
    public int FreeThrowsMade { get; set; }
    public int FreeThrowsAttempted { get; set; }
    public int Rebounds { get; set; }
    public int Assists { get; set; }
    public int Steals { get; set; }
    public int Blocks { get; set; }
    public int Turnovers { get; set; }
    public int Fouls { get; set; }
}
