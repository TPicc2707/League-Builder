namespace Game.Infrastructure.Data.Configurations;

public class GameLineupConfiguration : IEntityTypeConfiguration<GameLineup>
{
    public void Configure(EntityTypeBuilder<GameLineup> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
                gameId => gameId.Value,
                dbId => GameLineupId.Of(dbId));

        builder.HasOne<Domain.Models.Game>()
            .WithMany()
            .HasForeignKey(o => o.GameId)
            .IsRequired();

        builder.HasOne<Team>()
            .WithMany()
            .HasForeignKey(o => o.TeamId)
            .IsRequired();

        builder.ComplexProperty(
            g => g.BaseballLineup, gameDetailBuilder =>
            {
                gameDetailBuilder.Property(x => x.First);
                gameDetailBuilder.Property(x => x.Second);
                gameDetailBuilder.Property(x => x.Third);
                gameDetailBuilder.Property(x => x.Fourth);
                gameDetailBuilder.Property(x => x.Fifth);
                gameDetailBuilder.Property(x => x.Sixth);
                gameDetailBuilder.Property(x => x.Seventh);
                gameDetailBuilder.Property(x => x.Eighth);
                gameDetailBuilder.Property(x => x.Ninth);
                gameDetailBuilder.Property(x => x.StartingPitcher);
            });
    }
}
