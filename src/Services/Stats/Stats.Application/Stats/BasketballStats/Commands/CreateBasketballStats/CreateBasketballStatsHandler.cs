namespace Stats.Application.Stats.BasketballStats.Commands.CreateBasketballStats;

public class CreateBasketballStatsHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateBasketballStatsCommand, CreateBasketballStatsResult>
{
    public async Task<CreateBasketballStatsResult> Handle(CreateBasketballStatsCommand command, CancellationToken cancellationToken)
    {
        var basketballStats = CreateNewBasketballStats(command.BasketballStats);

        dbContext.BasketballStats.Add(basketballStats);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateBasketballStatsResult(basketballStats.Id.Value);
    }

    private Domain.Models.BasketballStats CreateNewBasketballStats(BasketballStatsDto basketballStatsDto)
    {
        var stats = BasketballPlayerStats.Of(basketballStatsDto.Stats.Start, basketballStatsDto.Stats.Minutes, basketballStatsDto.Stats.Points, basketballStatsDto.Stats.FieldGoalsMade,
                                                   basketballStatsDto.Stats.FieldGoalsAttempted, basketballStatsDto.Stats.FieldGoalPercentage, basketballStatsDto.Stats.ThreePointersMade, basketballStatsDto.Stats.ThreePointersAttempted,
                                                   basketballStatsDto.Stats.ThreePointPercentage, basketballStatsDto.Stats.FreeThrowsMade, basketballStatsDto.Stats.FreeThrowsAttempted, basketballStatsDto.Stats.FreeThrowPercentage, basketballStatsDto.Stats.Rebounds,
                                                   basketballStatsDto.Stats.Assists, basketballStatsDto.Stats.Steals, basketballStatsDto.Stats.Blocks, basketballStatsDto.Stats.Turnovers);

        var newBasketballStat = Domain.Models.BasketballStats.Create(
                id: BasketballStatsId.Of(Guid.NewGuid()),
                leagueId: LeagueId.Of(basketballStatsDto.LeagueId),
                teamId: TeamId.Of(basketballStatsDto.TeamId),
                playerId: PlayerId.Of(basketballStatsDto.PlayerId),
                seasonId: SeasonId.Of(basketballStatsDto.SeasonId),
                gameId: GameId.Of(basketballStatsDto.GameId),
                stats: stats
                );

        return newBasketballStat;
    }
}
