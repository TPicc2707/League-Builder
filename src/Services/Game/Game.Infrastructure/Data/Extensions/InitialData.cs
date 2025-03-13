namespace Game.Infrastructure.Data.Extensions;

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

    public static IEnumerable<Season> Seasons =>
        new List<Season>
        {
            //TODO
            Season.Create(SeasonId.Of(new Guid("9baeb193-c9f1-4b92-8d04-dfef45b9ed3c")), 2023),
            Season.Create(SeasonId.Of(new Guid("898a0e75-d5d3-4a05-973f-4eb5153649da")), 2024)
        };

    public static IEnumerable<Domain.Models.Game> Games
    {
        get
        {
            var gameDetail1 = GameDetail.Of(0, 0, new DateTime(2023, 6, 12, 13, 0, 0), null);
            var game1 = Domain.Models.Game.Create(GameId.Of(new Guid("a16ea142-27a2-497c-a33a-5d1fcd985900")),LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), TeamId.Of(new Guid("D8BD14EA-EFD4-48A0-9E53-321E39681201")), TeamId.Of(new Guid("7DC0013C-F09B-4E47-B4DC-B63161F8F055")),
            SeasonId.Of(new Guid("9baeb193-c9f1-4b92-8d04-dfef45b9ed3c")), gameDetail: gameDetail1);

            var gameDetail2 = GameDetail.Of(0, 0, new DateTime(2024, 6, 15, 13, 0, 0), null);
            var game2 = Domain.Models.Game.Create(GameId.Of(new Guid("d19157f2-ee31-444e-a423-26784e9e19d5")), LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), TeamId.Of(new Guid("7DC0013C-F09B-4E47-B4DC-B63161F8F055")), TeamId.Of(new Guid("D8BD14EA-EFD4-48A0-9E53-321E39681201")),
            SeasonId.Of(new Guid("898a0e75-d5d3-4a05-973f-4eb5153649da")), gameDetail: gameDetail2);

            var gameDetail3 = GameDetail.Of(0, 0, new DateTime(2023, 6, 16, 14, 0, 0), null);
            var game3 = Domain.Models.Game.Create(GameId.Of(new Guid("dd16ee11-ebc2-4446-9b3b-cc3ba5227cc0")), LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), TeamId.Of(new Guid("7DC0013C-F09B-4E47-B4DC-B63161F8F055")), TeamId.Of(new Guid("0ef05e29-7562-4e93-b710-f875fe293db9")),
            SeasonId.Of(new Guid("9baeb193-c9f1-4b92-8d04-dfef45b9ed3c")), gameDetail: gameDetail3);

            var gameDetail4 = GameDetail.Of(0, 0, new DateTime(2024, 6, 18, 14, 0, 0), null);
            var game4 = Domain.Models.Game.Create(GameId.Of(new Guid("a4a5a74d-8d24-4b38-8c67-b3f01d02e343")), LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), TeamId.Of(new Guid("0ef05e29-7562-4e93-b710-f875fe293db9")), TeamId.Of(new Guid("7DC0013C-F09B-4E47-B4DC-B63161F8F055")),
            SeasonId.Of(new Guid("898a0e75-d5d3-4a05-973f-4eb5153649da")), gameDetail: gameDetail4);

            var gameDetail5 = GameDetail.Of(0, 0, new DateTime(2023, 6, 18, 12, 0, 0), null);
            var game5 = Domain.Models.Game.Create(GameId.Of(new Guid("4d60cf9c-87c2-4f9d-a588-c2b55145b6a2")), LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), TeamId.Of(new Guid("D8BD14EA-EFD4-48A0-9E53-321E39681201")), TeamId.Of(new Guid("0ef05e29-7562-4e93-b710-f875fe293db9")),
            SeasonId.Of(new Guid("9baeb193-c9f1-4b92-8d04-dfef45b9ed3c")), gameDetail: gameDetail5);

            var gameDetail6 = GameDetail.Of(0, 0, new DateTime(2024, 6, 20, 13, 0, 0), null);
            var game6 = Domain.Models.Game.Create(GameId.Of(new Guid("84a5e1f3-0945-408a-b1e3-1a4082c94922")), LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), TeamId.Of(new Guid("0ef05e29-7562-4e93-b710-f875fe293db9")), TeamId.Of(new Guid("D8BD14EA-EFD4-48A0-9E53-321E39681201")),
            SeasonId.Of(new Guid("898a0e75-d5d3-4a05-973f-4eb5153649da")), gameDetail: gameDetail6);

            var gameDetail7 = GameDetail.Of(0, 0, new DateTime(2023, 10, 6, 13, 0, 0), null);
            var game7 = Domain.Models.Game.Create(GameId.Of(new Guid("710f3ea1-1b62-47cc-a455-97619b2b53d5")), LeagueId.Of(new Guid("05d80a72-d2dd-43c1-8ca0-ef1c0585db3b")), TeamId.Of(new Guid("063770FB-5651-49BD-A04E-74687DF1BD57")), TeamId.Of(new Guid("C9DCBACB-16E7-45E0-A496-B66EF212AC16")),
            SeasonId.Of(new Guid("9baeb193-c9f1-4b92-8d04-dfef45b9ed3c")), gameDetail: gameDetail7);

            var gameDetail8 = GameDetail.Of(0, 0, new DateTime(2024, 10, 18, 13, 0, 0), null);
            var game8 = Domain.Models.Game.Create(GameId.Of(new Guid("bb6a9a4a-42e8-4153-b9a6-807763b2d08c")), LeagueId.Of(new Guid("05d80a72-d2dd-43c1-8ca0-ef1c0585db3b")), TeamId.Of(new Guid("C9DCBACB-16E7-45E0-A496-B66EF212AC16")), TeamId.Of(new Guid("063770FB-5651-49BD-A04E-74687DF1BD57")),
            SeasonId.Of(new Guid("898a0e75-d5d3-4a05-973f-4eb5153649da")), gameDetail: gameDetail8);


            return new List<Domain.Models.Game> { game1, game2, game3, game4, game5, game6, game7, game8 };
        }
    }
}
