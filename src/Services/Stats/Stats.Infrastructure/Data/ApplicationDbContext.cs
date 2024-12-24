namespace Stats.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {

    }


    public DbSet<League> Leagues => Set<League>();

    public DbSet<Team> Teams => Set<Team>();

    public DbSet<Player> Players => Set<Player>();

    public DbSet<Season> Seasons => Set<Season>();

    public DbSet<Game> Games => Set<Game>();
    public DbSet<BaseballStats> BaseballStats => Set<BaseballStats>();

    public DbSet<BasketballStats> BasketballStats => Set<BasketballStats>();

    public DbSet<FootballStats> FootballStats => Set<FootballStats>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

}
