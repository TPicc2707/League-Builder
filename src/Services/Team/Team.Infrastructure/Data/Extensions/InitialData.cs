namespace Team.Infrastructure.Data.Extensions;
internal class InitialData
{
    public static IEnumerable<League> Leagues =>
    new List<League>
    {
        League.Create(LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), "Dummy Baseball League", Sport.Of("Baseball"), "This league is made experienced for players."),
        League.Create(LeagueId.Of(new Guid("05d80a72-d2dd-43c1-8ca0-ef1c0585db3b")), "Dummy Football League", Sport.Of("Football"), "This league is made experienced for players."),
        League.Create(LeagueId.Of(new Guid("01924964-763e-4794-8d2f-b4d4b44f2f83")), "Dummy Basketball League", Sport.Of("Basketball"), "This league is made experienced for players.")
    };

    public static IEnumerable<Domain.Models.Team> Teams
    {
        get
        {
            var address1 = Address.Of("tony", "piccirilli", "tony-piccirilli@team.com", "123 Way Lane", "US", "Lancaster", "PA", "12345");
            var address2 = Address.Of("john", "doe", "john-doe@team.com", "698 Main Avenue", "US", "Santa Cruz", "CA", "12346");
            var address3 = Address.Of("timmy", "johnson", "timmy-johnson@team.com", "Broadway No:1", "US", "Saratoga Springs", "NY", "12347");
            var address4 = Address.Of("lisa", "monroe", "lisa-monroe@team.com", "741 Second Street", "US", "Gainesville", "FL", "12348");
            var address5 = Address.Of("larry", "sanders", "larry-sanders@team.com", "741 First Street", "US", "Bowling Green", "KY", "47853");

            var team1 = Domain.Models.Team.Create(TeamId.Of(new Guid("d8bd14ea-efd4-48a0-9e53-321e39681201")),
                                                  LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")),
                                                  TeamName.Of("Cannons"),
                                                  teamAddress: address1,
                                                  "We love playing baseball.",
                                                  "team.png");

            var team2 = Domain.Models.Team.Create(TeamId.Of(new Guid("7dc0013c-f09b-4e47-b4dc-b63161f8f055")),
                                                  LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")),
                                                  TeamName.Of("Bombers"),
                                                  teamAddress: address2,
                                                  "We love playing baseball.",
                                                  "team.png");

            var team3 = Domain.Models.Team.Create(TeamId.Of(new Guid("063770fb-5651-49bd-a04e-74687df1bd57")),
                                                  LeagueId.Of(new Guid("05d80a72-d2dd-43c1-8ca0-ef1c0585db3b")),
                                                  TeamName.Of("Eagles"),
                                                  teamAddress: address3,
                                                  "We love playing football.",
                                                  "team.png");

            var team4 = Domain.Models.Team.Create(TeamId.Of(new Guid("c9dcbacb-16e7-45e0-a496-b66ef212ac16")),
                                                  LeagueId.Of(new Guid("05d80a72-d2dd-43c1-8ca0-ef1c0585db3b")),
                                                  TeamName.Of("Pirates"),
                                                  teamAddress: address4,
                                                  "We love playing football.",
                                                  "team.png");

            var team5 = Domain.Models.Team.Create(TeamId.Of(new Guid("0ef05e29-7562-4e93-b710-f875fe293db9")),
                                                  LeagueId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")),
                                                  TeamName.Of("Cardinals"),
                                                  teamAddress: address5,
                                                  "We love playing baseball.",
                                                  "team.png");

            return new List<Domain.Models.Team> { team1, team2, team3, team4, team5 };
        }
    }
}
