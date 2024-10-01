namespace League.API.Exceptions;
public class LeagueNotFoundException : NotFoundException
{
    public LeagueNotFoundException(Guid Id) : base("League", Id)
    {

    }
}
