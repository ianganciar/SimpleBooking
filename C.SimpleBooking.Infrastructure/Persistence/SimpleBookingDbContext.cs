using C.SimpleBooking.Infrastructure.Persistence.Configurations;
using D.SimpleBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace C.SimpleBooking.Infrastructure.Persistence;
public class SimpleBookingDbContext(DbContextOptions<SimpleBookingDbContext> options) : DbContext(options)
{
    public DbSet<Professional> Professionals { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Appoiment> Appoiments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SimpleBookingDbContext).Assembly);
    }
}
