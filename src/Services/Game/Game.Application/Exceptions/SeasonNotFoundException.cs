namespace Game.Application.Exceptions;

public class SeasonNotFoundException : NotFoundException
{
    public SeasonNotFoundException(Guid id) : base("Season", id)
    {
        
    }
}
