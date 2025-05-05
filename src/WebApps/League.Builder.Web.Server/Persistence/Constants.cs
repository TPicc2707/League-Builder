namespace League.Builder.Web.Server.Persistence
{
    public static class Constants
    {

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

        public static List<string> Positions(string sport)
        {
            if (sport == "Baseball")
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

            if (sport == "Basketball")
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

            if(sport == "Football")
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

        //public static List<string> BasketballPositions()
        //{
        //    return new List<string>
        //    {
        //        "Center",
        //        "Power Forward",
        //        "Small Forward",
        //        "Shooting Guard",
        //        "Point Guard"
        //    };
        //}

        //public static List<string> FootballPositions()
        //{
        //    return new List<string>
        //    {
        //        "Quarterback",
        //        "Running Back",
        //        "Wide Receiver",
        //        "Tight End",
        //        "Offensive Lineman",
        //        "Defensive Lineman",
        //        "Linebacker",
        //        "Defensive Back",
        //        "Safety",
        //        "Kicker",
        //        "Punter"
        //    };
        //}

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
    }

    public static class SportName
    {
        public const string BASEBALL = "Baseball";
        public const string BASKETBALL = "Basketball";
        public const string FOOTBALL = "Football";
    }
}
