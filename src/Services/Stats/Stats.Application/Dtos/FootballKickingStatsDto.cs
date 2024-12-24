namespace Stats.Application.Dtos;

public record FootballKickingStatsDto(
    int FieldGoalsMade, 
    int FieldGoalsAttempted, 
    decimal FieldGoalPercentage, 
    int ExtraPointsMade, 
    int ExtraPointsAttempted, 
    decimal ExtraPointPercentage, 
    int Punts, 
    int PuntingYards, 
    int LongestPunt
    );
