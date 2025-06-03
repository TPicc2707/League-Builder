namespace Stats.Application.Dtos;

public record BasketballPlayerStatsDto(
    bool Start, 
    int Minutes, 
    int Points, 
    int FieldGoalsMade, 
    int FieldGoalsAttempted, 
    decimal FieldGoalPercentage, 
    int ThreePointersMade, 
    int ThreePointersAttempted, 
    decimal ThreePointPercentage, 
    int FreeThrowsMade, 
    int FreeThrowsAttempted, 
    decimal FreeThrowPercentage, 
    int Rebounds, 
    int Assists, 
    int Steals, 
    int Blocks, 
    int Turnovers,
    int Fouls);
