namespace Stats.Application.Players.Commands.CreatePlayer;

public class CreatePlayerHandler(IApplicationDbContext dbContext)
     : ICommandHandler<CreatePlayerCommand, CreatePlayerResult>
{
    public async Task<CreatePlayerResult> Handle(CreatePlayerCommand command, CancellationToken cancellationToken)
    {
        var player = CreateNewPlayer(command.Player);

        dbContext.Players.Add(player);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CreatePlayerResult(player.Id.Value);
    }

    private Player CreateNewPlayer(PlayerDto playerDto)
    {

        var newPlayer = Player.Create(
                id: PlayerId.Of(playerDto.Id),
                firstName: playerDto.FirstName,
                lastName: playerDto.LastName
                );

        return newPlayer;
    }
}
