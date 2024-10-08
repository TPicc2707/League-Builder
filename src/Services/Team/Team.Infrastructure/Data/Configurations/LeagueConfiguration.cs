namespace Team.Infrastructure.Data.Configurations;
public class LeagueConfiguration : IEntityTypeConfiguration<League>
{
    public void Configure(EntityTypeBuilder<League> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).HasConversion(
                customerId => customerId.Value,
                dbId => LeagueId.Of(dbId));

        builder.Property(c => c.Name).HasMaxLength(150).IsRequired();

        builder.ComplexProperty(
            l => l.Sport, namebuilder =>
            {
                namebuilder.Property(n => n.Value)
                    .HasColumnName(nameof(League.Sport))
                    .HasMaxLength(50)
                    .IsRequired();
            });

        builder.Property(x => x.Description);

    }
}

