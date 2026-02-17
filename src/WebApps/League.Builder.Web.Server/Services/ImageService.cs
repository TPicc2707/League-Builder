namespace League.Builder.Web.Server.Services;

public class ImageService
{
    private readonly IAWSService _aws;

    public ImageService(IAWSService aws)
    {
        _aws = aws;    
    }

    public async Task<string> GetTeamImageAsync(LeagueModel league, TeamModel team)
    {
        var key = $"/{league.Sport}/{league.Name}/teams/{team.TeamName}/{team.ImageFile}";

        return await _aws.GetImage(key);
    }

    public async Task<string> GetPlayerImageAsync(LeagueModel league, TeamModel team, PlayerModel player)
    {
        var key = $"/{league.Sport}/{league.Name}/teams/{team.TeamName}/players/{String.Concat(player.FirstName, " ", player.LastName)}/{player.ImageFile}";

        return await _aws.GetImage(key);
    }
}
