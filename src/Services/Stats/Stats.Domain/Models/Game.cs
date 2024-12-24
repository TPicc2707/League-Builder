namespace Stats.Domain.Models;

public class Game : Aggregate<GameId>
{
    public static Game Create(GameId id)
    {
        var game = new Game
        {
            Id = id,
        };

        game.AddDomainEvent(new GameCreatedEvent(game));

        return game;
    }

    public void Update()
    {
        AddDomainEvent(new GameUpdateEvent(this));
    }

}
