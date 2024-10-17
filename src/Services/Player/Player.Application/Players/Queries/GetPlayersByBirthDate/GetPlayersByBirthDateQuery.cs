namespace Player.Application.Players.Queries.GetPlayersByBirthDate;

public record GetPlayersByBirthDateQuery(DateTime BirthDate)
    : IQuery<GetPlayersByBirthDateResult>;

public record GetPlayersByBirthDateResult(IEnumerable<PlayerDto> Players);