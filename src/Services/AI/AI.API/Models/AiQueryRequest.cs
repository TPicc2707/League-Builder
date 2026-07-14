namespace AI.API.Models;

public class AiQueryRequest
{
    public string Question { get; set; }
}

public class AiAddLeagueRequest
{
    public Guid LeagueId { get; set; }
}

public class AiDeleteLeagueRequest
{
    public Guid LeagueId { get; set; }
}

public class AiAddTeamRequest
{
    public Guid TeamId { get; set; }
}

public class AiDeleteTeamRequest
{
    public Guid TeamId { get; set; }
}

public class AiAddPlayerRequest
{
    public Guid PlayerId { get; set; }
}

public class AiDeletePlayerRequest
{
    public Guid PlayerId { get; set; }
}

public class AiAddSeasonRequest
{
    public Guid SeasonId { get; set; }
}

public class AiDeleteSeasonRequest
{
    public Guid SeasonId { get; set; }
}

public class AiAddStandingsRequest
{
    public Guid StandingsId { get; set; }
}

public class AiDeleteStandingsRequest
{
    public Guid StandingsId { get; set; }
}

public class AiAddGameRequest
{
    public Guid GameId { get; set; }
}

public class AiDeleteGameRequest
{
    public Guid GameId { get; set; }
}

public class AiAddBaseballStatsRequest
{
    public Guid BaseballStatsId { get; set; }
}

public class AiDeleteBaseballStatsRequest
{
    public Guid BaseballStatsId { get; set; }
}

public class AiAddBasketballStatsRequest
{
    public Guid BasketballStatsId { get; set; }
}

public class AiDeleteBasketballStatsRequest
{
    public Guid BasketballStatsId { get; set; }
}

public class AiAddFootballStatsRequest
{
    public Guid FootballStatsId { get; set; }
}

public class AiDeleteFootballStatsRequest
{
    public Guid FootballStatsId { get; set; }
}