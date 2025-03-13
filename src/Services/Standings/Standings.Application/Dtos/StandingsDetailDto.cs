namespace Standings.Application.Dtos;

public record StandingsDetailDto(
    int GamesPlayed,
    int Wins,
    int Losses,
    int Ties
    );
