namespace Game.Infrastructure.Data.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).HasConversion(
                teamId => teamId.Value,
                dbId => TeamId.Of(dbId));

        builder.Property(c => c.TeamName).HasMaxLength(50).IsRequired();
    }
}
