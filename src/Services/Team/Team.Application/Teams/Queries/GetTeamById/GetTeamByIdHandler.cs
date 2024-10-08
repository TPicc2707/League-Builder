namespace Team.Application.Teams.Queries.GetTeamById;
public class GetTeamByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetTeamByIdQuery, GetTeamByIdResult>
{
    public async Task<GetTeamByIdResult> Handle(GetTeamByIdQuery query, CancellationToken cancellationToken)
    {
        // get teams by id using dbContext
        // return result
        var teamId = TeamId.Of(query.Id);
        var team = await dbContext.Teams.FindAsync([teamId], cancellationToken: cancellationToken);
        if (team is null)
            throw new TeamNotFoundException(query.Id);

        return new GetTeamByIdResult(team.ToSingleTeamDto());
    }
}

