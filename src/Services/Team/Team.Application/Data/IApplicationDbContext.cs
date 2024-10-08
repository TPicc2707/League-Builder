namespace Team.Application.Data;
public interface IApplicationDbContext
{
    DbSet<League> Leagues { get; }
    DbSet<Domain.Models.Team> Teams { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
