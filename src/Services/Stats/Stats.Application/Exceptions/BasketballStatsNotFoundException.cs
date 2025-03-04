namespace Stats.Application.Exceptions;

public class BasketballStatsNotFoundException : NotFoundException
{
    public BasketballStatsNotFoundException(Guid id) : base("Baskeball Stats", id)
    {

    }
}
