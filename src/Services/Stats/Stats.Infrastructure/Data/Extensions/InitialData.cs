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
        Team.Create(TeamId.Of(new Guid("c9dcbacb-16e7-45e0-a496-b66ef212ac16")), "Pirates"),
        Team.Create(TeamId.Of(new Guid("0ef05e29-7562-4e93-b710-f875fe293db9")), "Cardinals")
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
            Player.Create(PlayerId.Of(new Guid("d4c95b68-084d-4630-bd4d-41598dba484f")), "Noah","Jones"),
            Player.Create(PlayerId.Of(new Guid("69752bda-2b77-4eaf-b8d2-4ef2d723a46e")), "Brock","Banner"),
            Player.Create(PlayerId.Of(new Guid("5b32c8d2-ba86-4a16-9c9c-8bb8903205dd")), "Oswald","Jerome"),
            Player.Create(PlayerId.Of(new Guid("dba1c618-826e-4d0c-afb4-df72c599874e")), "Victor","Bazwell"),
            Player.Create(PlayerId.Of(new Guid("f7b4f809-40a3-451b-ae74-1089fa465bd0")), "Kellen","McNeal"),
            Player.Create(PlayerId.Of(new Guid("36b95380-a7be-495d-98eb-ab7faafcadfe")), "Gary","Coleman")
       };

    public static IEnumerable<Season> Seasons =>
        new List<Season>
        {
            //TODO
            Season.Create(SeasonId.Of(new Guid("9baeb193-c9f1-4b92-8d04-dfef45b9ed3c")), 2023),
            Season.Create(SeasonId.Of(new Guid("898a0e75-d5d3-4a05-973f-4eb5153649da")), 2024)
        };

    public static IEnumerable<Game> Games =>
        new List<Game>
        {
            Game.Create(GameId.Of(new Guid("a16ea142-27a2-497c-a33a-5d1fcd985900"))),
            Game.Create(GameId.Of(new Guid("d19157f2-ee31-444e-a423-26784e9e19d5"))),
            Game.Create(GameId.Of(new Guid("dd16ee11-ebc2-4446-9b3b-cc3ba5227cc0"))),
            Game.Create(GameId.Of(new Guid("a4a5a74d-8d24-4b38-8c67-b3f01d02e343"))),
            Game.Create(GameId.Of(new Guid("4d60cf9c-87c2-4f9d-a588-c2b55145b6a2"))),
            Game.Create(GameId.Of(new Guid("84a5e1f3-0945-408a-b1e3-1a4082c94922"))),
            Game.Create(GameId.Of(new Guid("710f3ea1-1b62-47cc-a455-97619b2b53d5"))),
            Game.Create(GameId.Of(new Guid("bb6a9a4a-42e8-4153-b9a6-807763b2d08c")))

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