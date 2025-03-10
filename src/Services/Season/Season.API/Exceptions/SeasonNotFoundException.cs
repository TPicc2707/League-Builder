namespace Season.API.Exceptions;

public class SeasonNotFoundException : NotFoundException
{
    public SeasonNotFoundException(Guid Id) : base("Season", Id)
    {

    }
}
