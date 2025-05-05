using Game.Domain.Enum;

namespace Game.Infrastructure.Data.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Domain.Models.Game>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Game> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
                gameId => gameId.Value,
                dbId => GameId.Of(dbId));

        builder.HasOne<League>()
           .WithMany()
           .HasForeignKey(o => o.LeagueId)
           .IsRequired();

        builder.HasOne<Team>()
            .WithMany()
            .HasForeignKey(o => o.AwayTeamId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<Team>()
            .WithMany()
            .HasForeignKey(o => o.HomeTeamId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<Team>()
            .WithMany()
            .HasForeignKey(o => o.WinningTeamId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<Season>()
            .WithMany()
            .HasForeignKey(o => o.SeasonId)
            .IsRequired();

        builder.ComplexProperty(
            g => g.GameDetail, gameDetailBuilder =>
            {
                gameDetailBuilder.Property(x => x.AwayTeamScore);
                gameDetailBuilder.Property(x => x.HomeTeamScore);
                gameDetailBuilder.Property(x => x.StartTime);
                gameDetailBuilder.Property(x => x.EndTime);
            });

        builder.Property(t => t.GameStatus)
            .HasDefaultValue(GameStatus.NotStarted)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (GameStatus)Enum.Parse(typeof(GameStatus), dbStatus));
    }
}
