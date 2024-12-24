namespace Stats.Application.Exceptions;

public class PlayerNotFoundException : NotFoundException
{
    public PlayerNotFoundException(Guid id) : base("Player", id)
    {
        
    }
}
