namespace Stats.Application.Dtos;

public record FootballDefensiveStatsDto(
    int Tackles, 
    int Sacks, 
    int TacklesForLoss, 
    int PassesDefended, 
    int DefensiveInterceptions, 
    int DefensiveInterceptionYards, 
    int LongestDefensiveInterceptionPlay, 
    int DefensiveTouchdowns, 
    int ForcedFumbles, 
    int RecoveredFumbles);
