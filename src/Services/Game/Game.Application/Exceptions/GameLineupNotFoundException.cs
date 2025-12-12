namespace Game.Application.Exceptions;

public class GameLineupNotFoundException : NotFoundException
{
    public GameLineupNotFoundException(Guid id) : base("GameLineup", id)
    {
        
    }
}
