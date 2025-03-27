namespace Player.Application.Dtos;

public record PlayerDetailDto(string EmailAddress, string PhoneNumber, DateTime BirthDate, int Height, int Weight, string Position, int Number);
