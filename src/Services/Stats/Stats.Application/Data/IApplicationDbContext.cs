using Microsoft.EntityFrameworkCore;
using Stats.Domain.Models;

namespace Stats.Application.Data;

public interface IApplicationDbContext
{
    DbSet<League> Leagues { get; }
    DbSet<Team> Teams { get; }
    DbSet<Player> Players { get; }
    DbSet<Season> Seasons { get; }
    DbSet<Game> Games { get; }
    DbSet<BaseballStats> BaseballStats { get; }
    DbSet<BasketballStats> BasketballStats { get; }
    DbSet<FootballStats> FootballStats { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
