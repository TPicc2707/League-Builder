namespace Player.Application.Players.Commands.UpdatePlayer;

public class UpdatePlayerHandler(IApplicationDbContext dbContext, IPublishEndpoint publishEndpoint)
    : ICommandHandler<UpdatePlayerCommand, UpdatePlayerResult>
{
    public async Task<UpdatePlayerResult> Handle(UpdatePlayerCommand command, CancellationToken cancellationToken)
    {
        //Update Player entity from command object
        //save to database
        //return result

        var playerId = PlayerId.Of(command.Player.Id);
        var player = await dbContext.Players.FindAsync([playerId], cancellationToken: cancellationToken);
        if (player is null)
            throw new PlayerNotFoundException(command.Player.Id);

        await UpdatePlayerWithNewValues(player, command.Player);

        dbContext.Players.Update(player);
        await dbContext.SaveChangesAsync(cancellationToken);

        var eventMessage = new PlayerUpdatedEvent()
        {
            Id = player.Id.Value,
            FirstName = player.FirstName.Value,
            LastName = player.LastName.Value
        };

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        return new UpdatePlayerResult(true);
    }

    private async Task UpdatePlayerWithNewValues(Domain.Models.Player player, PlayerDto playerDto)
    {
        var updatedPlayerAddress = Address.Of(playerDto.PlayerAddress.AddressLine, playerDto.PlayerAddress.City, playerDto.PlayerAddress.Country, playerDto.PlayerAddress.State, playerDto.PlayerAddress.ZipCode);
        var updatedPlayerDetail = PlayerDetail.Of(playerDto.PlayerDetail.EmailAddress, playerDto.PlayerDetail.PhoneNumber, playerDto.PlayerDetail.BirthDate, playerDto.PlayerDetail.Height, playerDto.PlayerDetail.Weight, playerDto.PlayerDetail.Position, playerDto.PlayerDetail.Number);

        player.Update(
            teamId: TeamId.Of(playerDto.TeamId),
                firstName: FirstName.Of(playerDto.FirstName),
                lastName: LastName.Of(playerDto.LastName),
                playerAddress: updatedPlayerAddress,
                playerDetail: updatedPlayerDetail,
                description: playerDto.Description,
                imageFile: playerDto.ImageFile,
                playerStatus: playerDto.PlayerStatus);
    }
}
