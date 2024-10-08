﻿namespace Team.Application.Leagues.Commands.CreateLeague;
public class CreateLeagueHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateLeagueCommand, CreateLeagueResult>
{
    public async Task<CreateLeagueResult> Handle(CreateLeagueCommand command, CancellationToken cancellationToken)
    {
        var league = CreateNewLeague(command.League);

        dbContext.Leagues.Add(league);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CreateLeagueResult(league.Id.Value);

    }

    private League CreateNewLeague(LeagueDto leagueDto)
    {

        var newLeague = League.Create(
                id: LeagueId.Of(leagueDto.Id),
                name: leagueDto.Name,
                sport : Sport.Of(leagueDto.Sport),
                description: leagueDto.Description
                );

        return newLeague;
    }
}
