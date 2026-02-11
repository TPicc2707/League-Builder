namespace League.Builder.Web.Server.Models.Stats.Basketball;

public class TotalAccumulator
{
    public int Points;
    public int FieldGoalsMade;
    public int FieldGoalsAttempted;
    public int ThreePointersMade;
    public int ThreePointersAttempted;
    public int FreeThrowsMade;
    public int FreeThrowsAttempted;
    public int Rebounds;
    public int Assists;
    public int Steals;
    public int Blocks;
    public int Turnovers;
    public int Fouls;

    public void ApplyDelta(BasketballGameStatsModel updated, BasketballStatsModel original)
    {
        Points += updated.Points - original.Stats.Points;
        FieldGoalsMade += updated.FieldGoalsMade - original.Stats.FieldGoalsMade;
        FieldGoalsAttempted += updated.FieldGoalsAttempted - original.Stats.FieldGoalsAttempted;
        ThreePointersMade += updated.ThreePointersMade - original.Stats.ThreePointersMade;
        ThreePointersAttempted += updated.ThreePointersAttempted - original.Stats.ThreePointersAttempted;
        FreeThrowsMade += updated.FreeThrowsMade - original.Stats.FreeThrowsMade;
        FreeThrowsAttempted += updated.FreeThrowsAttempted - original.Stats.FreeThrowsAttempted;
        Rebounds += updated.Rebounds - original.Stats.Rebounds;
        Assists += updated.Assists - original.Stats.Assists;
        Steals += updated.Steals - original.Stats.Steals;
        Blocks += updated.Blocks - original.Stats.Blocks;
        Turnovers += updated.Turnovers - original.Stats.Turnovers;
        Fouls += updated.Fouls - original.Stats.Fouls;
    }
}
