namespace Player.Application.Dtos;

public record PlayerDto(
    Guid Id,
    Guid TeamId,
    string FirstName,
    string LastName,
    AddressDto PlayerAddress,
    PlayerDetailDto PlayerDetail,
    string Description,
    string ImageFile,
    PlayerStatus PlayerStatus
);
