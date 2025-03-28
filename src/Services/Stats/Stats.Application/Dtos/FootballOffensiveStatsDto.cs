namespace Stats.Application.Dtos;

public record FootballOffensiveStatsDto(
    int PassingCompletions, 
    int PassingAttempts, 
    decimal PassingCompletionPercentage, 
    int PassingYards, 
    decimal PassingYardsPerPlay, 
    int LongestPassingPlay, 
    int PassingTouchdowns, 
    int PassingInterceptions, 
    int Sacks, 
    decimal PasserRating,
    int RushingAttempts, 
    int RushingYards, 
    decimal RushingYardsAverage, 
    int LongestRushingPlay, 
    int RushingTouchdowns, 
    int RushingFumbles, 
    int RushingFumblesLost,
    int Receptions, 
    int Targets, 
    int ReceivingYards, 
    decimal ReceivingYardsPerPlay,
    int ReceivingTouchdowns, 
    int ReceivingFumbles, 
    int ReceivingFumblesLost, 
    int YardsAfterCatch
    );
