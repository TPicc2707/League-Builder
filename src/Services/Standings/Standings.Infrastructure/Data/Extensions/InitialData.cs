namespace Standings.Infrastructure.Data.Extensions;

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

    public static IEnumerable<Domain.Models.Standings> Standings
    {
        get
        {
            var standingsDetail1 = StandingsDetail.Of(0, 0, 0, 0);
            var standings1 = Domain.Models.Standings.Create(StandingsId.Of(new Guid("a5d27807-5e80-4aec-b7e0-5b7ae1fdff92")),LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), TeamId.Of(new Guid("D8BD14EA-EFD4-48A0-9E53-321E39681201")),
            SeasonId.Of(new Guid("9baeb193-c9f1-4b92-8d04-dfef45b9ed3c")), standingsDetail: standingsDetail1);

            var standingsDetail2 = StandingsDetail.Of(0, 0, 0, 0);
            var standings2 = Domain.Models.Standings.Create(StandingsId.Of(new Guid("bd9cf1ba-a8ba-437d-b676-40f96cf4a2fc")), LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), TeamId.Of(new Guid("D8BD14EA-EFD4-48A0-9E53-321E39681201")),
            SeasonId.Of(new Guid("898a0e75-d5d3-4a05-973f-4eb5153649da")), standingsDetail: standingsDetail2);

            var standingsDetail3 = StandingsDetail.Of(0, 0, 0, 0);
            var standings3 = Domain.Models.Standings.Create(StandingsId.Of(new Guid("1106d910-1a2e-4c81-b38e-5f8d8a05847c")), LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), TeamId.Of(new Guid("7DC0013C-F09B-4E47-B4DC-B63161F8F055")),
            SeasonId.Of(new Guid("9baeb193-c9f1-4b92-8d04-dfef45b9ed3c")), standingsDetail: standingsDetail3);

            var standingsDetail4 = StandingsDetail.Of(0, 0, 0, 0);
            var standings4 = Domain.Models.Standings.Create(StandingsId.Of(new Guid("fafb6031-b190-4645-8f26-a8efb6d92f7b")), LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), TeamId.Of(new Guid("7DC0013C-F09B-4E47-B4DC-B63161F8F055")),
            SeasonId.Of(new Guid("898a0e75-d5d3-4a05-973f-4eb5153649da")), standingsDetail: standingsDetail4);

            var standingsDetail5 = StandingsDetail.Of(0, 0, 0, 0);
            var standings5 = Domain.Models.Standings.Create(StandingsId.Of(new Guid("2e0f6609-cf42-4bd6-84d5-1bcb5eb734e8")), LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), TeamId.Of(new Guid("0ef05e29-7562-4e93-b710-f875fe293db9")),
            SeasonId.Of(new Guid("9baeb193-c9f1-4b92-8d04-dfef45b9ed3c")), standingsDetail: standingsDetail5);

            var standingsDetail6 = StandingsDetail.Of(0, 0, 0, 0);
            var standings6 = Domain.Models.Standings.Create(StandingsId.Of(new Guid("c8471bf9-4466-44fe-9662-9cd15502f142")), LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), TeamId.Of(new Guid("0ef05e29-7562-4e93-b710-f875fe293db9")),
            SeasonId.Of(new Guid("898a0e75-d5d3-4a05-973f-4eb5153649da")), standingsDetail: standingsDetail6);

            var standingsDetail7 = StandingsDetail.Of(0, 0, 0, 0);
            var standings7 = Domain.Models.Standings.Create(StandingsId.Of(new Guid("07e3cb98-d691-4900-a5d3-ffb69e0f3a70")), LeagueId.Of(new Guid("05d80a72-d2dd-43c1-8ca0-ef1c0585db3b")), TeamId.Of(new Guid("063770FB-5651-49BD-A04E-74687DF1BD57")),
            SeasonId.Of(new Guid("9baeb193-c9f1-4b92-8d04-dfef45b9ed3c")), standingsDetail: standingsDetail7);

            var standingsDetail8 = StandingsDetail.Of(0, 0, 0, 0);
            var standings8 = Domain.Models.Standings.Create(StandingsId.Of(new Guid("d8123fe9-f45f-4e88-895f-6b97f99d0ab3")), LeagueId.Of(new Guid("05d80a72-d2dd-43c1-8ca0-ef1c0585db3b")), TeamId.Of(new Guid("063770FB-5651-49BD-A04E-74687DF1BD57")),
            SeasonId.Of(new Guid("898a0e75-d5d3-4a05-973f-4eb5153649da")), standingsDetail: standingsDetail8);

            var standingsDetail9 = StandingsDetail.Of(0, 0, 0, 0);
            var standings9 = Domain.Models.Standings.Create(StandingsId.Of(new Guid("7bb08647-822e-4bd9-959c-02475618e8c9")), LeagueId.Of(new Guid("05d80a72-d2dd-43c1-8ca0-ef1c0585db3b")), TeamId.Of(new Guid("C9DCBACB-16E7-45E0-A496-B66EF212AC16")),
            SeasonId.Of(new Guid("9baeb193-c9f1-4b92-8d04-dfef45b9ed3c")), standingsDetail: standingsDetail9);

            var standingsDetail10 = StandingsDetail.Of(0, 0, 0, 0);
            var standings10 = Domain.Models.Standings.Create(StandingsId.Of(new Guid("d8123fe9-f45f-4e88-895f-6b97f99d0ab3")), LeagueId.Of(new Guid("05d80a72-d2dd-43c1-8ca0-ef1c0585db3b")), TeamId.Of(new Guid("C9DCBACB-16E7-45E0-A496-B66EF212AC16")),
            SeasonId.Of(new Guid("898a0e75-d5d3-4a05-973f-4eb5153649da")), standingsDetail: standingsDetail10);


            return new List<Domain.Models.Standings> { standings1, standings2, standings3, standings4, standings5, standings6, standings7, standings8, standings9, standings10 };
        }
    }
}
