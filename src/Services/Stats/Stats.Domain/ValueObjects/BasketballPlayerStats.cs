﻿namespace Stats.Domain.ValueObjects;

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

    protected BasketballPlayerStats()
    {

    }

    private BasketballPlayerStats(bool start, int minutes, int points, int fieldGoalsMade, int fieldGoalsAttempted, decimal fieldGoalPercentage, int threePointersMade, int threePointersAttempted, decimal threePointPercentage, int freeThrowsMade, int freeThrowsAttempted, decimal freeThrowPercentage, int rebounds, int assists, int steals, int blocks, int turnovers)
    {
        Start = start;
        Minutes = minutes;
        Points = points;
        FieldGoalsMade = fieldGoalsMade;
        FieldGoalsAttempted = fieldGoalsAttempted;
        FieldGoalPercentage = fieldGoalPercentage;
        ThreePointersMade = threePointersMade;
        ThreePointersAttempted = threePointersAttempted;
        ThreePointPercentage = threePointPercentage;
        FreeThrowsMade = freeThrowsMade;
        FreeThrowsAttempted = freeThrowsAttempted;
        FreeThrowPercentage = freeThrowPercentage;
        Rebounds = rebounds;
        Assists = assists;
        Steals = steals;
        Blocks = blocks;
        Turnovers = turnovers;
    }

    public static BasketballPlayerStats Of(bool start, int minutes, int points, int fieldGoalsMade, int fieldGoalsAttempted, decimal fieldGoalPercentage, int threePointersMade, int threePointersAttempted, decimal threePointPercentage, int freeThrowsMade, int freeThrowsAttempted, decimal freeThrowPercentage, int rebounds, int assists, int steals, int blocks, int turnovers)
    {
        return new BasketballPlayerStats(start, minutes, points, fieldGoalsMade, fieldGoalsAttempted, fieldGoalPercentage, threePointersMade, threePointersAttempted, threePointPercentage, freeThrowsMade, freeThrowsAttempted, freeThrowPercentage, rebounds, assists, steals, blocks, turnovers);
    }
}