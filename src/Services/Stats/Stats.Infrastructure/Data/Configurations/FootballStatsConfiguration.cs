namespace Stats.Infrastructure.Data.Configurations;

public class FootballStatsConfiguration : IEntityTypeConfiguration<FootballStats>
{
    public void Configure(EntityTypeBuilder<FootballStats> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
                footballStatsId => footballStatsId.Value,
                dbId => FootballStatsId.Of(dbId));

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
           h => h.OffensiveStats, offensiveStatsBuilder =>
           {
               offensiveStatsBuilder.Property(s => s.PassingCompletions);
               offensiveStatsBuilder.Property(s => s.PassingAttempts);
               offensiveStatsBuilder.Property(s => s.PassingCompletionPercentage);
               offensiveStatsBuilder.Property(s => s.PassingYards);
               offensiveStatsBuilder.Property(s => s.PassingYardsPerPlay);
               offensiveStatsBuilder.Property(s => s.LongestPassingPlay);
               offensiveStatsBuilder.Property(s => s.PassingTouchdowns);
               offensiveStatsBuilder.Property(s => s.PassingInterceptions);
               offensiveStatsBuilder.Property(s => s.Sacks);
               offensiveStatsBuilder.Property(s => s.PasserRating);
               offensiveStatsBuilder.Property(s => s.RushingAttempts);
               offensiveStatsBuilder.Property(s => s.RushingYards);
               offensiveStatsBuilder.Property(s => s.RushingYardsAverage);
               offensiveStatsBuilder.Property(s => s.LongestRushingPlay);
               offensiveStatsBuilder.Property(s => s.RushingTouchdowns);
               offensiveStatsBuilder.Property(s => s.RushingFumbles);
               offensiveStatsBuilder.Property(s => s.RushingFumblesLost);
               offensiveStatsBuilder.Property(s => s.Receptions);
               offensiveStatsBuilder.Property(s => s.Targets);
               offensiveStatsBuilder.Property(s => s.ReceivingYards);
               offensiveStatsBuilder.Property(s => s.ReceivingYardsPerPlay);
               offensiveStatsBuilder.Property(s => s.ReceivingTouchdowns);
               offensiveStatsBuilder.Property(s => s.ReceivingFumbles);
               offensiveStatsBuilder.Property(s => s.ReceivingFumblesLost);
               offensiveStatsBuilder.Property(s => s.YardsAfterCatch);

           });

        builder.ComplexProperty(
        h => h.DefensiveStats, defensiveStatsBuilder =>
        {
            defensiveStatsBuilder.Property(s => s.Tackles);
            defensiveStatsBuilder.Property(s => s.Sacks);
            defensiveStatsBuilder.Property(s => s.TacklesForLoss);
            defensiveStatsBuilder.Property(s => s.PassesDefended);
            defensiveStatsBuilder.Property(s => s.DefensiveInterceptions);
            defensiveStatsBuilder.Property(s => s.DefensiveInterceptionYards);
            defensiveStatsBuilder.Property(s => s.LongestDefensiveInterceptionPlay);
            defensiveStatsBuilder.Property(s => s.DefensiveTouchdowns);
            defensiveStatsBuilder.Property(s => s.ForcedFumbles);
            defensiveStatsBuilder.Property(s => s.RecoveredFumbles);
        });

        builder.ComplexProperty(
        h => h.KickingStats, kickingStatsBuilder =>
        {
            kickingStatsBuilder.Property(s => s.FieldGoalsMade);
            kickingStatsBuilder.Property(s => s.FieldGoalsAttempted);
            kickingStatsBuilder.Property(s => s.FieldGoalPercentage);
            kickingStatsBuilder.Property(s => s.ExtraPointsMade);
            kickingStatsBuilder.Property(s => s.ExtraPointsAttempted);
            kickingStatsBuilder.Property(s => s.ExtraPointPercentage);
            kickingStatsBuilder.Property(s => s.Punts);
            kickingStatsBuilder.Property(s => s.PuntingYards);
            kickingStatsBuilder.Property(s => s.LongestPunt);
        });
    }
}
