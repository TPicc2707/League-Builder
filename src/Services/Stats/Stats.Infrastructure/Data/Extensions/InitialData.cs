namespace Stats.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<League> Leagues =>
    new List<League>
    {
        League.Create(LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), "Dummy Baseball League"),
        League.Create(LeagueId.Of(new Guid("05d80a72-d2dd-43c1-8ca0-ef1c0585db3b")), "Dummy Football League"),
        League.Create(LeagueId.Of(new Guid("01924964-763e-4794-8d2f-b4d4b44f2f83")), "Dummy Basketball League")
    };

    public static IEnumerable<Team> Teams =>
    new List<Team>
    {
        Team.Create(TeamId.Of(new Guid("d8bd14ea-efd4-48a0-9e53-321e39681201")), "Cannons"),
        Team.Create(TeamId.Of(new Guid("7dc0013c-f09b-4e47-b4dc-b63161f8f055")), "Bombers"),
        Team.Create(TeamId.Of(new Guid("063770fb-5651-49bd-a04e-74687df1bd57")), "Eagles"),
        Team.Create(TeamId.Of(new Guid("c9dcbacb-16e7-45e0-a496-b66ef212ac16")), "Pirates")
    };

    public static IEnumerable<Player> Players =>
        new List<Player>
        {
            Player.Create(PlayerId.Of(new Guid("2bd14e3b-6dab-4b2c-ac3c-d6c2d73aec35")), "Johnny", "Johnson"),
            Player.Create(PlayerId.Of(new Guid("c429aab2-9427-4cd4-a905-36c64167bab5")), "Larry","Combs"),
            Player.Create(PlayerId.Of(new Guid("1b603592-591a-4362-ad24-d6bf55293496")), "Sean","Walker"),
            Player.Create(PlayerId.Of(new Guid("422d1d74-6603-4e5c-9cd4-2084d427ba9d")), "Timmy","Turner"),
            Player.Create(PlayerId.Of(new Guid("053c5b0e-91c0-4e0c-9b75-eaa8523952fe")), "Jalen","Smith"),
            Player.Create(PlayerId.Of(new Guid("eac710ad-5af0-4a37-9f6b-feb08ff2415c")), "James","Garcia"),
            Player.Create(PlayerId.Of(new Guid("036a529b-1a76-4603-b0df-dfd48cf4c182")), "Ben","Thomas"),
            Player.Create(PlayerId.Of(new Guid("d4c95b68-084d-4630-bd4d-41598dba484f")), "Noah","Jones")
       };

    public static IEnumerable<Season> Seasons =>
        new List<Season>
        {
            //TODO
        };

    public static IEnumerable<Game> Games =>
        new List<Game>
        {
            //TODO
        };

    public static IEnumerable<BaseballStats> BaseballStats =>
        new List<BaseballStats>
        {
            //TODO
        };

    public static IEnumerable<BasketballStats> BasketballStats =>
        new List<BasketballStats>
        {
            //TODO
        };

    public static IEnumerable<FootballStats> FootballStats =>
        new List<FootballStats>
        {
            //TODO

        };

}