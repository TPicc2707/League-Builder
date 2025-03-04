namespace Stats.Application.Stats.BasketballStats.Commands.UpdateBasketballStats;

public class UpdateBasketballStatsHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateBasketballStatsCommand, UpdateBasketballStatsResult>
{
    public async Task<UpdateBasketballStatsResult> Handle(UpdateBasketballStatsCommand command, CancellationToken cancellationToken)
    {
        //Update Basketball Stats entity from command object
        //save to database
        //return result

        var basketballStatsId = BasketballStatsId.Of(command.BasketballStats.Id);
        var basketballStats = await dbContext.BasketballStats.FindAsync([basketballStatsId], cancellationToken: cancellationToken);
        if (basketballStats is null)
            throw new BasketballStatsNotFoundException(command.BasketballStats.Id);

        UpdateBasketballStatsWithNewValues(basketballStats, command.BasketballStats);

        dbContext.BasketballStats.Update(basketballStats);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateBasketballStatsResult(true);
    }

    private void UpdateBasketballStatsWithNewValues(Domain.Models.BasketballStats basketballStats, BasketballStatsDto basketballStatsDto)
    {
        var stats = BasketballPlayerStats.Of(basketballStatsDto.Stats.Start, basketballStatsDto.Stats.Minutes, basketballStatsDto.Stats.Points, basketballStatsDto.Stats.FieldGoalsMade,
                                                   basketballStatsDto.Stats.FieldGoalsAttempted, basketballStatsDto.Stats.FieldGoalPercentage, basketballStatsDto.Stats.ThreePointersMade, basketballStatsDto.Stats.ThreePointersAttempted,
                                                   basketballStatsDto.Stats.ThreePointPercentage, basketballStatsDto.Stats.FreeThrowsMade, basketballStatsDto.Stats.FreeThrowsAttempted, basketballStatsDto.Stats.FreeThrowPercentage, basketballStatsDto.Stats.Rebounds,
                                                   basketballStatsDto.Stats.Assists, basketballStatsDto.Stats.Steals, basketballStatsDto.Stats.Blocks, basketballStatsDto.Stats.Turnovers);


        basketballStats.Update(
                leagueId: LeagueId.Of(basketballStatsDto.LeagueId),
                teamId: TeamId.Of(basketballStatsDto.TeamId),
                playerId: PlayerId.Of(basketballStatsDto.PlayerId),
                seasonId: SeasonId.Of(basketballStatsDto.SeasonId),
                gameId: GameId.Of(basketballStatsDto.GameId),
                stats: stats);

    }
}
