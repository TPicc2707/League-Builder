namespace Stats.Application.Exceptions;

public class BaseballStatsNotFoundException : NotFoundException
{
    public BaseballStatsNotFoundException(Guid id) : base("Baseball Stats", id)
    {

    }
}
