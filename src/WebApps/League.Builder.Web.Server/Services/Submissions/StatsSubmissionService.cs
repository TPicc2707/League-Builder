using MudBlazor;
using OllamaSharp.Models;

namespace League.Builder.Web.Server.Services.Submissions;

public class StatsSubmissionService
{
    private readonly IStatsService _statsService;
    private readonly IStatsLocalCacheService _statsLocalCacheService;

    public StatsSubmissionService(IStatsService statsService, IStatsLocalCacheService statsLocalCacheService)
    {
        _statsService = statsService;
        _statsLocalCacheService = statsLocalCacheService;
    }

    public async Task BaseballHittingSubmitAsync(
        BaseballGameStatsModel selected,
        List<BaseballGameStatsModel> model,
        GameModel game,
        Action<BaseballGameStatsModel, BaseballStatsModel> applyTotalDeltas)
    {
        if (selected is null)
            return;

        var form = model.FirstOrDefault(x => x.PlayerId == selected.PlayerId);

            var playerStats = await DataLoader.GetOrLoad(
            () => _statsLocalCacheService.GetBaseballStatsByPlayerCache(selected.PlayerId.ToString()),
            () => _statsService.GetBaseballStatsByPlayer(selected.PlayerId),
            (p) => _statsLocalCacheService.SetBaseballStatsByPlayerCache(selected.PlayerId.ToString(), p)
        );

        var existing = playerStats.BaseballStats.FirstOrDefault(x => x.GameId == selected.GameId);

        if (existing is not null)
        {
            var update = new UpdateBaseballStatsModel(existing.Id, selected.LeagueId, selected.TeamId,
                                                        selected.PlayerId, selected.SeasonId,
                                                        selected.GameId, BuildHittingUpdate(selected), BuildPitchingUpdate(form));

            await _statsService.UpdateBaseballStats(new(update));

            applyTotalDeltas(selected, existing);
        }
        else
        {
            var create = new CreateBaseballStatsModel(selected.LeagueId, selected.TeamId,
                                                        selected.PlayerId, selected.SeasonId,
                                                        selected.GameId, BuildHittingCreate(selected), BuildPitchingCreate(form));

            await _statsService.CreateBaseballStats(new(create));
            applyTotalDeltas(selected, DataLoader.CreateZeroBaseballStats());

        }

        await InvalidateBaseballCaches(selected);
    }

    public async Task BaseballPitchingSubmitAsync(
    BaseballGameStatsModel selected,
    List<BaseballGameStatsModel> model,
    GameModel game,
    Action<BaseballGameStatsModel, BaseballStatsModel> applyTotalDeltas)
    {
        if (selected is null)
            return;

        var form = model.FirstOrDefault(x => x.PlayerId == selected.PlayerId);

        var playerStats = await DataLoader.GetOrLoad(
            () => _statsLocalCacheService.GetBaseballStatsByPlayerCache(selected.PlayerId.ToString()),
            () => _statsService.GetBaseballStatsByPlayer(selected.PlayerId),
            (p) => _statsLocalCacheService.SetBaseballStatsByPlayerCache(selected.PlayerId.ToString(), p)
        );

        var existing = playerStats.BaseballStats.FirstOrDefault(x => x.GameId == selected.GameId);

        if (existing is not null)
        {

            var update = new UpdateBaseballStatsModel(existing.Id, selected.LeagueId, selected.TeamId,
                                                        selected.PlayerId, selected.SeasonId,
                                                        selected.GameId, BuildHittingUpdate(form), BuildPitchingUpdate(selected));

            await _statsService.UpdateBaseballStats(new(update));
            applyTotalDeltas(selected, existing);
        }
        else
        {
            var create = new CreateBaseballStatsModel(selected.LeagueId, selected.TeamId,
                                                        selected.PlayerId, selected.SeasonId,
                                                        selected.GameId, BuildHittingCreate(form), BuildPitchingCreate(selected));

            await _statsService.CreateBaseballStats(new(create));
            applyTotalDeltas(selected, DataLoader.CreateZeroBaseballStats());
        }

        await InvalidateBaseballCaches(form);
    }

    public async Task BasketballSubmitAsync(
        BasketballGameStatsModel selected,
        List<BasketballGameStatsModel> model,
        GameModel game,
        Action<BasketballGameStatsModel, BasketballStatsModel> applyTotalDeltas)
    {
        if (selected is null)
            return;

        var form = model.FirstOrDefault(x => x.PlayerId == selected.PlayerId);

            var playerStats = await DataLoader.GetOrLoad(
            () => _statsLocalCacheService.GetBasketballStatsByPlayerCache(selected.PlayerId.ToString()),
            () => _statsService.GetBasketballStatsByPlayer(selected.PlayerId),
            (p) => _statsLocalCacheService.SetBasketballStatsByPlayerCache(selected.PlayerId.ToString(), p)
        );

        var existing = playerStats.BasketballStats.FirstOrDefault(x => x.GameId == selected.GameId);

        if (existing is not null)
        {

            var update = new UpdateBasketballStatsModel(existing.Id, selected.LeagueId, selected.TeamId,
                                                        selected.PlayerId, selected.SeasonId,
                                                        selected.GameId, BuildBasketballStatsUpdate(selected));

            await _statsService.UpdateBasketballStats(new(update));

            applyTotalDeltas(selected, existing);

        }
        else
        {
            var create = new CreateBasketballStatsModel(selected.LeagueId, selected.TeamId,
                                                        selected.PlayerId, selected.SeasonId,
                                                        selected.GameId, BuildBasketballStatsCreate(selected));

            await _statsService.CreateBasketballStats(new(create));

            applyTotalDeltas(selected, DataLoader.CreateZeroBasketballStats());


        }

        await InvalidateBasketballCaches(selected);
    }

    public async Task FootballPassingSubmitAsync(
        FootballGameStatsModel selected,
        List<FootballGameStatsModel> model,
        GameModel game,
        Action<FootballGameStatsModel, FootballStatsModel> applyTotalDeltas)
    {
        if (selected is null)
            return; 

        var form = model.FirstOrDefault(x => x.PlayerId == selected.PlayerId);

        var playerStats = await DataLoader.GetOrLoad(
        () => _statsLocalCacheService.GetFootballStatsByPlayerCache(selected.PlayerId.ToString()),
        () => _statsService.GetFootballStatsByPlayer(selected.PlayerId),
        (p) => _statsLocalCacheService.SetFootballStatsByPlayerCache(selected.PlayerId.ToString(), p)
        );

        var existing = playerStats.FootballStats.FirstOrDefault(x => x.GameId == selected.GameId);

        if (existing is not null)
        {

            var update = new UpdateFootballStatsModel(existing.Id, selected.LeagueId, selected.TeamId,
                                                                                        selected.PlayerId, selected.SeasonId,
                                                                                        selected.GameId, BuildFootballPassingStatsUpdate(selected, form), BuildFootballDefensiveStatsUpdate(form), BuildFootballKickingStatsUpdate(form));

            await _statsService.UpdateFootballStats(new(update));
            applyTotalDeltas(selected, existing);

        }
        else
        {
            var create = new CreateFootballStatsModel(selected.LeagueId, selected.TeamId,
                                                                                        selected.PlayerId, selected.SeasonId,
                                                                                        selected.GameId, BuildFootballPassingStatsCreate(selected, form), BuildFootballDefensiveStatsCreate(form), BuildFootballKickingStatsCreate(form));

            await _statsService.CreateFootballStats(new(create));
            applyTotalDeltas(selected, DataLoader.CreateZeroFootballStats());

        }

        await InvalidateFootballCaches(selected);
    }

    public async Task FootballRushingSubmitAsync(
    FootballGameStatsModel selected,
    List<FootballGameStatsModel> model,
    GameModel game,
    Action<FootballGameStatsModel, FootballStatsModel> applyTotalDeltas)
    {
        if (selected is null)
            return;

        var form = model.FirstOrDefault(x => x.PlayerId == selected.PlayerId);

        var playerStats = await DataLoader.GetOrLoad(
        () => _statsLocalCacheService.GetFootballStatsByPlayerCache(selected.PlayerId.ToString()),
        () => _statsService.GetFootballStatsByPlayer(selected.PlayerId),
        (p) => _statsLocalCacheService.SetFootballStatsByPlayerCache(selected.PlayerId.ToString(), p)
        );

        var existing = playerStats.FootballStats.FirstOrDefault(x => x.GameId == selected.GameId);

        if (existing is not null)
        {

            var update = new UpdateFootballStatsModel(existing.Id, selected.LeagueId, selected.TeamId,
                                                                                        selected.PlayerId, selected.SeasonId,
                                                                                        selected.GameId, BuildFootballRushingStatsUpdate(selected, form), BuildFootballDefensiveStatsUpdate(form), BuildFootballKickingStatsUpdate(form));

            await _statsService.UpdateFootballStats(new(update));
            applyTotalDeltas(selected, existing);

        }
        else
        {
            var create = new CreateFootballStatsModel(selected.LeagueId, selected.TeamId,
                                                                                        selected.PlayerId, selected.SeasonId,
                                                                                        selected.GameId, BuildFootballRushingStatsCreate(selected, form), BuildFootballDefensiveStatsCreate(form), BuildFootballKickingStatsCreate(form));

            await _statsService.CreateFootballStats(new(create));
            applyTotalDeltas(selected, DataLoader.CreateZeroFootballStats());

        }

        await InvalidateFootballCaches(selected);
    }

    public async Task FootballReceivingSubmitAsync(
    FootballGameStatsModel selected,
    List<FootballGameStatsModel> model,
    GameModel game,
    Action<FootballGameStatsModel, FootballStatsModel> applyTotalDeltas)
    {
        if (selected is null)
            return;

        var form = model.FirstOrDefault(x => x.PlayerId == selected.PlayerId);

        var playerStats = await DataLoader.GetOrLoad(
        () => _statsLocalCacheService.GetFootballStatsByPlayerCache(selected.PlayerId.ToString()),
        () => _statsService.GetFootballStatsByPlayer(selected.PlayerId),
        (p) => _statsLocalCacheService.SetFootballStatsByPlayerCache(selected.PlayerId.ToString(), p)
        );

        var existing = playerStats.FootballStats.FirstOrDefault(x => x.GameId == selected.GameId);

        if (existing is not null)
        {

            var update = new UpdateFootballStatsModel(existing.Id, selected.LeagueId, selected.TeamId,
                                                                                        selected.PlayerId, selected.SeasonId,
                                                                                        selected.GameId, BuildFootballReceivingStatsUpdate(selected, form), BuildFootballDefensiveStatsUpdate(form), BuildFootballKickingStatsUpdate(form));

            await _statsService.UpdateFootballStats(new(update));
            applyTotalDeltas(selected, existing);

        }
        else
        {
            var create = new CreateFootballStatsModel(selected.LeagueId, selected.TeamId,
                                                                                        selected.PlayerId, selected.SeasonId,
                                                                                        selected.GameId, BuildFootballReceivingStatsCreate(selected, form), BuildFootballDefensiveStatsCreate(form), BuildFootballKickingStatsCreate(form));

            await _statsService.CreateFootballStats(new(create));
            applyTotalDeltas(selected, DataLoader.CreateZeroFootballStats());

        }

        await InvalidateFootballCaches(selected);
    }

    public async Task FootballDefensiveSubmitAsync(
    FootballGameStatsModel selected,
    List<FootballGameStatsModel> model,
    GameModel game,
    Action<FootballGameStatsModel, FootballStatsModel> applyTotalDeltas)
    {
        if (selected is null)
            return;

        var form = model.FirstOrDefault(x => x.PlayerId == selected.PlayerId);

        var playerStats = await DataLoader.GetOrLoad(
        () => _statsLocalCacheService.GetFootballStatsByPlayerCache(selected.PlayerId.ToString()),
        () => _statsService.GetFootballStatsByPlayer(selected.PlayerId),
        (p) => _statsLocalCacheService.SetFootballStatsByPlayerCache(selected.PlayerId.ToString(), p)
        );

        var existing = playerStats.FootballStats.FirstOrDefault(x => x.GameId == selected.GameId);

        if (existing is not null)
        {

            var update = new UpdateFootballStatsModel(existing.Id, selected.LeagueId, selected.TeamId,
                                                                                        selected.PlayerId, selected.SeasonId,
                                                                                        selected.GameId, BuildEmptyFootballOffensiveStatsUpdate(form), BuildFootballDefensiveStatsUpdate(selected), BuildFootballKickingStatsUpdate(form));

            await _statsService.UpdateFootballStats(new(update));
            applyTotalDeltas(selected, existing);

        }
        else
        {
            var create = new CreateFootballStatsModel(selected.LeagueId, selected.TeamId,
                                                                                        selected.PlayerId, selected.SeasonId,
                                                                                        selected.GameId, BuildEmptyFootballOffensiveStatsCreate(form), BuildFootballDefensiveStatsCreate(selected), BuildFootballKickingStatsCreate(form));

            await _statsService.CreateFootballStats(new(create));
            applyTotalDeltas(selected, DataLoader.CreateZeroFootballStats());

        }

        await InvalidateFootballCaches(selected);
    }

    public async Task FootballKickingSubmitAsync(
    FootballGameStatsModel selected,
    List<FootballGameStatsModel> model,
    GameModel game,
    Action<FootballGameStatsModel, FootballStatsModel> applyTotalDeltas)
    {
        if (selected is null)
            return;

        var form = model.FirstOrDefault(x => x.PlayerId == selected.PlayerId);

        var playerStats = await DataLoader.GetOrLoad(
        () => _statsLocalCacheService.GetFootballStatsByPlayerCache(selected.PlayerId.ToString()),
        () => _statsService.GetFootballStatsByPlayer(selected.PlayerId),
        (p) => _statsLocalCacheService.SetFootballStatsByPlayerCache(selected.PlayerId.ToString(), p)
        );

        var existing = playerStats.FootballStats.FirstOrDefault(x => x.GameId == selected.GameId);

        if (existing is not null)
        {

            var update = new UpdateFootballStatsModel(existing.Id, selected.LeagueId, selected.TeamId,
                                                                                        selected.PlayerId, selected.SeasonId,
                                                                                        selected.GameId, BuildEmptyFootballOffensiveStatsUpdate(form), BuildFootballDefensiveStatsUpdate(form), BuildFootballKickingStatsUpdate(selected));

            await _statsService.UpdateFootballStats(new(update));
            applyTotalDeltas(selected, existing);

        }
        else
        {
            var create = new CreateFootballStatsModel(selected.LeagueId, selected.TeamId,
                                                                                        selected.PlayerId, selected.SeasonId,
                                                                                        selected.GameId, BuildEmptyFootballOffensiveStatsCreate(form), BuildFootballDefensiveStatsCreate(form), BuildFootballKickingStatsCreate(selected));

            await _statsService.CreateFootballStats(new(create));
            applyTotalDeltas(selected, DataLoader.CreateZeroFootballStats());

        }

        await InvalidateFootballCaches(selected);
    }

    private UpdateBaseballHittingStatsModel BuildHittingUpdate(BaseballGameStatsModel form)
    {
        return new UpdateBaseballHittingStatsModel(form.AtBats, form.Hits,
                                            form.TotalBases, form.Runs,
                                            form.Doubles, form.Triples,
                                            form.HomeRuns, form.RunsBattedIn,
                                            form.StolenBases, form.Strikeouts, form.Walks, form.HitByPitch,
                                            form.SacrificeFly);
    }

    private CreateBaseballHittingStatsModel BuildHittingCreate(BaseballGameStatsModel form)
    {
        return new CreateBaseballHittingStatsModel(form.AtBats, form.Hits,
                                                form.TotalBases, form.Runs,
                                                form.Doubles, form.Triples,
                                                form.HomeRuns, form.RunsBattedIn,
                                                form.StolenBases, form.Strikeouts, form.Walks, form.HitByPitch, form.SacrificeFly);
    }

    private UpdateBaseballPitchingStatsModel BuildPitchingUpdate(BaseballGameStatsModel form)
    {
        return new UpdateBaseballPitchingStatsModel(form.Wins, form.Losses, form.PitchingRuns,
                                                    form.Start, form.Saves, form.Innings,
                                                    form.HitsAllowed, form.WalksAllowed, form.PitchingStrikeouts);

    }

    private CreateBaseballPitchingStatsModel BuildPitchingCreate(BaseballGameStatsModel form)
    {
        return new CreateBaseballPitchingStatsModel(form.Wins, form.Losses, form.PitchingRuns,
                                                form.Start, form.Saves, form.Innings,
                                                form.HitsAllowed, form.WalksAllowed, form.PitchingStrikeouts);

    }

    private UpdateBasketballPlayerStatsModel BuildBasketballStatsUpdate(BasketballGameStatsModel form)
    {
        return new UpdateBasketballPlayerStatsModel(form.Start, form.Minutes,
                                                            form.Points, form.FieldGoalsMade,
                                                            form.FieldGoalsAttempted, form.ThreePointersMade,
                                                            form.ThreePointersAttempted, form.FreeThrowsMade,
                                                            form.FreeThrowsAttempted, form.Rebounds, form.Assists, form.Steals,
                                                            form.Blocks, form.Turnovers, form.Fouls);
    }

    private CreateBasketballPlayerStatsModel BuildBasketballStatsCreate(BasketballGameStatsModel form)
    {
        return new CreateBasketballPlayerStatsModel(form.Start, form.Minutes,
                                                            form.Points, form.FieldGoalsMade,
                                                            form.FieldGoalsAttempted, form.ThreePointersMade,
                                                            form.ThreePointersAttempted, form.FreeThrowsMade,
                                                            form.FreeThrowsAttempted, form.Rebounds, form.Assists, form.Steals,
                                                            form.Blocks, form.Turnovers, form.Fouls);

    }

    private UpdateFootballOffensiveStatsModel BuildEmptyFootballOffensiveStatsUpdate(FootballGameStatsModel form)
    {
        return new UpdateFootballOffensiveStatsModel(form.PassingCompletions, form.PassingAttempts,
                                             form.PassingYards, form.LongestPassingPlay,
                                             form.PassingTouchdowns, form.PassingInterceptions,
                                             form.Sacks, form.RushingAttempts,
                                             form.RushingYards, form.LongestRushingPlay, form.RushingTouchdowns, form.RushingFumbles,
                                             form.RushingFumblesLost, form.Receptions, form.Targets, form.ReceivingYards, form.ReceivingTouchdowns,
                                             form.ReceivingFumbles, form.ReceivingFumblesLost, form.YardsAfterCatch);

    }

    private UpdateFootballOffensiveStatsModel BuildFootballPassingStatsUpdate(FootballGameStatsModel selected, FootballGameStatsModel form)
    {
       return new UpdateFootballOffensiveStatsModel(selected.PassingCompletions, selected.PassingAttempts,
                                            selected.PassingYards, selected.LongestPassingPlay,
                                            selected.PassingTouchdowns, selected.PassingInterceptions,
                                            selected.Sacks, form.RushingAttempts,
                                            form.RushingYards, form.LongestRushingPlay, form.RushingTouchdowns, form.RushingFumbles,
                                            form.RushingFumblesLost, form.Receptions, form.Targets, form.ReceivingYards, form.ReceivingTouchdowns,
                                            form.ReceivingFumbles, form.ReceivingFumblesLost, form.YardsAfterCatch);

    }

    private UpdateFootballOffensiveStatsModel BuildFootballRushingStatsUpdate(FootballGameStatsModel selected, FootballGameStatsModel form)
    {
        return new UpdateFootballOffensiveStatsModel(form.PassingCompletions, form.PassingAttempts,
                                                                form.PassingYards, form.LongestPassingPlay,
                                                                form.PassingTouchdowns, form.PassingInterceptions,
                                                                form.Sacks, selected.RushingAttempts,
                                                                selected.RushingYards, selected.LongestRushingPlay, selected.RushingTouchdowns, selected.RushingFumbles,
                                                                selected.RushingFumblesLost, form.Receptions, form.Targets, form.ReceivingYards, form.ReceivingTouchdowns,
                                                                form.ReceivingFumbles, form.ReceivingFumblesLost, form.YardsAfterCatch);

    }

    private UpdateFootballOffensiveStatsModel BuildFootballReceivingStatsUpdate(FootballGameStatsModel selected, FootballGameStatsModel form)
    {
        return new UpdateFootballOffensiveStatsModel(form.PassingCompletions, form.PassingAttempts,
                                                                form.PassingYards, form.LongestPassingPlay,
                                                                form.PassingTouchdowns, form.PassingInterceptions,
                                                                form.Sacks, form.RushingAttempts,
                                                                form.RushingYards, form.LongestRushingPlay, form.RushingTouchdowns, form.RushingFumbles,
                                                                form.RushingFumblesLost, selected.Receptions, selected.Targets, selected.ReceivingYards, selected.ReceivingTouchdowns,
                                                                selected.ReceivingFumbles, selected.ReceivingFumblesLost, selected.YardsAfterCatch);

    }

    private UpdateFootballDefensiveStatsModel BuildFootballDefensiveStatsUpdate(FootballGameStatsModel form)
    {
        return new UpdateFootballDefensiveStatsModel(form.Tackles, form.DefensiveSacks, form.TacklesForLoss, form.PassesDefended,
                                                                                                form.DefensiveInterceptions, form.DefensiveInterceptionYards, form.LongestDefensiveInterceptionPlay,
                                                                                                form.DefensiveTouchdowns, form.ForcedFumbles, form.RecoveredFumbles);


    }

    private UpdateFootballKickingStatsModel BuildFootballKickingStatsUpdate(FootballGameStatsModel form)
    {
        return new UpdateFootballKickingStatsModel(form.FieldGoalsMade, form.FieldGoalsAttempted, form.ExtraPointsMade,
                                                                                                form.ExtraPointsAttempted, form.LongestKick, form.Points, form.Punts, form.PuntingYards, form.LongestPunt);

    }

    private CreateFootballOffensiveStatsModel BuildEmptyFootballOffensiveStatsCreate(FootballGameStatsModel form)
    {
        return new CreateFootballOffensiveStatsModel(form.PassingCompletions, form.PassingAttempts,
                                             form.PassingYards, form.LongestPassingPlay,
                                             form.PassingTouchdowns, form.PassingInterceptions,
                                             form.Sacks, form.RushingAttempts,
                                             form.RushingYards, form.LongestRushingPlay, form.RushingTouchdowns, form.RushingFumbles,
                                             form.RushingFumblesLost, form.Receptions, form.Targets, form.ReceivingYards, form.ReceivingTouchdowns,
                                             form.ReceivingFumbles, form.ReceivingFumblesLost, form.YardsAfterCatch);

    }

    private CreateFootballOffensiveStatsModel BuildFootballPassingStatsCreate(FootballGameStatsModel selected, FootballGameStatsModel form)
    {
        return new CreateFootballOffensiveStatsModel(selected.PassingCompletions, selected.PassingAttempts,
                                            selected.PassingYards, selected.LongestPassingPlay,
                                            selected.PassingTouchdowns, selected.PassingInterceptions,
                                            selected.Sacks, form.RushingAttempts,
                                            form.RushingYards, form.LongestRushingPlay, form.RushingTouchdowns, form.RushingFumbles,
                                            form.RushingFumblesLost, form.Receptions, form.Targets, form.ReceivingYards, form.ReceivingTouchdowns,
                                            form.ReceivingFumbles, form.ReceivingFumblesLost, form.YardsAfterCatch);

    }

    private CreateFootballOffensiveStatsModel BuildFootballRushingStatsCreate(FootballGameStatsModel selected, FootballGameStatsModel form)
    {
        return new CreateFootballOffensiveStatsModel(form.PassingCompletions, form.PassingAttempts,
                                                                form.PassingYards, form.LongestPassingPlay,
                                                                form.PassingTouchdowns, form.PassingInterceptions,
                                                                form.Sacks, selected.RushingAttempts,
                                                                selected.RushingYards, selected.LongestRushingPlay, selected.RushingTouchdowns, selected.RushingFumbles,
                                                                selected.RushingFumblesLost, form.Receptions, form.Targets, form.ReceivingYards, form.ReceivingTouchdowns,
                                                                form.ReceivingFumbles, form.ReceivingFumblesLost, form.YardsAfterCatch);

    }

    private CreateFootballOffensiveStatsModel BuildFootballReceivingStatsCreate(FootballGameStatsModel selected, FootballGameStatsModel form)
    {
        return new CreateFootballOffensiveStatsModel(form.PassingCompletions, form.PassingAttempts,
                                                                form.PassingYards, form.LongestPassingPlay,
                                                                form.PassingTouchdowns, form.PassingInterceptions,
                                                                form.Sacks, form.RushingAttempts,
                                                                form.RushingYards, form.LongestRushingPlay, form.RushingTouchdowns, form.RushingFumbles,
                                                                form.RushingFumblesLost, selected.Receptions, selected.Targets, selected.ReceivingYards, selected.ReceivingTouchdowns,
                                                                selected.ReceivingFumbles, selected.ReceivingFumblesLost, selected.YardsAfterCatch);

    }

    private CreateFootballDefensiveStatsModel BuildFootballDefensiveStatsCreate(FootballGameStatsModel form)
    {
        return new CreateFootballDefensiveStatsModel(form.Tackles, form.DefensiveSacks, form.TacklesForLoss, form.PassesDefended,
                                                                                                form.DefensiveInterceptions, form.DefensiveInterceptionYards, form.LongestDefensiveInterceptionPlay,
                                                                                                form.DefensiveTouchdowns, form.ForcedFumbles, form.RecoveredFumbles);

    }

    private CreateFootballKickingStatsModel BuildFootballKickingStatsCreate(FootballGameStatsModel form)
    {
        return new CreateFootballKickingStatsModel(form.FieldGoalsMade, form.FieldGoalsAttempted, form.ExtraPointsMade,
                                                                                                form.ExtraPointsAttempted, form.LongestKick, form.Points, form.Punts, form.PuntingYards, form.LongestPunt);

    }

    private async Task InvalidateBaseballCaches(BaseballGameStatsModel form)
    {
        await _statsLocalCacheService.DeleteLeagueBaseballStatsBySeasonCache(form.LeagueId.ToString(), form.SeasonId.ToString());
        await _statsLocalCacheService.DeleteBaseballStatsByTeamCache(form.TeamId.ToString());
        await _statsLocalCacheService.DeleteBaseballStatsByPlayerCache(form.PlayerId.ToString());
        await _statsLocalCacheService.DeletePlayerBaseballStatsBySeasonCache(form.PlayerId.ToString(), form.SeasonId.ToString());
    }


    private async Task InvalidateBasketballCaches(BasketballGameStatsModel form)
    {
        await _statsLocalCacheService.DeleteLeagueBasketballStatsBySeasonCache(form.LeagueId.ToString(), form.SeasonId.ToString());
        await _statsLocalCacheService.DeleteBasketballStatsByTeamCache(form.TeamId.ToString());
        await _statsLocalCacheService.DeleteBasketballStatsByPlayerCache(form.PlayerId.ToString());
        await _statsLocalCacheService.DeletePlayerBasketballStatsBySeasonCache(form.PlayerId.ToString(), form.SeasonId.ToString());
    }

    private async Task InvalidateFootballCaches(FootballGameStatsModel form)
    {
        await _statsLocalCacheService.DeleteLeagueFootballStatsBySeasonCache(form.LeagueId.ToString(), form.SeasonId.ToString());
        await _statsLocalCacheService.DeleteFootballStatsByTeamCache(form.TeamId.ToString());
        await _statsLocalCacheService.DeleteFootballStatsByPlayerCache(form.PlayerId.ToString());
        await _statsLocalCacheService.DeletePlayerFootballStatsBySeasonCache(form.PlayerId.ToString(), form.SeasonId.ToString());
    }


}
