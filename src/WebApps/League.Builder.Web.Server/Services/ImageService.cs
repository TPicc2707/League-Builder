using OllamaSharp.Models;
using System.Reflection;

namespace League.Builder.Web.Server.Services;

public class ImageService
{
    private readonly IAWSService _aws;

    public ImageService(IAWSService aws)
    {
        _aws = aws;    
    }

    public async Task<string> GetLeagueImageAsync(LeagueModel league)
    {
        string keyPath = $"/{league.Sport}/{league.Name}/{league.ImageFile}";
        return await _aws.GetImage(keyPath);
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

    public async Task UploadLeagueImageAsync(CreateLeagueModel model)
    {
        string keyPath = $"/{model.Sport}/{model.Name}/{model.ImageFile}";

        await _aws.UploadImages(keyPath, model.File);
    }

    public async Task UploadNewPlayerImageAsync(LeagueModel league, TeamModel team, CreatePlayerModel player) 
    {
        var key = $"/{league.Sport}/{league.Name}/teams/{team.TeamName}/players/{String.Concat(player.FirstName, " ", player.LastName)}/{player.ImageFile}";

        await _aws.UploadImages(key, player.File);
    }

    public async Task UploadUpdatedPlayerImageAsync(LeagueModel league, TeamModel team, UpdatePlayerModel player)
    {
        var key = $"/{league.Sport}/{league.Name}/teams/{team.TeamName}/players/{String.Concat(player.FirstName, " ", player.LastName)}/{player.ImageFile}";

        await _aws.UploadImages(key, player.File);
    }

    public async Task CopyPlayerImageForNewTeamAsync(LeagueModel league, TeamModel oldTeam, TeamModel newTeam, PlayerModel player)
    {
        var oldPath = $"/{league.Sport}/{league.Name}/teams/{oldTeam.TeamName}/players/{String.Concat(player.FirstName, " ", player.LastName)}/{player.ImageFile}";
        var newPath = $"/{league.Sport}/{league.Name}/teams/{newTeam.TeamName}/players/{String.Concat(player.FirstName, " ", player.LastName)}/{player.ImageFile}";

        await _aws.CopyObjectToNewFolder(oldPath, newPath);

    }

    public async Task CopyPlayerImageForUpdateAsync(LeagueModel league, TeamModel team, PlayerModel oldPlayer, UpdatePlayerModel newPlayer)
    {
        var oldPath = $"/{league.Sport}/{league.Name}/teams/{team.TeamName}/players/{String.Concat(oldPlayer.FirstName, " ", oldPlayer.LastName)}/{oldPlayer.ImageFile}";
        var newPath = $"/{league.Sport}/{league.Name}/teams/{team.TeamName}/players/{String.Concat(newPlayer.FirstName, " ", newPlayer.LastName)}/{newPlayer.ImageFile}";

        await _aws.CopyObjectToNewFolder(oldPath, newPath);

    }
}
