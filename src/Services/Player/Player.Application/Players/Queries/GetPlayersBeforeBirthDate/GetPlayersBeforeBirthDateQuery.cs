namespace Player.Application.Players.Queries.GetPlayersBeforeBirthDate;

public record GetPlayersBeforeBirthDateQuery(DateTime BirthDate)
    : IQuery<GetPlayersBeforeBirthDateResult>;

public record GetPlayersBeforeBirthDateResult(IEnumerable<PlayerDto> Players);
