namespace Player.Application.Players.Queries.GetPlayersByPosition;

public record GetPlayersByPositionQuery(string Position)
    : IQuery<GetPlayersByPositionResult>;

public record GetPlayersByPositionResult(IEnumerable<PlayerDto> Players);
