namespace Player.Application.Players.Queries.GetPlayersByLastName;

public record GetPlayersByLastNameQuery(string LastName)
    : IQuery<GetPlayersByLastNameResult>;

public record GetPlayersByLastNameResult(IEnumerable<PlayerDto> Players);
