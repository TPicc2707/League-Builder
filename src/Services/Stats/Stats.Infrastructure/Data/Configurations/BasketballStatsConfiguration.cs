namespace Stats.Infrastructure.Data.Configurations;

public class BasketballStatsConfiguration : IEntityTypeConfiguration<BasketballStats>
{
    public void Configure(EntityTypeBuilder<BasketballStats> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
                basketballStatsId => basketballStatsId.Value,
                dbId => BasketballStatsId.Of(dbId));

        builder.HasOne<League>()
            .WithMany()
            .HasForeignKey(o => o.LeagueId)
            .IsRequired();

        builder.HasOne<Team>()
            .WithMany()
            .HasForeignKey(o => o.TeamId)
            .IsRequired();

        builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(o => o.PlayerId)
            .IsRequired();

        builder.HasOne<Season>()
            .WithMany()
            .HasForeignKey(o => o.SeasonId)
            .IsRequired();

        builder.HasOne<Game>()
            .WithMany()
            .HasForeignKey(o => o.GameId)
            .IsRequired();

        builder.ComplexProperty(
           h => h.Stats, statsBuilder =>
           {
               statsBuilder.Property(s => s.Start);
               statsBuilder.Property(s => s.Minutes);
               statsBuilder.Property(s => s.Points);
               statsBuilder.Property(s => s.FieldGoalsMade);
               statsBuilder.Property(s => s.FieldGoalsAttempted);
               statsBuilder.Property(s => s.FieldGoalPercentage);
               statsBuilder.Property(s => s.ThreePointersMade);
               statsBuilder.Property(s => s.ThreePointersAttempted);
               statsBuilder.Property(s => s.ThreePointPercentage);
               statsBuilder.Property(s => s.FreeThrowsMade);
               statsBuilder.Property(s => s.FreeThrowsAttempted);
               statsBuilder.Property(s => s.FreeThrowPercentage);
               statsBuilder.Property(s => s.Rebounds);
               statsBuilder.Property(s => s.Assists);
               statsBuilder.Property(s => s.Steals);
               statsBuilder.Property(s => s.Blocks);
               statsBuilder.Property(s => s.Turnovers);
               statsBuilder.Property(s => s.Fouls);
           });
    }
}
