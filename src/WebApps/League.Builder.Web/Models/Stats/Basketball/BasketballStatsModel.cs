namespace League.Builder.Web.Models.Stats.Basketball;

public record BasketballStatsModel(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    BasketballPlayerStatsModel Stats);


public record CreateBasketballStatsModel(
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    BasketballPlayerStatsModel Stats);

public record UpdateBasketballStatsModel(
    Guid Id,
    Guid LeagueId,
    Guid TeamId,
    Guid PlayerId,
    Guid SeasonId,
    Guid GameId,
    BasketballPlayerStatsModel Stats);


public record BasketballPlayerStatsModel(
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
    int Turnovers);


//Request Records
public record CreateBasketballStatsRequest(CreateBasketballStatsModel BasketballStats);
public record UpdateBasketballStatsRequest(UpdateBasketballStatsModel BasketballStats);

//Response Records
public record GetBasketballStatsResponse(PaginatedResult<BasketballStatsModel> BasketballStats);
public record GetBasketballStatByIdResponse(BasketballStatsModel BasketballStats);
public record GetBasketballStatsByLeagueResponse(IEnumerable<BasketballStatsModel> BasketballStats);
public record GetBasketballStatsByTeamResponse(IEnumerable<BasketballStatsModel> BasketballStats);
public record GetBasketballStatsByPlayerResponse(IEnumerable<BasketballStatsModel> BasketballStats);
public record GetLeagueBasketballStatsBySeasonResponse(IEnumerable<BasketballStatsModel> BasketballStats);
public record GetPlayerBasketballStatByGameResponse(BasketballStatsModel BasketballStats);
public record GetPlayerBasketballStatsBySeasonResponse(IEnumerable<BasketballStatsModel> BasketballStats);
public record GetTeamBasketballStatsByGameResponse(IEnumerable<BasketballStatsModel> BasketballStats);
public record GetTeamBasketballStatsBySeasonResponse(IEnumerable<BasketballStatsModel> BasketballStats);
public record CreateBasketballStatsResponse(Guid Id);
public record UpdateBasketballStatsResponse(bool IsSuccess);
public record DeleteBasketballStatsResponse(bool IsSuccess);