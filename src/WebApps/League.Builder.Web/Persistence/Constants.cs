namespace League.Builder.Web.Persistence
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
    }
}
