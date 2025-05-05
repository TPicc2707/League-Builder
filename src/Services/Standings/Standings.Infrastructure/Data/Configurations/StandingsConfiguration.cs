namespace Standings.Infrastructure.Data.Configurations;

public class StandingsConfiguration : IEntityTypeConfiguration<Domain.Models.Standings>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Standings> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
                gameId => gameId.Value,
                dbId => StandingsId.Of(dbId));

        builder.HasOne<League>()
           .WithMany()
           .HasForeignKey(o => o.LeagueId)
           .IsRequired();

        builder.HasOne<Team>()
            .WithMany()
            .HasForeignKey(o => o.TeamId)
            .IsRequired();

        builder.HasOne<Season>()
            .WithMany()
            .HasForeignKey(o => o.SeasonId)
            .IsRequired();

        builder.ComplexProperty(
            g => g.StandingsDetail, standingsDetailBuilder =>
            {
                standingsDetailBuilder.Property(x => x.GamesPlayed);
                standingsDetailBuilder.Property(x => x.Wins);
                standingsDetailBuilder.Property(x => x.Losses);
                standingsDetailBuilder.Property(x => x.Ties);
                standingsDetailBuilder.Property(x => x.WinPercentage);
            });

        builder.Property(t => t.StandingsStatus)
            .HasDefaultValue(StandingsStatus.NotStarted)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (StandingsStatus)Enum.Parse(typeof(StandingsStatus), dbStatus));
    }
}
