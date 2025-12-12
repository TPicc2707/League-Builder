namespace Team.Infrastructure.Data.Configurations;
public class TeamConfiguration : IEntityTypeConfiguration<Domain.Models.Team>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Team> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id).HasConversion(
                teamId => teamId.Value,
                dbId => TeamId.Of(dbId));

        builder.HasOne<League>()
            .WithMany()
            .HasForeignKey(o => o.LeagueId)
            .IsRequired();

        builder.ComplexProperty(
            t => t.TeamName, namebuilder =>
            {
                namebuilder.Property(n => n.Value)
                    .HasColumnName(nameof(Domain.Models.Team.TeamName))
                    .HasMaxLength(50)
                    .IsRequired();
            });

        builder.ComplexProperty(
           t => t.TeamAddress, addressBuilder =>
           {
               addressBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

               addressBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();
               addressBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

               addressBuilder.Property(a => a.EmailAddress)
                   .HasMaxLength(150)
                   .IsRequired();

               addressBuilder.Property(a => a.City)
                    .HasMaxLength(50);

               addressBuilder.Property(a => a.Country)
                    .HasMaxLength(50);

               addressBuilder.Property(a => a.State)
                    .HasMaxLength(50);

               addressBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();

           });

        builder.Property(x => x.Description);

        builder.Property(c => c.ImageFile).IsRequired();

        builder.Property(t => t.TeamStatus)
            .HasDefaultValue(TeamStatus.OffSeason)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (TeamStatus)Enum.Parse(typeof(TeamStatus), dbStatus));

        builder.ComplexProperty(
           t => t.TeamManager, addressBuilder =>
           {
               addressBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

               addressBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

               addressBuilder.Property(a => a.EmailAddress)
                   .HasMaxLength(150)
                   .IsRequired();
           });
    }
}
