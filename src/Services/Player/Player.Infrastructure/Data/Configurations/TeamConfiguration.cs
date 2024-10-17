namespace Player.Infrastructure.Data.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).HasConversion(
                customerId => customerId.Value,
                dbId => TeamId.Of(dbId));

        builder.Property(c => c.TeamName).HasMaxLength(50).IsRequired();

        builder.Property(x => x.Description);
    }
}
