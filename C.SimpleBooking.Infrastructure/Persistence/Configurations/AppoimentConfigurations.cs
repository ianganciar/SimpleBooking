using D.SimpleBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C.SimpleBooking.Infrastructure.Persistence.Configurations;
public class AppoimentConfigurations : IEntityTypeConfiguration<Appoiment>
{
    public void Configure(EntityTypeBuilder<Appoiment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Professional)
            .WithMany(p => p.Appoiments)
            .HasForeignKey(a => a.IdProfessional)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Service)
            .WithMany()
            .HasForeignKey(a => a.IdService)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Client)
            .WithMany(c => c.Appoiments)
            .HasForeignKey(a => a.IdClient)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.TimeSlot)
            .WithMany()
            .HasForeignKey(a => a.IdTimeSlot)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(a => a.IdProfessional)
            .IsRequired();

        builder.Property(a => a.IdClient)
           .IsRequired();

        builder.Property(a => a.IdService)
           .IsRequired();

        builder.Property(a => a.IdTimeSlot)
           .IsRequired();
    }
}
