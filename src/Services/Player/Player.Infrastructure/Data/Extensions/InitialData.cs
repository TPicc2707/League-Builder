namespace Player.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Team> Teams =>
    new List<Team>
    {
        Team.Create(TeamId.Of(new Guid("d8bd14ea-efd4-48a0-9e53-321e39681201")), "Cannons", "We love playing baseball."),
        Team.Create(TeamId.Of(new Guid("7dc0013c-f09b-4e47-b4dc-b63161f8f055")), "Bombers", "We love playing baseball."),
        Team.Create(TeamId.Of(new Guid("063770fb-5651-49bd-a04e-74687df1bd57")), "Eagles", "We love playing football."),
        Team.Create(TeamId.Of(new Guid("c9dcbacb-16e7-45e0-a496-b66ef212ac16")), "Pirates", "We love playing football.")
    };

    public static IEnumerable<Domain.Models.Player> Players
    {
        get
        {
            var address1 = Address.Of("875 Derby Road", "US", "PA", "52134");
            var playerDetail1 = PlayerDetail.Of("jj@email.com", "1234567890", new DateTime(2003, 02, 14), 72, 215, "Second Baseman", 0);

            var address2 = Address.Of("142 Philly Drive", "US", "PA", "52134");
            var playerDetail2 = PlayerDetail.Of("lc@email.com", "2345678901", new DateTime(2002, 11, 25), 76, 224, "First Baseman", 0);

            var address3 = Address.Of("123 1st Street", "US", "CA", "12346");
            var playerDetail3 = PlayerDetail.Of("sw@email.com", "3456789012", new DateTime(2001, 05, 06), 75, 251, "Third Baseman", 0);

            var address4 = Address.Of("564 2nd Street", "US", "CA", "12346");
            var playerDetail4 = PlayerDetail.Of("tt@email.com", "4567890123", new DateTime(2003, 08, 19), 79, 201, "Pitcher", 0);

            var address5 = Address.Of("Broadway No:1", "US", "NY", "12347");
            var playerDetail5 = PlayerDetail.Of("js@email.com", "5678901234", new DateTime(2001, 01, 02), 74, 276, "Defensive Lineman", 0);

            var address6 = Address.Of("Broadway No:2", "US", "NY", "12347");
            var playerDetail6 = PlayerDetail.Of("jg@email.com", "6789012345", new DateTime(2002, 05, 05), 71, 243, "Tight End", 0);

            var address7 = Address.Of("741 Quick Avenue", "US", "FL", "24512");
            var playerDetail7 = PlayerDetail.Of("bt@email.com", "7890123456", new DateTime(2003, 03, 15), 78, 212, "Quarterback", 0);

            var address8 = Address.Of("741 Second Street", "US", "FL", "24512");
            var playerDetail8 = PlayerDetail.Of("nj@email.com", "8901234567", new DateTime(2001, 09, 23), 74, 205, "Wide Receiver", 0);

            var player1 = Domain.Models.Player.Create(PlayerId.Of(new Guid("2bd14e3b-6dab-4b2c-ac3c-d6c2d73aec35")),
                                                  TeamId.Of(new Guid("d8bd14ea-efd4-48a0-9e53-321e39681201")),
                                                  FirstName.Of("Johnny"),
                                                  LastName.Of("Johnson"),
                                                  playerAddress: address1,
                                                  playerDetail: playerDetail1,
                                                  "Im good at baseball.",
                                                  "player.png");

            var player2 = Domain.Models.Player.Create(PlayerId.Of(new Guid("c429aab2-9427-4cd4-a905-36c64167bab5")),
                                                  TeamId.Of(new Guid("d8bd14ea-efd4-48a0-9e53-321e39681201")),
                                                  FirstName.Of("Larry"),
                                                  LastName.Of("Combs"),
                                                  playerAddress: address2,
                                                  playerDetail: playerDetail2,
                                                  "Im good at baseball.",
                                                  "player.png");

            var player3 = Domain.Models.Player.Create(PlayerId.Of(new Guid("1b603592-591a-4362-ad24-d6bf55293496")),
                                                  TeamId.Of(new Guid("7dc0013c-f09b-4e47-b4dc-b63161f8f055")),
                                                  FirstName.Of("Sean"),
                                                  LastName.Of("Walker"),
                                                  playerAddress: address3,
                                                  playerDetail: playerDetail3,
                                                  "Im good at baseball.",
                                                  "player.png");

            var player4 = Domain.Models.Player.Create(PlayerId.Of(new Guid("422d1d74-6603-4e5c-9cd4-2084d427ba9d")),
                                                  TeamId.Of(new Guid("7dc0013c-f09b-4e47-b4dc-b63161f8f055")),
                                                  FirstName.Of("Timmy"),
                                                  LastName.Of("Turner"),
                                                  playerAddress: address4,
                                                  playerDetail: playerDetail4,
                                                  "Im good at baseball.",
                                                  "player.png");

            var player5 = Domain.Models.Player.Create(PlayerId.Of(new Guid("053c5b0e-91c0-4e0c-9b75-eaa8523952fe")),
                                                  TeamId.Of(new Guid("063770fb-5651-49bd-a04e-74687df1bd57")),
                                                  FirstName.Of("Jalen"),
                                                  LastName.Of("Smith"),
                                                  playerAddress: address5,
                                                  playerDetail: playerDetail5,
                                                  "Im good at football.",
                                                  "player.png");

            var player6 = Domain.Models.Player.Create(PlayerId.Of(new Guid("eac710ad-5af0-4a37-9f6b-feb08ff2415c")),
                                                  TeamId.Of(new Guid("063770fb-5651-49bd-a04e-74687df1bd57")),
                                                  FirstName.Of("James"),
                                                  LastName.Of("Garcia"),
                                                  playerAddress: address6,
                                                  playerDetail: playerDetail6,
                                                  "Im good at football.",
                                                  "player.png");

            var player7 = Domain.Models.Player.Create(PlayerId.Of(new Guid("036a529b-1a76-4603-b0df-dfd48cf4c182")),
                                                  TeamId.Of(new Guid("c9dcbacb-16e7-45e0-a496-b66ef212ac16")),
                                                  FirstName.Of("Ben"),
                                                  LastName.Of("Thomas"),
                                                  playerAddress: address7,
                                                  playerDetail: playerDetail7,
                                                  "Im good at football.",
                                                  "player.png");

            var player8 = Domain.Models.Player.Create(PlayerId.Of(new Guid("d4c95b68-084d-4630-bd4d-41598dba484f")),
                                                  TeamId.Of(new Guid("c9dcbacb-16e7-45e0-a496-b66ef212ac16")),
                                                  FirstName.Of("Noah"),
                                                  LastName.Of("Jones"),
                                                  playerAddress: address8,
                                                  playerDetail: playerDetail8,
                                                  "Im good at football.",
                                                  "player.png");

            return new List<Domain.Models.Player> { player1, player2, player3, player4, player5, player6, player7, player8 };
        }
    }
}
