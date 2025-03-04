namespace Stats.Application.Exceptions;

public class PlayerFootballStatsByGameNotFoundException : NotFoundException
{
    public PlayerFootballStatsByGameNotFoundException(Guid id) : base("Player for Game", id)
    {

    }
}
