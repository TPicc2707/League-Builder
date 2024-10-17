namespace Player.Application.Players.Queries.GetPlayersAfterBirthDate;

public record GetPlayersAfterBirthDateQuery(DateTime BirthDate)
    : IQuery<GetPlayersAfterBirthDateResult>;

public record GetPlayersAfterBirthDateResult(IEnumerable<PlayerDto> Players);