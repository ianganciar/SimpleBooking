namespace D.SimpleBooking.Domain.Entities;

public class Appoiment(int idProfessional, int idClient, int idService, int idTimeSlot) : BaseEntity
{
    public int IdProfessional { get; private set; } = idProfessional;
    public Professional? Professional { get; private set; }
    public int IdClient { get; private set; } = idClient;
    public Client? Client { get; private set; }
    public int IdService { get; private set; } = idService;
    public Service? Service { get; private set; }
    public int IdTimeSlot { get; private set; } = idTimeSlot;
    public TimeSlot? TimeSlot { get; private set; }



}