namespace Player.Domain.Models;

public class Player : Entity<PlayerId>
{
    public TeamId TeamId { get; private set; } = default!;
    public FirstName FirstName { get; private set; } = default!;
    public LastName LastName { get; private set;} = default!;
    public Address PlayerAddress { get; private set; } = default!;
    public PlayerDetail PlayerDetail { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string ImageFile { get; private set; } = default!;
    public PlayerStatus PlayerStatus { get; private set; } = default!;

    public static Player Create(PlayerId id, TeamId teamId, FirstName firstName, LastName lastName, Address playerAddress, 
                                PlayerDetail playerDetail, string description, string imageFile)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(imageFile);

        var player = new Player
        {
            Id = id,
            TeamId = teamId,
            FirstName = firstName,
            LastName = lastName,
            PlayerAddress = playerAddress,
            PlayerDetail = playerDetail,
            Description = description,
            ImageFile = imageFile,
            PlayerStatus = PlayerStatus.OffSeason
        };

        return player;
    }

    public void Update(TeamId teamId, FirstName firstName, LastName lastName, Address playerAddress, 
                       PlayerDetail playerDetail, string description, string imageFile, PlayerStatus playerStatus)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(imageFile);

        TeamId = teamId;
        FirstName = firstName;
        LastName = lastName;
        PlayerAddress = playerAddress;
        PlayerDetail = playerDetail;
        Description = description;
        ImageFile = imageFile;
        PlayerStatus = playerStatus;
    }
}
