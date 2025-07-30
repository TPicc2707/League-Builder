namespace League.Builder.Web.Server.Models.Player;

public class PlayerModel
{
    public Guid Id { get; set; }
    public Guid TeamId { get; set; }
    public string TeamName { get; set; } = default!;
    public string Sport { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public AddressModel PlayerAddress { get; set; } = default!;
    public PlayerDetailModel PlayerDetail { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public string Image { get; set; } = default!;
    public PlayerStatus PlayerStatus { get; set; } = default!;
}

public record CreatePlayerModel(
    Guid TeamId,
    string FirstName,
    string LastName,
    AddressModel PlayerAddress,
    PlayerDetailModel PlayerDetail,
    string Description,
    string ImageFile);

public record UpdatePlayerModel(
    Guid Id,
    Guid TeamId,
    string FirstName,
    string LastName,
    AddressModel PlayerAddress,
    PlayerDetailModel PlayerDetail,
    string Description,
    string ImageFile,
    int PlayerStatus);

public record AddressModel(string AddressLine, string Country, string State, string ZipCode);
public record PlayerDetailModel(string EmailAddress, string PhoneNumber, DateTime BirthDate, int Height, int Weight, string Position, int Number);

public enum PlayerStatus
{
    FreeAgent = 1,
    OffSeason = 2,
    InSeason = 3,
    Retired = 4
}

//Request Record
public record UpdatePlayerRequest(UpdatePlayerModel Player);
public record CreatePlayerRequest(CreatePlayerModel Player);


// Response Records
public record GetPlayersResponse(PaginatedResult<PlayerModel> Players);
public record GetPlayerByIdResponse(PlayerModel Player);
public record GetPlayersByTeamResponse(IEnumerable<PlayerModel> Players);
public record GetPlayersByFirstNameResponse(IEnumerable<PlayerModel> Players);
public record GetPlayersByLastNameResponse(IEnumerable<PlayerModel> Players);
public record GetPlayersByPositionResponse(IEnumerable<PlayerModel> Players);
public record GetPlayersByStateResponse(IEnumerable<PlayerModel> Players);
public record GetPlayersByBirthDateResponse(IEnumerable<PlayerModel> Players);
public record GetPlayersBeforeBirthDateResponse(IEnumerable<PlayerModel> Players);
public record GetPlayersAfterBirthDateResponse(IEnumerable<PlayerModel> Players);
public record CreatePlayerResponse(Guid Id);
public record UpdatePlayerResponse(bool IsSuccess);
public record DeletePlayerResponse(bool IsSuccess);

