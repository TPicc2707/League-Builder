namespace Stats.Application.Exceptions;

public class FootballStatsNotFoundException : NotFoundException
{
    public FootballStatsNotFoundException(Guid id) : base("Football Stats", id)
    {
        
    }
}
