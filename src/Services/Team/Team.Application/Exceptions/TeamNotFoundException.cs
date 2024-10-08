namespace Team.Application.Exceptions;
public class TeamNotFoundException : NotFoundException
{
    public TeamNotFoundException(Guid id) : base("Team", id)
    {
        
    }
}