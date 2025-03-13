namespace Standings.Application.Exceptions;

public class StandingsNotFoundException : NotFoundException
{
    public StandingsNotFoundException(Guid id) : base("Standings", id)
    {

    }
}
