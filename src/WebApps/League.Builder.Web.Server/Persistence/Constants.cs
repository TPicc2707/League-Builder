namespace League.Builder.Web.Server.Persistence
{
    public static class Constants
    {
        private static string BASEBALL = "Baseball";
        private static string BASKETBALL = "Basketball";
        private static string FOOTBALL = "Football";

        public static List<string> When()
        {
            return new List<string>
            {
                "By",
                "Before",
                "After"
            };
        }

        public static List<string> Sports()
        {
            return new List<string>
            {
                "Baseball",
                "Football",
                "Basketball"
            };
        }

        public static List<string> PositionsBySport(string sport)
        {
            if (sport == BASEBALL)
            {
                return new List<string>
                {
                    "Catcher",
                    "First Baseman",
                    "Second Baseman",
                    "Shortstop",
                    "Third Baseman",
                    "Outfield",
                    "Pitcher"
                };
            }

            if (sport == BASKETBALL)
            {
                return new List<string>
                {
                    "Center",
                    "Power Forward",
                    "Small Forward",
                    "Shooting Guard",
                    "Point Guard"
                };
            }

            if (sport == FOOTBALL)
            {
                return new List<string>
                {
                    "Quarterback",
                    "Running Back",
                    "Wide Receiver",
                    "Tight End",
                    "Offensive Lineman",
                    "Defensive Lineman",
                    "Linebacker",
                    "Defensive Back",
                    "Safety",
                    "Kicker",
                    "Punter"
                };
            }

            return new List<string>();
        }

        public static Dictionary<string, string> BaseballPositions()
        {
            return new Dictionary<string, string>
            {
                    { "Catcher", "C" },
                    { "First Baseman", "1B" },
                    { "Second Baseman", "2B" },
                    { "Shortstop", "SS" },
                    { "Third Baseman", "3B" },
                    { "Outfield", "OF" },
                    { "Pitcher", "P" },
              };
        }

        public static List<string> States()
        {
            return new List<string>
            {
                "AL",
                "AK",
                "AZ",
                "AR",
                "CA",
                "CO",
                "CT",
                "DE",
                "FL",
                "GA",
                "HI",
                "ID",
                "IL",
                "IN",
                "IA",
                "KS",
                "KY",
                "LA",
                "ME",
                "MD",
                "MA",
                "MI",
                "MN",
                "MS",
                "MO",
                "MT",
                "NC",
                "NE",
                "NV",
                "NH",
                "NJ",
                "NM",
                "NY",
                "ND",
                "OH",
                "OK",
                "OR",
                "PA",
                "RI",
                "SC",
                "SD",
                "TN",
                "TX",
                "UT",
                "VT",
                "VA",
                "WA",
                "WV",
                "WI",
                "WY",
                "DC",
                "AS",
                "GU",
                "MP",
                "PR",
                "UM",
                "VI"
            };
        }

        public static List<string> Countries()
        {
            return new List<string>
            {
                "US"
            };
        }

        public static Dictionary<string, int> Months()
        {
            return new Dictionary<string, int>
            {
                { "January", 1},
                { "February", 2},
                { "March", 3},
                { "April", 4},
                { "May", 5},
                { "June", 6},
                { "July", 7},
                { "August", 8},
                { "September", 9},
                { "October", 10},
                { "November", 11},
                { "December", 12}
            };
        }

        public static List<int> DaysOfMonth()
        {
            return new List<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31
            };
        }

        public static Dictionary<int, string> Height()
        {
            return new Dictionary<int, string>
            {
                { 48, "4'0" },
                { 49, "4'1" },
                { 50, "4'2" },
                { 51, "4'3" },
                { 52, "4'4" },
                { 53, "4'5" },
                { 54, "4'6" },
                { 55, "4'7" },
                { 56, "4'8" },
                { 57, "4'9" },
                { 58, "4'10" },
                { 59, "4'11" },
                { 60, "5'0" },
                { 61, "5'1" },
                { 62, "5'2" },
                { 63, "5'3" },
                { 64, "5'4" },
                { 65, "5'5" },
                { 66, "5'6" },
                { 67, "5'7" },
                { 68, "5'8" },
                { 69, "5'9" },
                { 70, "5'10" },
                { 71, "5'11" },
                { 72, "6'0" },
                { 73, "6'1" },
                { 74, "6'2" },
                { 75, "6'3" },
                { 76, "6'4" },
                { 77, "6'5" },
                { 78, "6'6" },
                { 79, "6'7" },
                { 80, "6'8" },
                { 81, "6'9" },
                { 82, "6'10" },
                { 83, "6'11" },
                { 84, "7'0" },
                { 85, "7'1" },
                { 86, "7'2" },
                { 87, "7'3" },
                { 88, "7'4" },
                { 89, "7'5" },
                { 90, "7'6" },
                { 91, "7'7" },
                { 92, "7'8" },
                { 93, "7'9" },
                { 94, "7'10" },
                { 95, "7'11" },
                { 96, "8'0" }
            };
        }

        public static List<int> BattingOrder()
        {
            return new List<int>()
            {
               1,2,3,4,5,6,7,8,9
            };
        }

        public static string GameStatus(GameStatus status)
        {
            if (status == Models.Game.GameStatus.NotStarted)
                return "Not Started";

            if (status == Models.Game.GameStatus.InProgress)
                return "In Progress";

            if (status == Models.Game.GameStatus.Postponed)
                return "Postponed";

            if (status == Models.Game.GameStatus.Delayed)
                return "Delayed";

            if (status == Models.Game.GameStatus.Completed)
                return "Completed";

            return string.Empty;
        }

        public static List<int> JerseyNumbers()
        {
            return Enumerable.Range(0, 100).ToList();
        }
    }

    public static class SportName
    {
        public const string BASEBALL = "Baseball";
        public const string BASKETBALL = "Basketball";
        public const string FOOTBALL = "Football";
    }

    //This filter is for removing pitchers from hitting stats and hitters from pitching stats
    public static class PositionFilter
    {
        public const string BASEBALL = "Pitcher";
    }

    public static class PlayoffTeams
    {
        public const int TwoTeams = 2;
        public const int FourTeams = 4;
        public const int EightTeams = 8;
    }

    public static class BattingOrder
    {
        public const int First = 1;
        public const int Second = 2;
        public const int Third = 3;
        public const int Fourth = 4;
        public const int Fifth = 5;
        public const int Sixth = 6;
        public const int Seventh = 7;
        public const int Eight = 8;
        public const int Ninth = 9;
    }

}