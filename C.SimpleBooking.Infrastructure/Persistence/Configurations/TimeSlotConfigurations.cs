using D.SimpleBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C.SimpleBooking.Infrastructure.Persistence.Configurations;
public class TimeSlotConfigurations : IEntityTypeConfiguration<TimeSlot>
{
    public void Configure(EntityTypeBuilder<TimeSlot> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.Professional)
            .WithMany(p => p.TimeSlots)
            .HasForeignKey(t => t.ProfessionalId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(t => t.StartTime)
            .IsRequired();

        builder.Property(t => t.EndTime)
            .IsRequired();

        builder.Property(t => t.IsBooked)
            .IsRequired();

        builder.Property(t => t.ProfessionalId)
            .IsRequired();
    }
}
