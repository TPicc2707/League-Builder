namespace Player.Application.Players.Queries.GetPlayers;

public record GetPlayersQuery(PaginationRequest PaginationRequest)
    : IQuery<GetPlayersResult>;

public record GetPlayersResult(PaginatedResult<PlayerDto> Players);
