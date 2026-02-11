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
}
