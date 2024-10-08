namespace Team.Application.Exceptions;
public class LeagueNotFoundException : NotFoundException
{
    public LeagueNotFoundException(Guid id) : base("League", id)
    {

    }
}
