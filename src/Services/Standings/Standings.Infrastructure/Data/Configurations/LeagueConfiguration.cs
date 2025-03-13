namespace Standings.Infrastructure.Data.Configurations;

public class LeagueConfiguration : IEntityTypeConfiguration<League>
{
    public void Configure(EntityTypeBuilder<League> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).HasConversion(
        leagueId => leagueId.Value,
        dbId => LeagueId.Of(dbId));

        builder.Property(c => c.Name).HasMaxLength(150).IsRequired();
    }
}
