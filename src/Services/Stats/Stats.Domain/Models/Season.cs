namespace Stats.Domain.Models;

public class Season : Aggregate<SeasonId>
{
    public int Year { get; set; }

    public static Season Create(SeasonId id, int year)
    {
        var season = new Season
        {
            Id = id,
            Year = year,
        };

        season.AddDomainEvent(new SeasonCreatedEvent(season));

        return season;
    }

    public void Update(int year)
    {
        Year = year;
        AddDomainEvent(new SeasonUpdateEvent(this));

    }

}
