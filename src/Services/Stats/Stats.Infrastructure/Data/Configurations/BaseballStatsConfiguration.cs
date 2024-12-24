namespace Stats.Infrastructure.Data.Configurations;

public class BaseballStatsConfiguration : IEntityTypeConfiguration<BaseballStats>
{
    public void Configure(EntityTypeBuilder<BaseballStats> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
                baseballStatsId => baseballStatsId.Value,
                dbId => BaseballStatsId.Of(dbId));

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
           h => h.HittingStats, hittingStatsBuilder =>
           {
               hittingStatsBuilder.Property(s => s.AtBats);
               hittingStatsBuilder.Property(s => s.Hits);
               hittingStatsBuilder.Property(s => s.TotalBases);
               hittingStatsBuilder.Property(s => s.Runs);
               hittingStatsBuilder.Property(s => s.Doubles);
               hittingStatsBuilder.Property(s => s.Triples);
               hittingStatsBuilder.Property(s => s.HomeRuns);
               hittingStatsBuilder.Property(s => s.RunsBattedIn);
               hittingStatsBuilder.Property(s => s.StolenBases);
               hittingStatsBuilder.Property(s => s.Strikeouts);
               hittingStatsBuilder.Property(s => s.Walks);
               hittingStatsBuilder.Property(s => s.Average);
               hittingStatsBuilder.Property(s => s.Slugging);
               hittingStatsBuilder.Property(s => s.OnBasePercentage);
               hittingStatsBuilder.Property(s => s.OnBasePlusSlugging);

           });

        builder.ComplexProperty(
        h => h.PitchingStats, pitchingStatsBuilder =>
        {
            pitchingStatsBuilder.Property(s => s.Wins);
            pitchingStatsBuilder.Property(s => s.Losses);
            pitchingStatsBuilder.Property(s => s.Start);
            pitchingStatsBuilder.Property(s => s.Saves);
            pitchingStatsBuilder.Property(s => s.Innings);
            pitchingStatsBuilder.Property(s => s.HitsAllowed);
            pitchingStatsBuilder.Property(s => s.WalksAllowed);
            pitchingStatsBuilder.Property(s => s.PitchingStrikeouts);
            pitchingStatsBuilder.Property(s => s.WalksHitsPerInning);
        });
    }
}
