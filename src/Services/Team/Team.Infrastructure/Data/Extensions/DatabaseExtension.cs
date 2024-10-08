namespace Team.Infrastructure.Data.Extensions;
public static class DatabaseExtension
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
}

