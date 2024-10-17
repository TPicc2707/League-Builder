namespace Player.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Team> Teams { get; }
    DbSet<Domain.Models.Player> Players { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
