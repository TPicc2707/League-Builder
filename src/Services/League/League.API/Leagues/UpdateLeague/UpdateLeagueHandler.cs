﻿namespace League.API.Leagues.UpdateLeague;

public record UpdateLeagueCommand(Guid Id, string Name, string Sport, string Description, string EmailAddress, string ImageFile)
    : ICommand<UpdateLeagueResult>;

public record UpdateLeagueResult(bool IsSuccess);

public class UpdateLeagueCommandValidator : AbstractValidator<UpdateLeagueCommand>
{
    public UpdateLeagueCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("League Id is required");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
            .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");
        RuleFor(x => x.Sport).NotEmpty().WithMessage("Sport is required");
        RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("Email Address is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
    }
}

public class UpdateLeagueCommandHandler
    (IDocumentSession documentSession, IPublishEndpoint publishEndpoint)
    : ICommandHandler<UpdateLeagueCommand, UpdateLeagueResult>
{
    public async Task<UpdateLeagueResult> Handle(UpdateLeagueCommand command, CancellationToken cancellationToken)
    {
        var league = await documentSession.LoadAsync<Models.League>(command.Id, cancellationToken);

        if (league == null)
        {
            throw new LeagueNotFoundException(command.Id);
        }

        league.Name = command.Name;
        league.Sport = command.Sport;
        league.Description = command.Description;
        league.EmailAddress = command.EmailAddress;
        league.ImageFile = command.ImageFile;
        league.Modified_DateTime = DateTime.Now;
        league.Modified_User = "tony.pic";

        documentSession.Update(league);
        await documentSession.SaveChangesAsync(cancellationToken);

        var eventMessage = league.Adapt<LeagueUpdatedEvent>();

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        return new UpdateLeagueResult(true);
    }
}
