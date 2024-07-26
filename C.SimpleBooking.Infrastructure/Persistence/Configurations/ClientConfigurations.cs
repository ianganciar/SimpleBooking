using D.SimpleBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C.SimpleBooking.Infrastructure.Persistence.Configurations;
public class ClientConfigurations : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(c => c.Professional)
            .WithMany(p => p.Clients)
            .HasForeignKey(c => c.IdProfessional)
            .OnDelete(DeleteBehavior.Restrict);

        builder.OwnsOne(p => p.Name, n =>
        {
            n.Property(name => name.FirstName)
            .IsRequired()
            .HasColumnName("FirstName")
            .HasMaxLength(50);

            n.Property(name => name.LastName)
            .IsRequired()
            .HasColumnName("LastName")
            .HasMaxLength(50);
        });

        builder.OwnsOne(p => p.Email, e =>
        {
            e.Property(email => email.Value)
            .IsRequired()
            .HasColumnName("Email")
            .HasMaxLength(100);
        });

        builder.Property(c => c.Phone)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.IdProfessional)
            .IsRequired();
    }
}
