namespace Stats.Infrastructure.Data.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).HasConversion(
                gameId => gameId.Value,
                dbId => GameId.Of(dbId));
    }
}
