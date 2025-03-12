namespace Game.Application.Exceptions;

public class GameNotFoundException : NotFoundException
{
    public GameNotFoundException(Guid id) : base("Game", id)
    {

    }
}
