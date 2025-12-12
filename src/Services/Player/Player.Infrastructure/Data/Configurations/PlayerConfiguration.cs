namespace Player.Infrastructure.Data.Configurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Domain.Models.Player>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Player> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
                playerId => playerId.Value,
                dbId => PlayerId.Of(dbId));

        builder.HasOne<Team>()
            .WithMany()
            .HasForeignKey(o => o.TeamId)
            .IsRequired();

        builder.ComplexProperty(
            p => p.FirstName, namebuilder =>
            {
                namebuilder.Property(n => n.Value)
                    .HasColumnName(nameof(Domain.Models.Player.FirstName))
                    .HasMaxLength(100)
                    .IsRequired();
            });

        builder.ComplexProperty(
            p => p.LastName, namebuilder =>
            {
                namebuilder.Property(n => n.Value)
                    .HasColumnName(nameof(Domain.Models.Player.LastName))
                    .HasMaxLength(100)
                    .IsRequired();
            });

        builder.ComplexProperty(
           p => p.PlayerAddress, addressBuilder =>
           {
               addressBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
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

        builder.ComplexProperty(
            p => p.PlayerDetail, detailBuilder =>
            {
                detailBuilder.Property(d => d.EmailAddress)
                   .HasMaxLength(150)
                   .IsRequired();

                detailBuilder.Property(d => d.PhoneNumber)
                   .HasMaxLength(15)
                   .IsRequired();

                detailBuilder.Property(d => d.BirthDate);

                detailBuilder.Property(d => d.Height);

                detailBuilder.Property(d => d.Weight);

                detailBuilder.Property(d => d.Position);

                detailBuilder.Property(d => d.Number);
            });

        builder.Property(x => x.Description);

        builder.Property(c => c.ImageFile).IsRequired();

        builder.Property(t => t.PlayerStatus)
            .HasDefaultValue(PlayerStatus.OffSeason)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (PlayerStatus)Enum.Parse(typeof(PlayerStatus), dbStatus));
    }
}
