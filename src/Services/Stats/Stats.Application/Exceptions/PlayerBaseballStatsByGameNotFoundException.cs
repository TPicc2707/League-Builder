namespace Stats.Application.Exceptions;

public class PlayerBaseballStatsByGameNotFoundException : NotFoundException
{
    public PlayerBaseballStatsByGameNotFoundException(Guid id) : base("Player for Game", id)
    {

    }
}