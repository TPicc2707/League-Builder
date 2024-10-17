namespace Player.Infrastructure.Data.Extensions;

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
        await SeedTeamAsync(context);
        await SeedPlayerAsync(context);
    }

    private static async Task SeedTeamAsync(ApplicationDbContext context)
    {
        if (!await context.Teams.AnyAsync())
        {
            await context.Teams.AddRangeAsync(InitialData.Teams);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedPlayerAsync(ApplicationDbContext context)
    {
        if (!await context.Players.AnyAsync())
        {
            await context.Players.AddRangeAsync(InitialData.Players);
            await context.SaveChangesAsync();
        }
    }

}
