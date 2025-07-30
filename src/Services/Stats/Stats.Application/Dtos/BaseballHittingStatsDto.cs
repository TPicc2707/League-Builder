namespace Stats.Application.Dtos;

public record BaseballHittingStatsDto(
    int AtBats, 
    int Hits, 
    int TotalBases, 
    int Runs, 
    int Doubles, 
    int Triples, 
    int HomeRuns, 
    int RunsBattedIn, 
    int StolenBases, 
    int Strikeouts, 
    int Walks, 
    int HitByPitch,
    int SacrificeFly
    );
