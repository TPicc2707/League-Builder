namespace Stats.Application.Dtos;

public record FootballKickingStatsDto(
    int FieldGoalsMade, 
    int FieldGoalsAttempted, 
    int ExtraPointsMade, 
    int ExtraPointsAttempted, 
    int LongestKick, 
    int Points, 
    int Punts, 
    int PuntingYards, 
    int LongestPunt
    );
