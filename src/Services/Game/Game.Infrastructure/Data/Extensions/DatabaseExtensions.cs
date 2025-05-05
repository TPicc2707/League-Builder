namespace Game.Infrastructure.Data.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedLeagueAsync(context);
        await SeedTeamAsync(context);
        await SeedSeasonAsync(context);
        await SeedGameAsync(context);
    }

    private static async Task SeedLeagueAsync(ApplicationDbContext context)
    {
        if (!await context.Leagues.AnyAsync())
        {
            await context.Leagues.AddRangeAsync(InitialData.Leagues);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedTeamAsync(ApplicationDbContext context)
    {
        if (!await context.Teams.AnyAsync())
        {
            await context.Teams.AddRangeAsync(InitialData.Teams);
            await context.SaveChangesAsync();
        }
    }
    private static async Task SeedSeasonAsync(ApplicationDbContext context)
    {
        if (!await context.Seasons.AnyAsync())
        {
            await context.Seasons.AddRangeAsync(InitialData.Seasons);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedGameAsync(ApplicationDbContext context)
    {
        if (!await context.Games.AnyAsync())
        {
            await context.Games.AddRangeAsync(InitialData.Games);
            await context.SaveChangesAsync();
        }
    }

}
