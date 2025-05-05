namespace Player.Application.Players.Commands.CreatePlayer;

public class CreatePlayerHandler(IApplicationDbContext dbContext, IPublishEndpoint publishEndpoint)
    : ICommandHandler<CreatePlayerCommand, CreatePlayerResult>
{
    public async Task<CreatePlayerResult> Handle(CreatePlayerCommand command, CancellationToken cancellationToken)
    {
        var player = CreateNewPlayer(command.Player);

        dbContext.Players.Add(player);
        await dbContext.SaveChangesAsync(cancellationToken);

        var eventMessage = new PlayerCreationEvent()
        {
            Id = player.Id.Value,
            FirstName = player.FirstName.Value,
            LastName = player.LastName.Value
        };

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        return new CreatePlayerResult(player.Id.Value);
    }

    private Domain.Models.Player CreateNewPlayer(PlayerDto playerDto)
    {
        var playerAddress = Address.Of(playerDto.PlayerAddress.AddressLine, playerDto.PlayerAddress.Country, playerDto.PlayerAddress.State, playerDto.PlayerAddress.ZipCode);
        var playerDetail = PlayerDetail.Of(playerDto.PlayerDetail.EmailAddress, playerDto.PlayerDetail.PhoneNumber, playerDto.PlayerDetail.BirthDate, playerDto.PlayerDetail.Height, playerDto.PlayerDetail.Weight, playerDto.PlayerDetail.Position, playerDto.PlayerDetail.Number);

        var newPlayer = Domain.Models.Player.Create(
                id: PlayerId.Of(Guid.NewGuid()),
                teamId: TeamId.Of(playerDto.TeamId),
                firstName: FirstName.Of(playerDto.FirstName),
                lastName: LastName.Of(playerDto.LastName),
                playerAddress: playerAddress,
                playerDetail: playerDetail,
                description: playerDto.Description,
                imageFile: playerDto.ImageFile
                );

        return newPlayer;
    }
}
