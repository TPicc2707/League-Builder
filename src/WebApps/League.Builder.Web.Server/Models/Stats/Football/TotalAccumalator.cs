namespace League.Builder.Web.Server.Models.Stats.Football;

public class PassingTotalAccumalator
{
    public int PassingCompletions;
    public int PassingAttempts;
    public int PassingYards;
    public int PassingTouchdowns;
    public int PassingInterceptions;
    public int Sacks;
}

public class RushingTotalAccumalator
{
    public int RushingAttempts;
    public int RushingYards;
    public int RushingTouchdowns;
    public int RushingFumbles;
    public int RushingFumblesLost;
}

public class ReceivingTotalAccumalator 
{
    public int Receptions;
    public int Targets;
    public int ReceivingYards;
    public int ReceivingTouchdowns;
    public int ReceivingFumbles;
    public int ReceivingFumblesLost;
    public int YardsAfterCatch;
}

public class DefensiveTotalAccumalator 
{
    public int Tackles;
    public int DefensiveSacks;
    public int TacklesForLoss;
    public int PassesDefended;
    public int DefensiveInterceptions;
    public int DefensiveInterceptionYards;
    public int DefensiveTouchdowns;
    public int ForcedFumbles;
    public int RecoveredFumbles;
}

public class KickingTotalAccumalator 
{
    public int FieldGoalsMade;
    public int FieldGoalsAttempted;
    public int ExtraPointsMade;
    public int ExtraPointsAttempted;
    public int Points;
    public int Punts;
    public int PuntingYards;
}