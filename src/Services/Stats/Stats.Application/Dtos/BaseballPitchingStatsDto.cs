namespace Stats.Application.Dtos;

public record BaseballPitchingStatsDto(
    int Wins, 
    int Losses, 
    int Runs,
    bool Start, 
    int Saves, 
    decimal Innings, 
    int HitsAllowed, 
    int WalksAllowed, 
    int PitchingStrikeouts
    );