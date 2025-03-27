namespace Player.Application.Players.Queries.GetPlayersByState;

public record GetPlayersByStateQuery(string State)
    : IQuery<GetPlayersByStateResult>;

public record GetPlayersByStateResult(IEnumerable<PlayerDto> Players);
