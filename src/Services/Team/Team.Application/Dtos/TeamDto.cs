namespace Team.Application.Dtos;
public record TeamDto(
    Guid Id,
    Guid LeagueId,
    string TeamName,
    AddressDto TeamAddress,
    string Description,
    string ImageFile,
    TeamStatus TeamStatus,
    ManagerDto TeamManager
);
