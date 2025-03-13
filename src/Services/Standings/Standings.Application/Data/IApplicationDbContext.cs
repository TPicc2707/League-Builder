namespace Standings.Application.Data;

public interface IApplicationDbContext
{
    DbSet<League> Leagues { get; }
    DbSet<Team> Teams { get; }
    DbSet<Season> Seasons { get; }
    DbSet<Domain.Models.Standings> Standings { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
