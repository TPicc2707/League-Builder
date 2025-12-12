namespace Game.Application.Dtos;

public record BaseballGameLineupDto(
    Guid First,
    Guid Second,
    Guid Third,
    Guid Fourth,
    Guid Fifth,
    Guid Sixth,
    Guid Seventh,
    Guid Eighth,
    Guid Ninth,
    Guid StartingPitcher);
