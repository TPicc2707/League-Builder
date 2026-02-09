namespace League.Builder.Web.Server.Models.Stats.Football;

public class FootballGameStatsModel
{
    public FootballGameStatsModel()
    {

    }

    public FootballGameStatsModel(Guid leagueId, Guid teamId, Guid playerId, Guid seasonId, Guid gameId, string firstName, string lastName)
    {
        LeagueId = leagueId;
        TeamId = teamId;
        PlayerId = playerId;
        SeasonId = seasonId;
        GameId = gameId;
        PlayerName = String.Concat(firstName + " " + lastName);
    }

    public FootballGameStatsModel(Guid leagueId, Guid teamId, Guid playerId, Guid seasonId, Guid gameId, string firstName, string lastName,
                                   int passingCompletions, int passingAttempts, int passingYards, int longestPassingPlay, int passingTouchdowns, int passingInterceptions, int sacks,
                                   int rushingAttempts, int rushingYards, int longestRushingPlay, int rushingTouchdowns, int rushingFumbles, int rushingFumblesLost,
                                   int receptions, int targets, int receivingYards, int receivingTouchdowns, int receivingFumbles, int receivingFumblesLost, int yardsAfterCatch,
                                   int tackles, int defensiveSacks, int tacklesForLoss, int passesDefended, int defensiveInterceptions, int defensiveInterceptionYards,
                                   int longestDefensiveInterceptionPlay, int defensiveTouchdowns, int forcedFumbles, int recoveredFumbles,
                                   int fieldGoalsMade, int fieldGoalsAttempted, int extraPointsMade, int extraPointsAttempted, int longestKick, int points, int punts, int puntingYards,
                                   int longestPunt)
    {
        LeagueId = leagueId;
        TeamId = teamId;
        PlayerId = playerId;
        SeasonId = seasonId;
        GameId = gameId;
        PlayerName = String.Concat(firstName + " " + lastName);
        PassingCompletions = passingCompletions;
        PassingAttempts = passingAttempts;
        PassingYards = passingYards;
        LongestPassingPlay = longestPassingPlay;
        PassingTouchdowns = passingTouchdowns;
        PassingInterceptions = passingInterceptions;
        Sacks = sacks;
        RushingAttempts = rushingAttempts;
        RushingYards = rushingYards;
        LongestRushingPlay = longestRushingPlay;
        RushingTouchdowns = rushingTouchdowns;
        RushingFumbles = rushingFumbles;
        RushingFumblesLost = rushingFumblesLost;
        Receptions = receptions;
        Targets = targets;
        ReceivingYards = receivingYards;
        ReceivingTouchdowns = receivingTouchdowns;
        ReceivingFumbles = receivingFumbles;
        ReceivingFumblesLost = receivingFumblesLost;
        YardsAfterCatch = yardsAfterCatch;
        Tackles = tackles;
        DefensiveSacks = defensiveSacks;
        TacklesForLoss = tacklesForLoss;
        PassesDefended = passesDefended;
        DefensiveInterceptions = defensiveInterceptions;
        DefensiveInterceptionYards = defensiveInterceptionYards;
        LongestDefensiveInterceptionPlay = longestDefensiveInterceptionPlay;
        DefensiveTouchdowns = defensiveTouchdowns;
        ForcedFumbles = forcedFumbles;
        RecoveredFumbles = recoveredFumbles;
        FieldGoalsMade = fieldGoalsMade;
        FieldGoalsAttempted = fieldGoalsAttempted;
        ExtraPointsMade = extraPointsMade;
        ExtraPointsAttempted = extraPointsAttempted;
        LongestKick = longestKick;
        Points = points;
        Punts = punts;
        PuntingYards = puntingYards;
        LongestPunt = longestPunt;
    }

    public Guid LeagueId { get; set; }
    public Guid TeamId { get; set; }
    public Guid PlayerId { get; set; }
    public Guid SeasonId { get; set; }
    public Guid GameId { get; set; }
    public string PlayerName { get; set; }
    public int PassingCompletions { get; set; }
    public int PassingAttempts { get; set; }
    public int PassingYards { get; set; }
    public int LongestPassingPlay { get; set; }
    public int PassingTouchdowns { get; set; }
    public int PassingInterceptions { get; set; }
    public int Sacks { get; set; }
    public int RushingAttempts { get; set; }
    public int RushingYards { get; set; }
    public int LongestRushingPlay { get; set; }
    public int RushingTouchdowns { get; set; }
    public int RushingFumbles { get; set; }
    public int RushingFumblesLost { get; set; }
    public int Receptions { get; set; }
    public int Targets { get; set; }
    public int ReceivingYards { get; set; }
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
    public int ExtraPointsMade { get; set; }
    public int ExtraPointsAttempted { get; set; }
    public int LongestKick { get; set; }
    public int Points { get; set; }
    public int Punts { get; set; }
    public int PuntingYards { get; set; }
    public int LongestPunt { get; set; }
}
