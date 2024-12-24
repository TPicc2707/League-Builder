namespace Stats.Application.Players.Commands.UpdatePlayer;

public class UpdatePlayerHandler(IApplicationDbContext dbContext)
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

        UpdateTeamWithNewValues(player, command.Player);

        dbContext.Players.Update(player);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdatePlayerResult(true);
    }

    private void UpdateTeamWithNewValues(Player player, PlayerDto playerDto)
    {
        player.Update(
            firstName: playerDto.FirstName,
            lastName: playerDto.LastName);
    }
}
