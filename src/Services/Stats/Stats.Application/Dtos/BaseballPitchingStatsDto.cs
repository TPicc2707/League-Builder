namespace Stats.Application.Dtos;

public record BaseballPitchingStatsDto(
    int Wins, 
    int Losses, 
    bool Start, 
    int Saves, 
    decimal Innings, 
    int HitsAllowed, 
    int WalksAllowed, 
    int PitchingStrikeouts, 
    decimal WalksHitsPerInning
    );