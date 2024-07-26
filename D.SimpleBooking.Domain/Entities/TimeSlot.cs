namespace D.SimpleBooking.Domain.Entities;

public class TimeSlot(DateTime startTime, DateTime endTime, int professionalId) : BaseEntity
{
    public DateTime StartTime { get; private set; } = startTime;
    public DateTime EndTime { get; private set; } = endTime;
    public bool IsBooked { get; private set; } = false;
    public int ProfessionalId { get; set; } = professionalId;
    public Professional Professional { get; private set; }

}