namespace League.API.Data;
public class LeagueInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Models.League>().AnyAsync())
            return;

        session.Store<Models.League>(GetPreconfiguedLeagues());
        await session.SaveChangesAsync();

    }

    private static IEnumerable<Models.League> GetPreconfiguedLeagues() => new List<Models.League>()
    {
        new()
        {
            Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
            Name = "Dummy Baseball League",
            Sport = "Baseball",
            Description = "This league is made experienced players.",
            ImageFile = "league-1.png",
            EmailAddress = "tony.pic@email.com",
            Created_DateTime = DateTime.Now,
            Created_User = "tony.pic",
            Modified_DateTime = DateTime.Now,
            Modified_User = "tony.pic"
        },
        new()
        {
            Id = new Guid("05d80a72-d2dd-43c1-8ca0-ef1c0585db3b"),
            Name = "Dummy Football League",
            Sport = "Football",
            Description = "This league is made experienced players.",
            ImageFile = "league-2.png",
            EmailAddress = "tony.pic@email.com",
            Created_DateTime = DateTime.Now,
            Created_User = "tony.pic",
            Modified_DateTime = DateTime.Now,
            Modified_User = "tony.pic"
        }
    };
}