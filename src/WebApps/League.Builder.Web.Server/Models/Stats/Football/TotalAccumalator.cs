namespace League.Builder.Web.Server.Models.Stats.Football;

public class PassingTotalAccumalator
{
    public int PassingCompletions;
    public int PassingAttempts;
    public int PassingYards;
    public int PassingTouchdowns;
    public int PassingInterceptions;
    public int Sacks;

    public void ApplyDeltas(FootballGameStatsModel updated, FootballStatsModel original)
    {
        PassingCompletions += updated.PassingCompletions - original.OffensiveStats.PassingCompletions;
        PassingAttempts += updated.PassingAttempts - original.OffensiveStats.PassingAttempts;
        PassingYards += updated.PassingYards - original.OffensiveStats.PassingYards;
        PassingTouchdowns += updated.PassingTouchdowns - original.OffensiveStats.PassingTouchdowns;
        PassingInterceptions += updated.PassingInterceptions - original.OffensiveStats.PassingInterceptions;
        Sacks += updated.Sacks - original.OffensiveStats.Sacks;
    }
}

public class RushingTotalAccumalator
{
    public int RushingAttempts;
    public int RushingYards;
    public int RushingTouchdowns;
    public int RushingFumbles;
    public int RushingFumblesLost;

    public void ApplyDeltas(FootballGameStatsModel updated, FootballStatsModel original)
    {
        RushingAttempts += updated.RushingAttempts - original.OffensiveStats.RushingAttempts;
        RushingYards += updated.RushingYards - original.OffensiveStats.RushingYards;
        RushingTouchdowns += updated.RushingTouchdowns - original.OffensiveStats.RushingTouchdowns;
        RushingFumbles += updated.RushingFumbles - original.OffensiveStats.RushingFumbles;
        RushingFumblesLost += updated.RushingFumblesLost - original.OffensiveStats.RushingFumblesLost;
    }
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

    public void ApplyDeltas(FootballGameStatsModel updated, FootballStatsModel original)
    {
        Receptions += updated.Receptions - original.OffensiveStats.Receptions;
        Targets += updated.Targets - original.OffensiveStats.Targets;
        ReceivingYards += updated.ReceivingYards - original.OffensiveStats.ReceivingYards;
        ReceivingTouchdowns += updated.ReceivingTouchdowns - original.OffensiveStats.ReceivingTouchdowns;
        ReceivingFumbles += updated.ReceivingFumbles - original.OffensiveStats.ReceivingFumbles;
        ReceivingFumblesLost += updated.ReceivingFumblesLost - original.OffensiveStats.ReceivingFumblesLost;
        YardsAfterCatch += updated.YardsAfterCatch - original.OffensiveStats.YardsAfterCatch;
    }
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

    public void ApplyDeltas(FootballGameStatsModel updated, FootballStatsModel original)
    {
        Tackles += updated.Tackles - original.DefensiveStats.Tackles;
        DefensiveSacks += updated.DefensiveSacks - original.DefensiveStats.Sacks;
        TacklesForLoss += updated.TacklesForLoss - original.DefensiveStats.TacklesForLoss;
        PassesDefended += updated.PassesDefended - original.DefensiveStats.PassesDefended;
        DefensiveInterceptions += updated.DefensiveInterceptions - original.DefensiveStats.DefensiveInterceptions;
        DefensiveInterceptionYards += updated.DefensiveInterceptionYards - original.DefensiveStats.DefensiveInterceptionYards;
        DefensiveTouchdowns += updated.DefensiveTouchdowns - original.DefensiveStats.DefensiveTouchdowns;
        ForcedFumbles += updated.ForcedFumbles - original.DefensiveStats.ForcedFumbles;
        RecoveredFumbles += updated.RecoveredFumbles - original.DefensiveStats.RecoveredFumbles;
    }
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
    public void ApplyDeltas(FootballGameStatsModel updated, FootballStatsModel original)
    {
        FieldGoalsMade += updated.FieldGoalsMade - original.KickingStats.FieldGoalsMade;
        FieldGoalsAttempted += updated.FieldGoalsAttempted - original.KickingStats.FieldGoalsAttempted;
        ExtraPointsMade += updated.ExtraPointsMade - original.KickingStats.ExtraPointsMade;
        ExtraPointsAttempted += updated.ExtraPointsAttempted - original.KickingStats.ExtraPointsAttempted;
        Points += updated.Points - original.KickingStats.Points;
        Punts += updated.Punts - original.KickingStats.Punts;
        PuntingYards += updated.PuntingYards - original.KickingStats.PuntingYards;
    }

}