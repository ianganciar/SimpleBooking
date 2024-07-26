using D.SimpleBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C.SimpleBooking.Infrastructure.Persistence.Configurations;
public class ProfessionalConfigurations : IEntityTypeConfiguration<Professional>
{
    public void Configure(EntityTypeBuilder<Professional> builder)
    {
        builder.HasKey(p => p.Id);

        builder.OwnsOne(p => p.Name);
        builder.OwnsOne(p => p.Email);
        builder.OwnsOne(p => p.Address);

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

        builder.OwnsOne(p => p.Address, a =>
        {
            a.Property(address => address.Street)
                    .IsRequired()
                    .HasMaxLength(100);

            a.Property(address => address.Number)
                .IsRequired()
                .HasMaxLength(10);

            a.Property(address => address.Complement)
                .HasMaxLength(50);

            a.Property(address => address.Neighborhood)
                .IsRequired()
                .HasMaxLength(50);

            a.Property(address => address.City)
                .IsRequired()
                .HasMaxLength(50);

            a.Property(address => address.State)
                .IsRequired()
                .HasMaxLength(2);

            a.Property(address => address.ZipCode)
                .IsRequired()
                .HasMaxLength(10);
        });


        builder.OwnsOne(p => p.Email, e =>
        {
            e.Property(email => email.Value)
            .IsRequired()
            .HasColumnName("Email")
            .HasMaxLength(100);
        });



        builder.Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(20);

        builder.Property(p => p.PasswordHash)
                .IsRequired()
                .HasMaxLength(256);

        builder.Property(p => p.Description)
            .HasMaxLength(500);

       

    }
}
