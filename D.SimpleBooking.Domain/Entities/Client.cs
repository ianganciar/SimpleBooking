using D.SimpleBooking.Domain.ValueObjects;

namespace D.SimpleBooking.Domain.Entities;
public class Client : BaseEntity
{
    protected Client() { }
    public Client(Name name, Email email, string phone, int idProfessional)
    {
        Name = name;
        Email = email;
        Phone = phone;
        IdProfessional = idProfessional;
    }
      
    public  Name? Name { get; private set; } 
    public Email? Email { get; private set; }
    public string? Phone { get; private set; }
    public int IdProfessional { get; set; }
    public Professional? Professional { get; private set; }
    public List<Appoiment> Appoiments { get; private set; } = [];
}
