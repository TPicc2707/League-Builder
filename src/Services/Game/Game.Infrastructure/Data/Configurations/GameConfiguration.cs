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
            .IsRequired();

        builder.HasOne<Team>()
            .WithMany()
            .HasForeignKey(o => o.HomeTeamId)
            .IsRequired();

        builder.HasOne<Team>()
            .WithMany()
            .HasForeignKey(o => o.WinningTeamId);

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
    }
}
