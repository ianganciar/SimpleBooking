namespace D.SimpleBooking.Domain.Entities;
public class Service(string title, string description, int durationInMinutes, decimal price, int professionalId) : BaseEntity
{
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;
    public int DurationInMinutes { get; private set; } = durationInMinutes;
    public decimal Price { get; private set; } = price;
    public int ProfessionalId { get; private set; } = professionalId;
    public Professional? Professional { get; private set; }
}
