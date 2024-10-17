namespace Player.Application.Players.Queries.GetPlayerById;

public record GetPlayerByIdQuery(Guid Id) : IQuery<GetPlayerByIdResult>;

public record GetPlayerByIdResult(PlayerDto Player);