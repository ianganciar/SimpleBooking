using D.SimpleBooking.Domain.ValueObjects;

namespace D.SimpleBooking.Domain.Entities;
public class Professional : BaseEntity
{
    //Contrutor utilizado pelo efcore para gerar as migrations
    private Professional()
    {
        Name = new Name(string.Empty, string.Empty);
        Email = new Email(string.Empty);
        Phone = string.Empty;
        Description = string.Empty;
        PasswordHash = string.Empty;
        Address = new Address(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
    }
    public Professional(Name name, Email email, string phone, string passwordHash, string description, Address address)
    {
        Name = name;
        Email = email;
        Phone = phone;
        PasswordHash = passwordHash;
        Description = description;
        Address = address;
    }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public string Phone { get; private set; }
    public string PasswordHash { get; private set; }
    public string Description { get; private set; }
    public Address Address { get; private set; }
    public List<Service> Services { get; private set; } = [];
    public List<Appoiment> Appoiments { get; private set; } = [];
    public List<TimeSlot> TimeSlots { get; private set; } = [];
    public List<Client> Clients { get; private set; } = [];


    public void Update(Name name, string description, Address address)
    {
        Name = name;
        Description = description;
        Address = address;
    }
    public void Delete()
    {
        IsActive = false;
    }
}
