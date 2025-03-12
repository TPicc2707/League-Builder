namespace Game.Application.Games.Queries.GetGames;

public record GetGamesQuery(PaginationRequest PaginationRequest)
    : IQuery<GetGamesResult>;

public record GetGamesResult(PaginatedResult<GameDto> Games);
