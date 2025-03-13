namespace Standings.Infrastructure.Data.Configurations;

public class SeasonConfiguration : IEntityTypeConfiguration<Season>
{
    public void Configure(EntityTypeBuilder<Season> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).HasConversion(
                seasonId => seasonId.Value,
                dbId => SeasonId.Of(dbId));

        builder.Property(c => c.Year).IsRequired();
    }
}
