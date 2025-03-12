namespace Player.Application.Extensions;

public static class PlayerExtensions
{
    public static IEnumerable<PlayerDto> ToPlayerDtoList(this IEnumerable<Domain.Models.Player> players)
    {
        return players.Select(player => new PlayerDto(
            Id: player.Id.Value,
            TeamId: player.TeamId.Value,
            FirstName: player.FirstName.Value,
            LastName: player.LastName.Value,
            PlayerAddress: new AddressDto(
                player.PlayerAddress.AddressLine,
                player.PlayerAddress.Country,
                player.PlayerAddress.State,
                player.PlayerAddress.ZipCode),
            PlayerDetail: new PlayerDetailDto(
                player.PlayerDetail.EmailAddress,
                player.PlayerDetail.PhoneNumber,
                player.PlayerDetail.BirthDate,
                player.PlayerDetail.Height,
                player.PlayerDetail.Weight,
                player.PlayerDetail.Position),
            Description: player.Description,
            ImageFile: player.ImageFile,
            PlayerStatus: player.PlayerStatus
            ));
    }

    public static PlayerDto ToSinglePlayerDto(this Domain.Models.Player player)
    {
        return new PlayerDto(
            Id: player.Id.Value,
            TeamId: player.TeamId.Value,
            FirstName: player.FirstName.Value,
            LastName: player.LastName.Value,
            PlayerAddress: new AddressDto(
                player.PlayerAddress.AddressLine,
                player.PlayerAddress.Country,
                player.PlayerAddress.State,
                player.PlayerAddress.ZipCode),
            PlayerDetail: new PlayerDetailDto(
                player.PlayerDetail.EmailAddress,
                player.PlayerDetail.PhoneNumber,
                player.PlayerDetail.BirthDate,
                player.PlayerDetail.Height,
                player.PlayerDetail.Weight,
                player.PlayerDetail.Position),
            Description: player.Description,
            ImageFile: player.ImageFile,
            PlayerStatus: player.PlayerStatus
            );
    }
}
