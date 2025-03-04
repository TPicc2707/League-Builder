namespace Stats.Application.Exceptions;

public class PlayerBasketballStatsByGameNotFoundException : NotFoundException
{
    public PlayerBasketballStatsByGameNotFoundException(Guid id) : base("Player for Game", id)
    {
        
    }
}
