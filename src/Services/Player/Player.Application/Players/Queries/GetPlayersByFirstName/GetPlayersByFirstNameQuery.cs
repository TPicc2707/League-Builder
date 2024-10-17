namespace Player.Application.Players.Queries.GetPlayersByFirstName;

public record GetPlayersByFirstNameQuery(string FirstName)
    : IQuery<GetPlayersByFirstNameResult>;

public record GetPlayersByFirstNameResult(IEnumerable<PlayerDto> Players);
