namespace Stats.Application.Dtos;

public record BasketballPlayerStatsDto(
    bool Start, 
    int Minutes, 
    int Points, 
    int FieldGoalsMade, 
    int FieldGoalsAttempted, 
    int ThreePointersMade, 
    int ThreePointersAttempted, 
    int FreeThrowsMade, 
    int FreeThrowsAttempted, 
    int Rebounds, 
    int Assists, 
    int Steals, 
    int Blocks, 
    int Turnovers,
    int Fouls);
