namespace Stats.Domain.ValueObjects;

public record BasketballPlayerStats
{
    public bool Start { get; } = default!;
    public int Minutes { get; } = default!;
    public int Points { get; } = default!;
    public int FieldGoalsMade { get; } = default!;
    public int FieldGoalsAttempted { get; } = default!;
    public decimal FieldGoalPercentage{ get; } = default!;
    public int ThreePointersMade { get; } = default!;
    public int ThreePointersAttempted { get; } = default!;
    public decimal ThreePointPercentage { get; } = default!;
    public int FreeThrowsMade { get; } = default!;
    public int FreeThrowsAttempted { get; } = default!;
    public decimal FreeThrowPercentage { get; } = default!;
    public int Rebounds { get; } = default!;
    public int Assists { get; } = default!;
    public int Steals { get; } = default!;
    public int Blocks { get; } = default!;
    public int Turnovers { get; } = default!;
    public int Fouls { get; } = default!;

    protected BasketballPlayerStats()
    {

    }

    private BasketballPlayerStats(bool start, int minutes, int points, int fieldGoalsMade, int fieldGoalsAttempted, int threePointersMade, int threePointersAttempted, int freeThrowsMade, int freeThrowsAttempted, int rebounds, int assists, int steals, int blocks, int turnovers, int fouls)
    {
        Start = start;
        Minutes = minutes;
        Points = points;
        FieldGoalsMade = fieldGoalsMade;
        FieldGoalsAttempted = fieldGoalsAttempted;
        if (fieldGoalsMade == 0 || fieldGoalsAttempted == 0)
            FieldGoalPercentage = 0.00M;
        else
            FieldGoalPercentage = (decimal)fieldGoalsMade / fieldGoalsAttempted;
        ThreePointersMade = threePointersMade;
        ThreePointersAttempted = threePointersAttempted;
        if (threePointersMade == 0 || threePointersAttempted == 0)
            ThreePointPercentage = 0.00M;
        else
            ThreePointPercentage = threePointersMade / threePointersAttempted;
        FreeThrowsMade = freeThrowsMade;
        FreeThrowsAttempted = freeThrowsAttempted;
        if (freeThrowsMade == 0 || freeThrowsAttempted == 0)
            FreeThrowPercentage = 0.00M;
        else
            FreeThrowPercentage = freeThrowsMade / freeThrowsAttempted;
        Rebounds = rebounds;
        Assists = assists;
        Steals = steals;
        Blocks = blocks;
        Turnovers = turnovers;
        Fouls = fouls;
    }

    public static BasketballPlayerStats Of(bool start, int minutes, int points, int fieldGoalsMade, int fieldGoalsAttempted, int threePointersMade, int threePointersAttempted, int freeThrowsMade, int freeThrowsAttempted, int rebounds, int assists, int steals, int blocks, int turnovers, int fouls)
    {
        return new BasketballPlayerStats(start, minutes, points, fieldGoalsMade, fieldGoalsAttempted, threePointersMade, threePointersAttempted, freeThrowsMade, freeThrowsAttempted, rebounds, assists, steals, blocks, turnovers, fouls);
    }
}
