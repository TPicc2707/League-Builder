namespace Game.Application.Data;

public interface IApplicationDbContext
{
    DbSet<League> Leagues { get; }
    DbSet<Team> Teams { get; }
    DbSet<Season> Seasons { get; }
    DbSet<Domain.Models.Game> Games { get; }
    DbSet<Domain.Models.GameLineup> GameLineups { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
