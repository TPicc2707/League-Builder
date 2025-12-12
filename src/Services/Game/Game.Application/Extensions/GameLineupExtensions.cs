namespace Game.Application.Extensions;

public static class GameLineupExtensions
{
    public static GameLineupDto ToSingleBaseballGameLineupDto(this Domain.Models.GameLineup gameLineup, Team team)
    {
        return new GameLineupDto(
            Id: gameLineup.Id.Value,
            GameId: gameLineup.GameId.Value,
            TeamId: gameLineup.TeamId.Value,
            BaseballLineup: new BaseballGameLineupDto(
                gameLineup.BaseballLineup.First,
                gameLineup.BaseballLineup.Second,
                gameLineup.BaseballLineup.Third,
                gameLineup.BaseballLineup.Fourth,
                gameLineup.BaseballLineup.Fifth,
                gameLineup.BaseballLineup.Sixth,
                gameLineup.BaseballLineup.Seventh,
                gameLineup.BaseballLineup.Eighth,
                gameLineup.BaseballLineup.Ninth,
                gameLineup.BaseballLineup.StartingPitcher),
            Team: new TeamDto(
                gameLineup.TeamId.Value,
                team.TeamName));
    }


}
