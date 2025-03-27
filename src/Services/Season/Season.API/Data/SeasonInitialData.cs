namespace Season.API.Data;

public class SeasonInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Models.Season>().AnyAsync())
            return;

        session.Store<Models.Season>(GetPreconfiguedSeasons());
        await session.SaveChangesAsync();

    }

    private static IEnumerable<Models.Season> GetPreconfiguedSeasons() => new List<Models.Season>()
    {
        new()
        {
            Id = new Guid("9baeb193-c9f1-4b92-8d04-dfef45b9ed3c"),
            Year = 2023,
            Description = "This season is for 2023-2024.",
            Created_DateTime = DateTime.Now,
            Created_User = "tony.pic",
            Modified_DateTime = DateTime.Now,
            Modified_User = "tony.pic"
        },
        new()
        {
            Id = new Guid("898a0e75-d5d3-4a05-973f-4eb5153649da"),
            Year = 2024,
            Description = "This season is for 2023-2025.",
            Created_DateTime = DateTime.Now,
            Created_User = "tony.pic",
            Modified_DateTime = DateTime.Now,
            Modified_User = "tony.pic"
        }
    };
}
