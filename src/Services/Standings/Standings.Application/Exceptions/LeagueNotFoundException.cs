namespace Standings.Application.Exceptions;

public class LeagueNotFoundException : NotFoundException
{
    public LeagueNotFoundException(Guid id) : base("Team", id)
    {

    }
}
