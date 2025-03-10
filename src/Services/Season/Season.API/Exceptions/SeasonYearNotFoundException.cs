namespace Season.API.Exceptions
{
    public class SeasonYearNotFoundException : NotFoundException
    {
        public SeasonYearNotFoundException(int year) : base("Season", year)
        {

        }
    }
}
