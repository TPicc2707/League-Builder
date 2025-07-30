namespace Stats.Application.Dtos;

public record FootballOffensiveStatsDto(
    int PassingCompletions, 
    int PassingAttempts, 
    int PassingYards, 
    int LongestPassingPlay, 
    int PassingTouchdowns, 
    int PassingInterceptions, 
    int Sacks, 
    int RushingAttempts, 
    int RushingYards, 
    int LongestRushingPlay, 
    int RushingTouchdowns, 
    int RushingFumbles, 
    int RushingFumblesLost,
    int Receptions, 
    int Targets, 
    int ReceivingYards, 
    int ReceivingTouchdowns, 
    int ReceivingFumbles, 
    int ReceivingFumblesLost, 
    int YardsAfterCatch
    );
